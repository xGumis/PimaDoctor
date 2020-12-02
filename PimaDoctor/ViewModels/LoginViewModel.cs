using PimaDoctor.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimaDoctor.ViewModels
{
    class LoginViewModel
    {
        public LoginViewModel(ILoginView view)
        {
            view.CheckCredentials += CheckCredentials;
            view.GetRole += GetRole;
            view.Login += Login;
        }

        private void Login()
        {
            throw new NotImplementedException();
        }

        private string GetRole(string username)
        {
            throw new NotImplementedException();
        }

        private bool CheckCredentials(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
