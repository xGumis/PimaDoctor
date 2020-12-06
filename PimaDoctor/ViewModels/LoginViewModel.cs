using PimaDoctor.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PimaDoctor.Validators;

namespace PimaDoctor.ViewModels
{
    class LoginViewModel
    {
        public LoginViewModel(ILoginView view)
        {
            view.CheckCredentials += CheckCredentials;
            view.Login += Login;
        }

        private void Login(string username)
        {
            Utilities.Cache.User = new UserValidator().GetUserByLogin(username);
        }

        private bool CheckCredentials(string username, string password)
        {
            return new UserValidator().UserLoginValidation(username, password);
        }
    }
}
