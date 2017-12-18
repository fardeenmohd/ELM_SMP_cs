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
    /// Author: Fardin Mohammed
    /// Last Modified Date: 17.12.2017
    /// </summary>
    public partial class MainWindow : Form
    {
        Matrix<double> data;
        ELM elm;
        Matrix<double> prediction;
        Matrix<double> test;
        int dataOffset;

        /// <summary>
        /// Initializes the main form and puts initial values for the inputs
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
                    output_CompanyName.Text = ofile.FileName.Split('\\')[ofile.FileName.Split('\\').Length - 1].Split('.')[0];
                    button_CreateElm.Enabled = true;
                }
                catch(Exception exception)
                {
                    MessageBox.Show("" + exception.ToString(), "Parsing Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        /// <summary>
        /// Initializes an ELM network for given configurations
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
        /// Trains the model and stores the weights
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
        /// Runs the ELM network and stores the predictions
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
            button_PlotBestSample.Enabled = true;
            plot_at_index(getBestIndex());

        }

        /// <summary>
        /// Plots a selected sample
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Plot_Click(object sender, EventArgs e)
        {

            int validSelectedSampleIndex = Int32.Parse(input_SelectedSample.Text) - 1;
            if(validSelectedSampleIndex <= Int32.Parse(output_SampleCount.Text) && validSelectedSampleIndex >= 0)
            {

                plot_at_index(validSelectedSampleIndex);

            }
            else
            {
                MessageBox.Show("Please choose a valid sample number to plot", "Invalid Sample Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Back logic for plotting at an index value
        /// </summary>
        /// <param name="index"></param>
        public void plot_at_index(int index)
        {
            double[] selectedPredSample = prediction.Row(index).ToArray();
            double[] selectedTestSample = test.Row(index).ToArray();

            double[] predOpenPrice = new ArraySegment<double>(selectedPredSample, 0, dataOffset).ToArray();
            double[] predClosePrice = new ArraySegment<double>(selectedPredSample, dataOffset, dataOffset).ToArray();
            double[] predHighPrice = new ArraySegment<double>(selectedPredSample, 2 * dataOffset, dataOffset).ToArray();
            double[] predLowPrice = new ArraySegment<double>(selectedPredSample, 3 * dataOffset, dataOffset).ToArray();

            double[] testOpenPrice = new ArraySegment<double>(selectedTestSample, 0, dataOffset).ToArray();
            double[] testClosePrice = new ArraySegment<double>(selectedTestSample, dataOffset, dataOffset).ToArray();
            double[] testHighPrice = new ArraySegment<double>(selectedTestSample, 2 * dataOffset, dataOffset).ToArray();
            double[] testLowPrice = new ArraySegment<double>(selectedTestSample, 3 * dataOffset, dataOffset).ToArray();

            output_MSEOpen.Text = getMeanSquare(predOpenPrice, testOpenPrice).ToString();
            output_MSEClose.Text = getMeanSquare(predClosePrice, testClosePrice).ToString();
            output_MSEHigh.Text = getMeanSquare(predHighPrice, testHighPrice).ToString();
            output_MSELow.Text = getMeanSquare(predLowPrice, testLowPrice).ToString();

            input_SelectedSample.Text = (index + 1).ToString();

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

        /// <summary>
        /// Plots the best sample by finding the minimum distance between the two arrays
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_PlotBestSample_Click(object sender, EventArgs e)
        {

            plot_at_index(getBestIndex());
            
        }

        /// <summary>
        /// Gets the MSE between two arrays
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public double getMeanSquare(double[] arr1, double[] arr2)
        {
            double MSE = 0;

            for (int i = 0; i < arr1.Length; i++)
            {
                MSE += Math.Pow(arr1[i] - arr2[i], 2);
            }

            MSE = MSE / arr1.Length;

            return Math.Round(MSE,3);
        }

        /// <summary>
        /// Euclidean distance between two lines
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public double getDistanceBetweenLines(double[] arr1, double[] arr2)
        {
            double distance = 0;

            for(int i = 0; i< arr1.Length; i++)
            {
                distance += Math.Pow(arr1[i] - arr2[i],2);
            }

            distance = Math.Sqrt(distance);

            return distance;
        }

        public int getBestIndex()
        {
            double minimumDistance = double.MaxValue;
            int bestIndex = 0;
            for (int i = 0; i < prediction.RowCount; i++)
            {
                double[] selectedPredSample = prediction.Row(i).ToArray();
                double[] selectedTestSample = test.Row(i).ToArray();

                double distance = getDistanceBetweenLines(selectedPredSample, selectedTestSample);
                if (distance <= minimumDistance)
                {
                    minimumDistance = distance;
                    bestIndex = i;
                }
            }

            return bestIndex;
        }

        
    }
}
