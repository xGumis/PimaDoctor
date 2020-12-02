using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PimaDoctor.Views.Interfaces;

namespace PimaDoctor.ViewModels
{
    class ClassifyViewModel
    {
        public ClassifyViewModel(IClassifyView view)
        {
            view.GoBackToMenu += Back;
            view.ClassifyData += ClassifyData;
        }

        private bool ClassifyData(int pregnancies, int glucose, int bloodPressure, int skinThickness, int insulin, double bmi, double diabetesPedigreeFunction, int age)
        {
            throw new NotImplementedException();
        }

        private void Back()
        {
            throw new NotImplementedException();
        }
    }
}
