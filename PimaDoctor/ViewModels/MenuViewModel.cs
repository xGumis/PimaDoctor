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
        }

        private void GoToUserAdd()
        {
            throw new NotImplementedException();
        }

        private void GoToTrain()
        {
            throw new NotImplementedException();
        }

        private void GoToClassify()
        {
            throw new NotImplementedException();
        }

        private void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
