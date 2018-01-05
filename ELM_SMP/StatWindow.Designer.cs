namespace ELM_SMP
{
    partial class StatWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_LowPrice = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_HighPrice = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_ClosePrice = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_OpenPrice = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart_LowPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_HighPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_ClosePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_OpenPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_LowPrice
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_LowPrice.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_LowPrice.Legends.Add(legend1);
            this.chart_LowPrice.Location = new System.Drawing.Point(428, 326);
            this.chart_LowPrice.Name = "chart_LowPrice";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_LowPrice.Series.Add(series1);
            this.chart_LowPrice.Size = new System.Drawing.Size(400, 300);
            this.chart_LowPrice.TabIndex = 33;
            this.chart_LowPrice.Text = "Low Price Errors";
            this.chart_LowPrice.Customize += new System.EventHandler(this.chart_LowPrice_Customize);
            // 
            // chart_HighPrice
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_HighPrice.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_HighPrice.Legends.Add(legend2);
            this.chart_HighPrice.Location = new System.Drawing.Point(11, 326);
            this.chart_HighPrice.Name = "chart_HighPrice";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart_HighPrice.Series.Add(series2);
            this.chart_HighPrice.Size = new System.Drawing.Size(400, 300);
            this.chart_HighPrice.TabIndex = 32;
            this.chart_HighPrice.Text = "High Price Errors";
            this.chart_HighPrice.Customize += new System.EventHandler(this.chart_HighPrice_Customize);
            // 
            // chart_ClosePrice
            // 
            chartArea3.Name = "ChartArea1";
            this.chart_ClosePrice.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart_ClosePrice.Legends.Add(legend3);
            this.chart_ClosePrice.Location = new System.Drawing.Point(428, 8);
            this.chart_ClosePrice.Name = "chart_ClosePrice";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart_ClosePrice.Series.Add(series3);
            this.chart_ClosePrice.Size = new System.Drawing.Size(400, 300);
            this.chart_ClosePrice.TabIndex = 31;
            this.chart_ClosePrice.Text = "Close Price Errors";
            this.chart_ClosePrice.Customize += new System.EventHandler(this.chart_ClosePrice_Customize);
            // 
            // chart_OpenPrice
            // 
            chartArea4.Name = "ChartArea1";
            this.chart_OpenPrice.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart_OpenPrice.Legends.Add(legend4);
            this.chart_OpenPrice.Location = new System.Drawing.Point(11, 8);
            this.chart_OpenPrice.Name = "chart_OpenPrice";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart_OpenPrice.Series.Add(series4);
            this.chart_OpenPrice.Size = new System.Drawing.Size(400, 300);
            this.chart_OpenPrice.TabIndex = 30;
            this.chart_OpenPrice.Text = "Open Price Errors";
            this.chart_OpenPrice.Customize += new System.EventHandler(this.chart_OpenPrice_Customize);
            // 
            // StatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 641);
            this.Controls.Add(this.chart_LowPrice);
            this.Controls.Add(this.chart_HighPrice);
            this.Controls.Add(this.chart_ClosePrice);
            this.Controls.Add(this.chart_OpenPrice);
            this.Name = "StatWindow";
            this.Text = "StatWindow";
            ((System.ComponentModel.ISupportInitialize)(this.chart_LowPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_HighPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_ClosePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_OpenPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_LowPrice;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_HighPrice;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_ClosePrice;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_OpenPrice;
    }
}