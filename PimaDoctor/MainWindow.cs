﻿using PimaDoctor.Views;
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
using LinqToDB.Data;
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
