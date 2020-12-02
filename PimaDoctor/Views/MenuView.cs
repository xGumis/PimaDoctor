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
using PimaDoctor.ViewModels;

namespace PimaDoctor.Views
{
    public partial class MenuView : AbstractChangingWindow, IMenu
    {
        public MenuView()
        {
            InitializeComponent();
            viewModel = new MenuViewModel(this);
            if(GetRole() == "admin")
            {
                buttonAddUser.Enabled = true;
                buttonTrain.Enabled = true;
            }
        }

        private MenuViewModel viewModel;
        public Action Logout { get; set; }
        public Action GoToTrain { get; set; }
        public Action GoToClassify { get; set; }
        public Action GoToUserAdd { get; set; }
        public Func<string> GetRole { get; set; }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            GoToTrain();
            Change_Window(new TrainView());
        }

        private void buttonClassify_Click(object sender, EventArgs e)
        {
            GoToClassify();
            Change_Window(new ClassifyView());
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            GoToUserAdd();
            Change_Window(new AddUserView());
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Logout();
            Change_Window(new LoginView());
        }
    }
}
