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
            view.AddUser += AddUser;
            view.GetRoles += GetRoles;
        }

        private string[] GetRoles()
        {
            return Validators.RoleValidator.GetAllRoles().Select(x => x.Name).ToArray();
        }

        private bool AddUser(string username, string password, string role)
        {
            var roleId = Validators.RoleValidator.GetRoleByName(role).Id;
            return Validators.UserValidator.UserAddValidation(username, password, roleId);
        }

    }
}
