using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PimaDoctor.Views.Interfaces;

namespace PimaDoctor.ViewModels
{
    class AddUserViewModel
    {
        public AddUserViewModel(IAddUserView view)
        {
            view.GoBackToMenu += Back;
            view.AddUser += AddUser;
            view.GetRoles += GetRoles;
        }

        private string[] GetRoles()
        {
            throw new NotImplementedException();
        }

        private bool AddUser(string username, string password, string role)
        {
            throw new NotImplementedException();
        }

        private void Back()
        {
            throw new NotImplementedException();
        }
    }
}
