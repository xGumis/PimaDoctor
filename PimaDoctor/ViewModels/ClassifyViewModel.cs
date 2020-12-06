using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PimaDoctor.Models;
using PimaDoctor.Views.Interfaces;

namespace PimaDoctor.ViewModels
{
    class ClassifyViewModel
    {
        public ClassifyViewModel(IClassifyView view)
        {
            view.ClassifyData += ClassifyData;
        }

        private double ClassifyData(int pregnancies, int glucose, int bloodPressure, int skinThickness, int insulin, double bmi, double diabetesPedigreeFunction, int age)
        {
            var test = new Diabetes()
            {
                Pregnancies = pregnancies,
                Glucose = glucose,
                BloodPressure = bloodPressure,
                SkinThickness = skinThickness,
                Insulin = insulin,
                BMI = bmi,
                DiabetesPedigreeFunction = diabetesPedigreeFunction,
                Age = age
            };
            return Neural.Network.Predict(test);
        }

    }
}
