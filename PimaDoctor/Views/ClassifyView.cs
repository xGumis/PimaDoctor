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
    public partial class ClassifyView : AbstractChangingWindow, IClassifyView
    {

        public ClassifyView()
        {
            InitializeComponent();
            viewModel = new ClassifyViewModel(this);
        }
        private ClassifyViewModel viewModel;
        public Func<int, int, int, int, int, double, double, int, bool> ClassifyData { get; set; }

        private void buttonClassify_Click(object sender, EventArgs e)
        {
            var pregnancies = Decimal.ToInt32(numericUpDownPregnancies.Value);
            var glucose = Decimal.ToInt32(numericUpDownGlucose.Value);
            var pressure = Decimal.ToInt32(numericUpDownPressure.Value);
            var thickness = Decimal.ToInt32(numericUpDownThickness.Value);
            var insuline = Decimal.ToInt32(numericUpDownInsulin.Value);
            var bmi = Decimal.ToDouble(numericUpDownBMI.Value);
            var dpf = Decimal.ToDouble(numericUpDownDPF.Value);
            var age = Decimal.ToInt32(numericUpDownAge.Value);
            var res = ClassifyData(pregnancies, glucose, pressure, thickness, insuline, bmi, dpf, age);
            labelResultBool.Text = res.ToString();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Change_Window(new MenuView());
        }
    }
}
