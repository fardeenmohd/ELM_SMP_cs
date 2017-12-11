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
                ELM elm = new ELM(30, 500, 1, data,80);
                elm.train(elm.Xtrain, elm.Ytrain);
                Matrix<double> prediction = elm.predict(elm.Xtest);
                // TODO prediction gives 6 colums we dont need column 0 and 5 , because they are time and volume, then we compute r^2 and draw graphs
                var pred = prediction.ToArray();
                var ytest = elm.Ytest.ToArray();

                for (int i = 0; i < 100; i++)
                    for (int j = 0; j < 6; j++)
                    {

                    }
                //DelimitedWriter.Write(@"H:\Windows7\Documents\prediction.csv", prediction, ",", System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                //DelimitedWriter.Write(@"H:\Windows7\Documents\Ytest.csv", elm.Ytest, ",");
            }
        }
    }
}
