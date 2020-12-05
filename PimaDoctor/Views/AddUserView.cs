using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PimaDoctor.ViewModels;
using PimaDoctor.Views.Interfaces;

namespace PimaDoctor.Views
{
    public partial class AddUserView : AbstractChangingWindow, IAddUserView
    {
        public AddUserView()
        {
            InitializeComponent();
            viewModel = new AddUserViewModel(this);
            comboBoxRole.Items.Clear();
            comboBoxRole.Items.AddRange(GetRoles());
        }

        private AddUserViewModel viewModel;
        public Func<string, string, string, bool> AddUser { get; set; }
        public Func<string[]> GetRoles { get; set; }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var pass = textBoxPassword.Text;
            if(pass == textBoxConfirm.Text)
            {
                var user = textBoxUsername.Text;
                var role = comboBoxRole.Text;
                if (AddUser(user, pass, role))
                    MessageBox.Show("Pomyślnie dodano użytkownika.");
                else
                    MessageBox.Show("Błąd przy dodawaniu użytkownika.");
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Change_Window(new MenuView());
        }
    }
}
