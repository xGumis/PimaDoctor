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
using PimaDoctor.Neural;

namespace PimaDoctor
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            ChangeWindow(new LoginView());
            Network.InitNetwork();
            Network.LoadNetwork();
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
