using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Numpy;
using NumSharp;
using Python.Runtime;

namespace PimaDoctor.Neural
{
    public static class PythonExtensions {
        public static void ExecResource(this PyScope scope, string name) {
            using (Py.GIL()) {
                var asm = Assembly.GetCallingAssembly();
                using var stream = asm.GetManifestResourceStream(asm.GetManifestResourceNames().Single(fn => fn.EndsWith(name, StringComparison.OrdinalIgnoreCase)));
                using var streamReader = new StreamReader(stream, Encoding.UTF8);
                scope.Exec(streamReader.ReadToEnd());
            }
        }

        public static void ExecFile(this PyScope scope, string path) {
            if (!File.Exists(path))
                throw new FileNotFoundException(path);
            var txt = File.ReadAllText(path, Encoding.UTF8);

            using (Py.GIL()) {
                var script = PythonEngine.Compile(txt, new FileInfo(path).FullName, RunFlagType.File);
                scope.Execute(script)?.Dispose();
            }
        }

        public static PyObject GetFunction(this PyScope scope, string funcName) {
            using (Py.GIL()) {
                return scope.Variables()[funcName];
            }
        }

        private static PyScope NumpyInteropScope;
        private static PyObject NumpyConverter;

        public static unsafe NDarray ToNumpyNET(this NDArray nd) {
            using (Py.GIL()) {
                if (NumpyInteropScope == null) {
                    NumpyInteropScope = Py.CreateScope();
                    NumpyInteropScope.ExecResource("numpy_interop.py");
                    NumpyConverter = NumpyInteropScope.GetFunction("to_numpy");
                }

                return new NDarray(NumpyConverter.Invoke(new PyLong((long) nd.Unsafe.Address),
                    new PyLong(nd.size * nd.dtypesize),
                    new PyString(nd.dtype.Name.ToLowerInvariant()),
                    new PyTuple(nd.shape.Select(dim => (PyObject) new PyLong(dim)).ToArray())));
            }
        }
    }
}