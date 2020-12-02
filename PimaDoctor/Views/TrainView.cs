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
    public partial class TrainView : AbstractChangingWindow, ITrainView
    {
        public TrainView()
        {
            InitializeComponent();
            viewModel = new TrainViewModel(this);
        }

        private TrainViewModel viewModel;

        public Func<bool> RetrainNetwork { get; set; }
        public Action GetBackToMenu { get; set; }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            if (RetrainNetwork())
            {
                MessageBox.Show("Uczenie sieci powiodło się");
            }
            else
                MessageBox.Show("Uczenie sieci nie powiodło się");
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            GetBackToMenu();
            Change_Window(new MenuView());
        }
    }
}
