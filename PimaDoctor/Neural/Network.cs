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

namespace PimaDoctor.Neural
{
    public static class Network
    {
        private static IEnumerable<Diabetes> _records = Enumerable.Empty<Diabetes>();
        private static IEnumerable<Diabetes> _testRecords = Enumerable.Empty<Diabetes>();

        private static void ReadTrainingCsv()
        {
            using var reader = new StreamReader("Datasets/diabetes.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            _records = csv.GetRecords<Diabetes>().ToList();
        }
        
        private static void ReadTestCsv()
        {
            using var reader = new StreamReader("Datasets/test.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            _testRecords = csv.GetRecords<Diabetes>().ToList();
        }

        public static void InitNetwork()
        {
            //Keras.Keras.DisablePySysConsoleLog = true;
            
            ReadTrainingCsv();

            NDArray data = _records.Select(x =>
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
            NDArray outcome = _records.Select(x => (double) x.Outcome).ToArray();
            
            NDarray datanew = data.ToNumpyNET();
            NDarray outcomenew = outcome.ToNumpyNET();
            
            var model = new Sequential();
            model.Add(new Dense(8, activation: "tanh", input_dim: 8, kernel_initializer: "uniform"));
            model.Add(new Dense(12, activation: "tanh", kernel_initializer: "uniform"));
            model.Add(new Dense(1, activation: "sigmoid", kernel_initializer: "uniform"));
            
            model.Compile(optimizer:"adam", loss:"binary_crossentropy", metrics: new string[] { "accuracy" });
            model.Fit(datanew, outcomenew, batch_size: 10, epochs: 800, verbose: 1);
            
            // saving the model to file
            string json = model.ToJson();
            File.WriteAllText("model.json", json);
            model.SaveWeight("model.h5");
        }

        public static void LoadNetwork()
        {
            ReadTestCsv();
            var model = Sequential.ModelFromJson(File.ReadAllText("model.json"));
            model.LoadWeight("model.h5");
            
            NDArray testData = _testRecords.Select(x =>
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
            var test = model.Predict(testDataNew);
        }
    }
}