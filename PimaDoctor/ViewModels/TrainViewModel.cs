using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PimaDoctor.Views.Interfaces;
using PimaDoctor.Neural;

namespace PimaDoctor.ViewModels
{
    class TrainViewModel
    {
        public TrainViewModel(ITrainView view)
        {
            view.RetrainNetwork += RetrainNetwork;
            view.LoadNetwork += LoadNetwork;
            view.SaveNetwork += SaveNetwork;
            view.CheckForAdminRole += CheckAdmin;
        }

        private bool CheckAdmin()
        {
            if (Utilities.Cache.User.Role.Name == "admin")
                return true;
            return false;
        }

        private bool SaveNetwork(string weight_path, string structure_path)
        {
            return Network.SaveModel(weight_path, structure_path);
        }

        private bool LoadNetwork(string weight_path, string structure_path)
        {
            return Network.LoadModel(weight_path, structure_path);
        }

        private bool RetrainNetwork(string path)
        {
            return Network.TrainNetwork(path);
        }

    }
}
