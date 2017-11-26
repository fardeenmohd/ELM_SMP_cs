using MathNet.Numerics.Data.Text;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ELM_SMP
{
    public partial class Form1 : Form
    {
        Matrix<double> data;
        public Form1()
        {
            InitializeComponent();
        }

        private void openCSV_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "CSV Files (*.csv)|*.csv";
            if (DialogResult.OK == ofile.ShowDialog())
            {
                data = DelimitedReader.Read<double>(ofile.FileName, false, ",", true, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                ELM elm = new ELM(15, 500, 1, data);
            }
        }
    }
}
