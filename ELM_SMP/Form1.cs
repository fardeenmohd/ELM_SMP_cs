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
        ELM elm;
        
        public Form1()
        {
            InitializeComponent();

            input_InputDays.Text = "30";
            input_OutputDays.Text = "10";
            input_HiddenLayerSize.Text = "100";
            input_BiasValue.Text = "1";
            input_TrainPercentage.Text = "80";

        }

        private void openCSV_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "CSV Files (*.csv)|*.csv";
            if (DialogResult.OK == ofile.ShowDialog())
            {
                try
                {
                    data = DelimitedReader.Read<double>(ofile.FileName, false, ",", true, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

                }
                catch(Exception exception)
                {
                    MessageBox.Show("" + exception.ToString(), "Parsing Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void button_CreateElm_Click(object sender, EventArgs e)
        {
            int inputDays = Int32.Parse(input_InputDays.Text);
            int outputDays = Int32.Parse(input_OutputDays.Text);
            int hiddenLayerSize = Int32.Parse(input_HiddenLayerSize.Text);
            int trainPercentage = Int32.Parse(input_TrainPercentage.Text);
            int biasValue = Int32.Parse(input_BiasValue.Text);

            if(data != null)
            {
                elm = new ELM(inputDays, hiddenLayerSize,outputDays, biasValue, data, trainPercentage);

            }
            else
            {
                MessageBox.Show("Please check your data", "ELM Creation Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void button_Train_Click(object sender, EventArgs e)
        {
            if(elm != null )
                elm.train(elm.Xtrain, elm.Ytrain);
            else
                MessageBox.Show("Cannot train, please check your ELM", "ELM Training Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_Predict_Click(object sender, EventArgs e)
        {
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
