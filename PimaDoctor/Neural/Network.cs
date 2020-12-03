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

        public static void TrainNetwork()
        {
            Keras.Keras.DisablePySysConsoleLog = true;
            var records = ReadCsv("Datasets/diabetes.csv");

            NDArray data = records.Select(x =>
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
            NDArray outcome = records.Select(x => (double) x.Outcome).ToArray();
            
            NDarray datanew = data.ToNumpyNET();
            NDarray outcomenew = outcome.ToNumpyNET();

            var model = new Sequential();
            model.Add(new Dense(8, activation: "tanh", input_dim: 8, kernel_initializer: "uniform"));
            model.Add(new Dense(12, activation: "tanh", kernel_initializer: "uniform"));
            model.Add(new Dense(1, activation: "sigmoid", kernel_initializer: "uniform"));
            
            model.Compile(optimizer:"adam", loss:"binary_crossentropy", metrics: new string[] { "accuracy" });
            var history = model.Fit(datanew, outcomenew, batch_size: 10, epochs: 800, verbose: 1);
            
            /*
             * Saving the model to file
             */
            var json = model.ToJson();
            File.WriteAllText("model.json", json);
            model.SaveWeight("model.h5");
            var accuracy = history.HistoryLogs.Last().Value.Last();
        }

        public static void LoadModel()
        {
            Keras.Keras.DisablePySysConsoleLog = true;

            /*
             * Reading the model from file
             */
            _model = BaseModel.ModelFromJson(File.ReadAllText("model.json"));
            _model.LoadWeight("model.h5");
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
            var test = _model?.Predict(testDataNew);
            var value = test?[0][0].ToString();
            return Convert.ToDouble(value, CultureInfo.InvariantCulture);
        }
        
        private static List<Diabetes> ReadCsv(string pathToCsv)
        {
            using var reader = new StreamReader(pathToCsv);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<Diabetes>().ToList();
        }
    }
}