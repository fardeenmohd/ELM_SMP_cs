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
    /// <summary>
    /// 
    /// </summary>
    public partial class MainWindow : Form
    {
        Matrix<double> data;
        ELM elm;
        Matrix<double> prediction;
        Matrix<double> test;
        int dataOffset;

        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
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
                    button_CreateElm.Enabled = true;
                }
                catch(Exception exception)
                {
                    MessageBox.Show("" + exception.ToString(), "Parsing Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_CreateElm_Click(object sender, EventArgs e)
        {
            int inputDays = Int32.Parse(input_InputDays.Text);
            int outputDays = Int32.Parse(input_OutputDays.Text);
            dataOffset = outputDays;
            int hiddenLayerSize = Int32.Parse(input_HiddenLayerSize.Text);
            int trainPercentage = Int32.Parse(input_TrainPercentage.Text);
            int biasValue = Int32.Parse(input_BiasValue.Text);

            if(data != null)
            {
                elm = new ELM(inputDays, hiddenLayerSize,outputDays, biasValue, data, trainPercentage);
                if(elm !=null)
                {
                    button_Train.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Please check your data", "ELM Creation Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Train_Click(object sender, EventArgs e)
        {
           
            if (elm != null)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                elm.train(elm.Xtrain, elm.Ytrain);
                watch.Stop();
                long trainingTime = watch.ElapsedMilliseconds;
                output_TrainingTime.Text = trainingTime.ToString()+" Ms";
                button_Predict.Enabled = true;
            }
               
            else
                MessageBox.Show("Cannot train, please check your ELM", "ELM Training Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Predict_Click(object sender, EventArgs e)
        {
            prediction = elm.predict(elm.Xtest);
            test = elm.Ytest;

            output_SampleCount.Text = (prediction.RowCount + 1).ToString();
            input_SelectedSample.Enabled = true;
            button_Plot.Enabled = true;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Plot_Click(object sender, EventArgs e)
        {

            int validSelectedSampleIndex = Int32.Parse(input_SelectedSample.Text) - 1;
            if(validSelectedSampleIndex <= Int32.Parse(output_SampleCount.Text) && validSelectedSampleIndex >= 0)
            {
                double[] selectedPredSample = prediction.Row(validSelectedSampleIndex).ToArray();
                double[] selectedTestSample = test.Row(validSelectedSampleIndex).ToArray();

                double[] predOpenPrice = new ArraySegment<double>(selectedPredSample, 0, dataOffset).ToArray();
                double[] predClosePrice = new ArraySegment<double>(selectedPredSample, dataOffset, dataOffset).ToArray();
                double[] predHighPrice = new ArraySegment<double>(selectedPredSample, 2*dataOffset, dataOffset).ToArray();
                double[] predLowPrice = new ArraySegment<double>(selectedPredSample, 3 * dataOffset, dataOffset).ToArray();

                double[] testOpenPrice = new ArraySegment<double>(selectedTestSample, 0, dataOffset).ToArray();
                double[] testClosePrice = new ArraySegment<double>(selectedTestSample, dataOffset, dataOffset).ToArray();
                double[] testHighPrice = new ArraySegment<double>(selectedTestSample, 2 * dataOffset, dataOffset).ToArray();
                double[] testLowPrice = new ArraySegment<double>(selectedTestSample, 3 * dataOffset, dataOffset).ToArray();

                chart_OpenPrice.Series.Clear();
                chart_OpenPrice.Series.Add("Predicted");
                chart_OpenPrice.Series["Predicted"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart_OpenPrice.Series["Predicted"].Points.DataBindY(predOpenPrice);
                chart_OpenPrice.Series.Add("Test");
                chart_OpenPrice.Series["Test"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart_OpenPrice.Series["Test"].Points.DataBindY(testOpenPrice);
                chart_OpenPrice.ChartAreas[0].AxisX.Interval = 1;
                chart_OpenPrice.ChartAreas[0].AxisY.Interval = 10;
                chart_OpenPrice.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                chart_OpenPrice.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                chart_OpenPrice.ChartAreas[0].AxisX.Title = "Days";
                chart_OpenPrice.ChartAreas[0].AxisY.Title = "Open Price";


                chart_ClosePrice.Series.Clear();
                chart_ClosePrice.Series.Add("Predicted");
                chart_ClosePrice.Series["Predicted"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart_ClosePrice.Series["Predicted"].Points.DataBindY(predClosePrice);
                chart_ClosePrice.Series.Add("Test");
                chart_ClosePrice.Series["Test"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart_ClosePrice.Series["Test"].Points.DataBindY(testClosePrice);
                chart_ClosePrice.ChartAreas[0].AxisX.Interval = 1;
                chart_ClosePrice.ChartAreas[0].AxisY.Interval = 10;
                chart_ClosePrice.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                chart_ClosePrice.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                chart_ClosePrice.ChartAreas[0].AxisX.Title = "Days";
                chart_ClosePrice.ChartAreas[0].AxisY.Title = "Close Price";

                chart_HighPrice.Series.Clear();
                chart_HighPrice.Series.Add("Predicted");
                chart_HighPrice.Series["Predicted"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart_HighPrice.Series["Predicted"].Points.DataBindY(predHighPrice);
                chart_HighPrice.Series.Add("Test");
                chart_HighPrice.Series["Test"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart_HighPrice.Series["Test"].Points.DataBindY(testHighPrice);
                chart_HighPrice.ChartAreas[0].AxisX.Interval = 1;
                chart_HighPrice.ChartAreas[0].AxisY.Interval = 10;
                chart_HighPrice.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                chart_HighPrice.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                chart_HighPrice.ChartAreas[0].AxisX.Title = "Days";
                chart_HighPrice.ChartAreas[0].AxisY.Title = "High Price";

                chart_LowPrice.Series.Clear();
                chart_LowPrice.Series.Add("Predicted");
                chart_LowPrice.Series["Predicted"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart_LowPrice.Series["Predicted"].Points.DataBindY(predLowPrice);
                chart_LowPrice.Series.Add("Test");
                chart_LowPrice.Series["Test"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart_LowPrice.Series["Test"].Points.DataBindY(testLowPrice);
                chart_LowPrice.ChartAreas[0].AxisX.Interval = 1;
                chart_LowPrice.ChartAreas[0].AxisY.Interval = 10;
                chart_LowPrice.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                chart_LowPrice.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                chart_LowPrice.ChartAreas[0].AxisX.Title = "Days";
                chart_LowPrice.ChartAreas[0].AxisY.Title = "Low Price";


            }
            else
            {
                MessageBox.Show("Please choose a valid sample number to plot", "Invalid Sample Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
