using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PimaDoctor.Views.Interfaces;

namespace PimaDoctor.Views
{
    public partial class LoginView : AbstractChangingWindow, ILoginView
    {
        public LoginView()
        {
            InitializeComponent();
        }

        public Func<string, string, bool> CheckCredentials { get; set; }
        public Func<string, string> GetRole { get; set; }
        public Action Login { get; set; }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var login = textBoxLogin.Text;
            var pass = textBoxPassword.Text;
            if (CheckCredentials(login, pass))
            {
                var role = GetRole(login);
                Login();
            }
            else MessageBox.Show("Nieprawidłowe dane logowania.");
        }
    }
}
