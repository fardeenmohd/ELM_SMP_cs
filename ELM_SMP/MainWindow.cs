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
using System.Windows.Forms.DataVisualization.Charting;

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

            input_InputDays.Text = "20";
            input_OutputDays.Text = "10";
            input_HiddenLayerSize.Text = "50";
            input_BiasValue.Text = "1";
            input_TrainPercentage.Text = "50";

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenCSVButtonClick(object sender, EventArgs e)
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
                    test_InputDays.Enabled = true;
                    test_OutputDays.Enabled = true;
                    test_HiddenLayerSize.Enabled = true;
                    test_TrainPercentage.Enabled = true;
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
        private void CreateELMButtonClick(object sender, EventArgs e)
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
        private void TrainButtonClick(object sender, EventArgs e)
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
        private void PredictButtonClick(object sender, EventArgs e)
        {
            prediction = elm.predict(elm.Xtest);
            test = elm.Ytest;

            output_SampleCount.Text = (prediction.RowCount + 1).ToString();
            input_SelectedSample.Enabled = true;
            button_Plot.Enabled = true;
            button_PlotBestSample.Enabled = true;
            PlotAtIndex(GetBestIndex(prediction,test));

        }

        /// <summary>
        /// Plots a selected sample
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlotButtonCLick(object sender, EventArgs e)
        {

            int validSelectedSampleIndex = Int32.Parse(input_SelectedSample.Text) - 1;
            if(validSelectedSampleIndex <= Int32.Parse(output_SampleCount.Text) && validSelectedSampleIndex >= 0)
            {

                PlotAtIndex(validSelectedSampleIndex);

            }
            else
            {
                MessageBox.Show("Please choose a valid sample number to plot", "Invalid Sample Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="predPrice"></param>
        /// <param name="testPrice"></param>
        /// <param name="type"></param>
        public void setupChart(Chart chart, double[] predPrice, double[] testPrice, string type)
        {
            chart.Visible = true;
            chart.Series.Clear();
            chart.Series.Add("Predicted");
            chart.Series["Predicted"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart.Series["Predicted"].Points.DataBindY(predPrice);
            chart.Series.Add("Test");
            chart.Series["Test"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart.Series["Test"].Points.DataBindY(testPrice);
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chart.ChartAreas[0].AxisX.Title = "Days";
            chart.ChartAreas[0].AxisY.Title = type;
        }

        /// <summary>
        /// Back logic for plotting at an index value
        /// </summary>
        /// <param name="index"></param>
        public void PlotAtIndex(int index)
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

            output_MSEOpen.Text = GetMeanSquare(predOpenPrice, testOpenPrice).ToString();
            output_MSEClose.Text = GetMeanSquare(predClosePrice, testClosePrice).ToString();
            output_MSEHigh.Text = GetMeanSquare(predHighPrice, testHighPrice).ToString();
            output_MSELow.Text = GetMeanSquare(predLowPrice, testLowPrice).ToString();

            input_SelectedSample.Text = (index + 1).ToString();

            setupChart(chart_OpenPrice, predOpenPrice, testOpenPrice, "Open Price");

            setupChart(chart_ClosePrice, predClosePrice, testClosePrice, "Close Price");

            setupChart(chart_HighPrice, predHighPrice, testHighPrice, "High Price");

            setupChart(chart_LowPrice, predLowPrice, testLowPrice, "Low Price");

        }

        /// <summary>
        /// Plots the best sample by finding the minimum distance between the two arrays
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlotBestSampleClick(object sender, EventArgs e)
        {

            PlotAtIndex(GetBestIndex(prediction, test));
            
        }

        /// <summary>
        /// Gets the MSE between two arrays
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public double GetMeanSquare(double[] arr1, double[] arr2)
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
        public double GetDistanceBetweenLines(double[] arr1, double[] arr2)
        {
            double distance = 0;

            for(int i = 0; i< arr1.Length; i++)
            {
                distance += Math.Pow(arr1[i] - arr2[i],2);
            }

            distance = Math.Sqrt(distance);

            return distance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prediction"></param>
        /// <param name="test"></param>
        /// <returns></returns>
        public int GetBestIndex(Matrix<double> prediction, Matrix<double> test)
        {
            double minimumDistance = double.MaxValue;
            int bestIndex = 0;
            for (int i = 0; i < prediction.RowCount; i++)
            {
                double[] selectedPredSample = prediction.Row(i).ToArray();
                double[] selectedTestSample = test.Row(i).ToArray();

                double distance = GetDistanceBetweenLines(selectedPredSample, selectedTestSample);
                if (distance <= minimumDistance)
                {
                    minimumDistance = distance;
                    bestIndex = i;
                }
            }

            return bestIndex;
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="testOffset"></param>
        private void ShowStats(String type, int testOffset)
        {
            int inputDays = Int32.Parse(input_InputDays.Text);
            int outputDays = Int32.Parse(input_OutputDays.Text);
            int hiddenLayerSize = Int32.Parse(input_HiddenLayerSize.Text);
            int trainPercentage = Int32.Parse(input_TrainPercentage.Text);
            int biasValue = Int32.Parse(input_BiasValue.Text);
            dataOffset = outputDays;
            double[] openPriceArray = new double[testOffset];
            double[] closePriceArray = new double[testOffset];
            double[] highPriceArray = new double[testOffset]; ;
            double[] lowPriceArray = new double[testOffset];
            double[] offsetArray = new double[testOffset];
            

            for (int i = 1; i <= 10; i++)
            {
                ELM tempELM = new ELM(inputDays, hiddenLayerSize, outputDays, biasValue, data, trainPercentage);
                switch (type)
                {
                    case "Input Days" :
                        tempELM = new ELM(i * testOffset, hiddenLayerSize, outputDays, biasValue, data, trainPercentage);
                        break;
                    case "Output Days":
                        tempELM = new ELM(inputDays, hiddenLayerSize, i * testOffset, biasValue, data, trainPercentage);
                        break;
                    case "Hidden Layer Size":
                        tempELM = new ELM(inputDays, i * testOffset, outputDays, biasValue, data, trainPercentage);
                        break;
                    case "Train Percentage":
                        tempELM = new ELM(inputDays, hiddenLayerSize, outputDays, biasValue, data, i * testOffset);
                        break;

                }
                
                tempELM.train(tempELM.Xtrain, tempELM.Ytrain);
                Matrix<double> tempPrediction = tempELM.predict(tempELM.Xtest);
                Matrix<double> tempTest = tempELM.Ytest;
                int tempBestIndex = GetBestIndex(tempPrediction, tempTest);
                double[] selectedPredSample = tempPrediction.Row(tempBestIndex).ToArray();
                double[] selectedTestSample = tempTest.Row(tempBestIndex).ToArray();

                double[] predOpenPrice = new ArraySegment<double>(selectedPredSample, 0, dataOffset).ToArray();
                double[] predClosePrice = new ArraySegment<double>(selectedPredSample, dataOffset, dataOffset).ToArray();
                double[] predHighPrice = new ArraySegment<double>(selectedPredSample, 2 * dataOffset, dataOffset).ToArray();
                double[] predLowPrice = new ArraySegment<double>(selectedPredSample, 3 * dataOffset, dataOffset).ToArray();

                double[] testOpenPrice = new ArraySegment<double>(selectedTestSample, 0, dataOffset).ToArray();
                double[] testClosePrice = new ArraySegment<double>(selectedTestSample, dataOffset, dataOffset).ToArray();
                double[] testHighPrice = new ArraySegment<double>(selectedTestSample, 2 * dataOffset, dataOffset).ToArray();
                double[] testLowPrice = new ArraySegment<double>(selectedTestSample, 3 * dataOffset, dataOffset).ToArray();

                double tempOpenPriceError = GetMeanSquare(predOpenPrice, testOpenPrice);
                double tempClosePriceError = GetMeanSquare(predClosePrice, testClosePrice);
                double tempHighPriceError = GetMeanSquare(predHighPrice, testHighPrice);
                double tempLowPriceError = GetMeanSquare(predLowPrice, testLowPrice);

                offsetArray[i - 1] = i * testOffset;
                openPriceArray[i - 1] = tempOpenPriceError;
                closePriceArray[i - 1] = tempClosePriceError;
                highPriceArray[i - 1] = tempHighPriceError;
                lowPriceArray[i - 1] = tempLowPriceError;


            }
            StatWindow inputStatWindow = new StatWindow(openPriceArray, closePriceArray, highPriceArray, lowPriceArray, offsetArray, type);
            inputStatWindow.Show();

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestInputButtonClick(object sender, EventArgs e)
        {
            ShowStats("Input Days", 10);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestOutputButtonClick(object sender, EventArgs e)
        {
            ShowStats("Output Days" , 10);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestHiddenLayerSizeClick(object sender, EventArgs e)
        {
            ShowStats("Hidden Layer Size", 100);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestTrainPercentageClick(object sender, EventArgs e)
        {
            ShowStats("Train Percentage", 10);
        }
    }
}
