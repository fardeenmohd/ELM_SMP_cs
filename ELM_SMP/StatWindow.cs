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
    /// Last Modified Date: 07.01.2018
    /// </summary>
    public partial class StatWindow : Form
    {

        private double[] xAxis;

        /// <summary>
        /// Constructor for the statistics window
        /// </summary>
        /// <param name="openPriceErrors"></param>
        /// <param name="closePriceErrors"></param>
        /// <param name="highPriceErrors"></param>
        /// <param name="lowPriceErrors"></param>
        /// <param name="xAxis"></param>
        /// <param name="type"></param>
        public StatWindow(double[] openPriceErrors, double[] closePriceErrors, double[] highPriceErrors, double[] lowPriceErrors, double[] xAxis, string type)
        {
            InitializeComponent();
            this.xAxis = xAxis;
            this.Text = type + " Statistics";
            setUpChart(chart_OpenPrice, openPriceErrors, type, "Open Price Error");
            setUpChart(chart_ClosePrice, closePriceErrors, type, "Close Price Error");
            setUpChart(chart_HighPrice, highPriceErrors, type, "High Price Error");
            setUpChart(chart_LowPrice, lowPriceErrors, type, "Low Price Error");
        }


        /// <summary>
        /// Puts custom labels for the Xaxis on the charts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chart_OpenPrice_Customize(object sender, EventArgs e)
        {
            setCustomXaxis(chart_OpenPrice, xAxis);
        }

        /// <summary>
        /// Puts custom labels for the Xaxis on the charts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chart_ClosePrice_Customize(object sender, EventArgs e)
        {
            setCustomXaxis(chart_ClosePrice, xAxis);
        }

        /// <summary>
        /// Puts custom labels for the Xaxis on the charts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chart_HighPrice_Customize(object sender, EventArgs e)
        {
            setCustomXaxis(chart_HighPrice, xAxis);
        }

        /// <summary>
        /// Puts custom labels for the Xaxis on the charts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chart_LowPrice_Customize(object sender, EventArgs e)
        {
            setCustomXaxis(chart_LowPrice, xAxis);
        }


        /// <summary>
        /// Helper function to initialize charts
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="data"></param>
        /// <param name="type"></param>
        private void setUpChart(Chart chart, double[] data, string type, string name)
        {
            chart.Series.Clear();
            chart.Series.Add("Error");
            chart.Series["Error"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart.Series["Error"].Points.DataBindY(data);
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.Minimum = 1;
            chart.ChartAreas[0].AxisX.Maximum = 9;
            chart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chart.ChartAreas[0].AxisX.Title = type;
            chart.ChartAreas[0].AxisY.Title = name;
        }

        /// <summary>
        /// Helper function to use an array for the x axis labels
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="xAxis"></param>
        private void setCustomXaxis(Chart chart, double[] xAxis)
        {
            int count = 0;
            foreach (CustomLabel label in chart.ChartAreas[0].AxisX.CustomLabels)
            {

                label.Text = xAxis[count].ToString();
                count++;


            }
        }

    }
}
