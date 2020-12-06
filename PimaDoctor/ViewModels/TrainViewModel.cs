using System;
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
            throw new NotImplementedException();
        }

        private bool LoadNetwork(string weight_path, string structure_path)
        {
            throw new NotImplementedException();
        }

        private bool RetrainNetwork(string path)
        {
            throw new NotImplementedException();
        }

    }
}
