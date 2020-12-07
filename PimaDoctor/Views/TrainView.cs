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
            if (CheckForAdminRole())
            {
                buttonSave.Enabled = true;
                buttonTrain.Enabled = true;
                buttonEncryptCSV.Enabled = true;
            }
        }

        private TrainViewModel viewModel;

        public Func<string,bool> RetrainNetwork { get; set; }
        public Func<string,string,bool> LoadNetwork { get; set; }
        public Func<string,string,bool> SaveNetwork { get; set; }
        public Func<bool> CheckForAdminRole { get; set; }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            var oDialog = new OpenFileDialog()
            {
                Title = "Wybierz plik z z danymi",
                DefaultExt = "csv",
                Filter = "Pliki csv (*.csv)|*.csv"
                
            };
            if(oDialog.ShowDialog() == DialogResult.OK)
            {
                if (RetrainNetwork(oDialog.FileName))
                {
                    MessageBox.Show("Uczenie sieci powiodło się");
                }
                else
                    MessageBox.Show("Uczenie sieci nie powiodło się");
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Change_Window(new MenuView());
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var wdialog = new SaveFileDialog()
            {
                Title = "Zapisz plik z wagami",
                DefaultExt = "h5",
                Filter = "Pliki h5 (*.h5)|*.h5"
            };
            var sdialog = new SaveFileDialog()
            {
                Title = "Zapisz plik ze strukturą",
                DefaultExt = "json",
                Filter = "Pliki json (*.json)|*.json"
            };
            if (wdialog.ShowDialog() == DialogResult.OK)
            {
                if (sdialog.ShowDialog() == DialogResult.OK)
                {
                    if(SaveNetwork(wdialog.FileName,sdialog.FileName))
                        MessageBox.Show("Zapisywanie powiodło się");
                    else
                        MessageBox.Show("Zapisywanie nie powiodło się");
                }
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            var wdialog = new OpenFileDialog()
            {
                Title = "Wczytaj plik z wagami",
                DefaultExt = "h5",
                Filter = "Pliki h5 (*.h5)|*.h5"
            };
            var sdialog = new OpenFileDialog()
            {
                Title = "Wczytaj plik ze strukturą",
                DefaultExt = "json",
                Filter = "Pliki json (*.json)|*.json"
            };
            if (wdialog.ShowDialog() == DialogResult.OK)
            {
                if (sdialog.ShowDialog() == DialogResult.OK)
                {
                    if (LoadNetwork(wdialog.FileName, sdialog.FileName))
                        MessageBox.Show("Wczytywanie powiodło się");
                    else
                        MessageBox.Show("Wczytywanie nie powiodło się");
                }
            }
        }

        private void buttonEncryptCSV_Click(object sender, EventArgs e)
        {
            var rdialog = new OpenFileDialog()
            {
                Title = "Wczytaj plik do szyfrowania",
                DefaultExt = "csv",
                Filter = "Pliki csv (*.csv)|*.csv"
            };
            var wdialog = new SaveFileDialog()
            {
                Title = "Zapisz zaszyfrowany plik",
                DefaultExt = "csv",
                Filter = "Pliki csv (*.csv)|*.csv"
            };
            if (rdialog.ShowDialog() == DialogResult.OK)
            {
                if (wdialog.ShowDialog() == DialogResult.OK)
                {
                    Utilities.RSAEncryption.EncryptCsvFile(rdialog.FileName, wdialog.FileName);
                }
            }
        }
    }
}
