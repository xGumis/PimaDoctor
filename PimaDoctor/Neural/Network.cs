using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Keras.Layers;
using Keras.Models;
using Numpy;
using NumSharp;
using PimaDoctor.Models;
using np = NumSharp.np;

namespace PimaDoctor.Neural
{
    public static class Network
    {
        private static BaseModel? _model;

        public static bool TrainNetwork(string path)
        {
            Keras.Keras.DisablePySysConsoleLog = true;
            try
            {
                var records = ReadCsv(path);

                NDArray data = records.Select(x =>
                    new[] {
                    x.Pregnancies,
                    x.Glucose,
                    x.BloodPressure,
                    x.SkinThickness,
                    x.Insulin,
                    x.BMI,
                    x.DiabetesPedigreeFunction,
                    x.Age
                    }).ToArray();
                NDArray outcome = records.Select(x => (double)x.Outcome).ToArray();

                NDarray datanew = data.ToNumpyNET();
                NDarray outcomenew = outcome.ToNumpyNET();

                var model = new Sequential();
                model.Add(new Dense(7, activation: "tanh", input_dim: 8, kernel_initializer: "uniform"));
                model.Add(new Dense(6, activation: "tanh", kernel_initializer: "uniform"));
                model.Add(new Dense(1, activation: "sigmoid", kernel_initializer: "uniform"));

                model.Compile(optimizer: "adam", loss: "binary_crossentropy", metrics: new string[] { "accuracy" });
                model.Fit(datanew, outcomenew, batch_size: 10, epochs: 800, verbose: 1);

                Utilities.Cache.Model = model;
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static bool LoadModel(string weight_path, string structure_path)
        {
            Keras.Keras.DisablePySysConsoleLog = true;
            try
            {
                /*
                 * Reading the model from file
                 */
                Utilities.Cache.Model = BaseModel.ModelFromJson(File.ReadAllText(structure_path));
                Utilities.Cache.Model.LoadWeight(weight_path);
                return true;

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static bool SaveModel(string weight_path, string structure_path)
        {
            Keras.Keras.DisablePySysConsoleLog = true;
            try
            {
                /*
                 * Saving the model to file
                 */
                var json = Utilities.Cache.Model.ToJson();
                File.WriteAllText(structure_path, json);
                Utilities.Cache.Model.SaveWeight(weight_path);
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static double Predict(Diabetes patientTest)
        {
            Keras.Keras.DisablePySysConsoleLog = true;
            var tests = new List<Diabetes> {patientTest};

            NDArray testData = tests.Select(x =>
                new [] {
                    x.Pregnancies,
                    x.Glucose,
                    x.BloodPressure,
                    x.SkinThickness,
                    x.Insulin,
                    x.BMI,
                    x.DiabetesPedigreeFunction,
                    x.Age
                }).ToArray();

            NDarray testDataNew = testData.ToNumpyNET();
            var test = Utilities.Cache.Model.Predict(testDataNew);
            var value = test?[0][0].ToString();
            return Convert.ToDouble(value, CultureInfo.InvariantCulture);
        }
        
        private static List<Diabetes> ReadCsv(string pathToCsv)
        {
            using var reader = new StreamReader(pathToCsv);
            using var writer = new StringWriter();
            while (!reader.EndOfStream)
            {
                writer.WriteLine(Utilities.RSAEncryption.Decrypt(reader.ReadLine()));
            }
            reader.Close();
            using var csv = new CsvReader(new StringReader(writer.ToString()), CultureInfo.InvariantCulture);
            writer.Close();
            return csv.GetRecords<Diabetes>().ToList();
        }
    }
}