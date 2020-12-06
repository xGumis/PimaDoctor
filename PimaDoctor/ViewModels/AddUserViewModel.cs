using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PimaDoctor.Validators;
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
            return new RoleValidator().GetAllRoles().Select(x => x.Name).ToArray();
        }

        private bool AddUser(string username, string password, string role)
        {
            var roleId = new RoleValidator().GetRoleByName(role).Id;
            return new UserValidator().UserAddValidation(username, password, roleId);
        }

    }
}
