using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PimaDoctor.Views.Interfaces;

namespace PimaDoctor.ViewModels
{
    class MenuViewModel
    {
        public MenuViewModel(IMenu view)
        {
            view.Logout += Logout;
            view.GoToClassify += GoToClassify;
            view.GoToTrain += GoToTrain;
            view.GoToUserAdd += GoToUserAdd;
            view.CheckForAdminRole += CheckForAdmin;
        }

        private bool CheckForAdmin()
        {
            if (Utilities.Cache.User.Role.Name == "admin")
                return true;
            return false;
        }

        private void GoToUserAdd()
        {
        }

        private void GoToTrain()
        {
        }

        private void GoToClassify()
        {
        }

        private void Logout()
        {
            Utilities.Cache.Clear();
        }
    }
}
