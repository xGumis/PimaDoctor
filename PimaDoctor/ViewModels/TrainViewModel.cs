﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PimaDoctor.Views.Interfaces;

namespace PimaDoctor.ViewModels
{
    class TrainViewModel
    {
        public TrainViewModel(ITrainView view)
        {
            view.GetBackToMenu += Back;
            view.RetrainNetwork += RetrainNetwork;
        }

        private bool RetrainNetwork()
        {
            throw new NotImplementedException();
        }

        private void Back()
        {
            throw new NotImplementedException();
        }
    }
}