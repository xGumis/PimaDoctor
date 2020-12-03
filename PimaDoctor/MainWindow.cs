using PimaDoctor.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using LinqToDB.Tools;
using PimaDoctor.Models;
using PimaDoctor.Neural;

namespace PimaDoctor
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            ChangeWindow(new LoginView());
            Network.TrainNetwork();
            /*
             * TODO: remove, example of usage
             */
            // Network.TrainNetwork();
            // Network.LoadModel();
            // Diabetes test = new Diabetes();
            // test.Pregnancies = 6;
            // test.Glucose = 148;
            // test.BloodPressure = 72;
            // test.SkinThickness = 35;
            // test.Insulin = 0;
            // test.BMI = 33.6;
            // test.DiabetesPedigreeFunction = 0.627;
            // test.Age = 50;
            // var prediction = Network.Predict(test);
            // MessageBox.Show(prediction.ToString());
        }
        private void ChangeWindow(AbstractChangingWindow window)
        {
            this.Controls.Clear();
            window.Change_Window += ChangeWindow;
            window.Dock = DockStyle.Fill;
            this.Controls.Add(window);
        }
    }
}
