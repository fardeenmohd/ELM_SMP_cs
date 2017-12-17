namespace ELM_SMP
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
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
            this.button_CSV = new System.Windows.Forms.Button();
            this.button_Train = new System.Windows.Forms.Button();
            this.button_Predict = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.input_InputDays = new System.Windows.Forms.TextBox();
            this.input_OutputDays = new System.Windows.Forms.TextBox();
            this.input_HiddenLayerSize = new System.Windows.Forms.TextBox();
            this.input_BiasValue = new System.Windows.Forms.TextBox();
            this.input_TrainPercentage = new System.Windows.Forms.TextBox();
            this.button_CreateElm = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.output_TrainingTime = new System.Windows.Forms.TextBox();
            this.output_SampleCount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.input_SelectedSample = new System.Windows.Forms.TextBox();
            this.button_Plot = new System.Windows.Forms.Button();
            this.chart_OpenPrice = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_ClosePrice = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_HighPrice = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_LowPrice = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_PlotBestSample = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_OpenPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_ClosePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_HighPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_LowPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // button_CSV
            // 
            this.button_CSV.Location = new System.Drawing.Point(12, 45);
            this.button_CSV.Name = "button_CSV";
            this.button_CSV.Size = new System.Drawing.Size(300, 23);
            this.button_CSV.TabIndex = 0;
            this.button_CSV.Text = "Open File";
            this.button_CSV.UseVisualStyleBackColor = true;
            this.button_CSV.Click += new System.EventHandler(this.openCSV_btn_Click);
            // 
            // button_Train
            // 
            this.button_Train.Enabled = false;
            this.button_Train.Location = new System.Drawing.Point(12, 224);
            this.button_Train.Name = "button_Train";
            this.button_Train.Size = new System.Drawing.Size(300, 23);
            this.button_Train.TabIndex = 1;
            this.button_Train.Text = "Train";
            this.button_Train.UseVisualStyleBackColor = true;
            this.button_Train.Click += new System.EventHandler(this.button_Train_Click);
            // 
            // button_Predict
            // 
            this.button_Predict.Enabled = false;
            this.button_Predict.Location = new System.Drawing.Point(12, 253);
            this.button_Predict.Name = "button_Predict";
            this.button_Predict.Size = new System.Drawing.Size(300, 23);
            this.button_Predict.TabIndex = 2;
            this.button_Predict.Text = "Predict";
            this.button_Predict.UseVisualStyleBackColor = true;
            this.button_Predict.Click += new System.EventHandler(this.button_Predict_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of Input Days:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number of Output Days:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Number of Hidden Layer Neurons:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Input Layer Bias Value:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Train Percentage";
            // 
            // input_InputDays
            // 
            this.input_InputDays.Location = new System.Drawing.Point(212, 74);
            this.input_InputDays.Name = "input_InputDays";
            this.input_InputDays.Size = new System.Drawing.Size(100, 20);
            this.input_InputDays.TabIndex = 8;
            // 
            // input_OutputDays
            // 
            this.input_OutputDays.Location = new System.Drawing.Point(212, 99);
            this.input_OutputDays.Name = "input_OutputDays";
            this.input_OutputDays.Size = new System.Drawing.Size(100, 20);
            this.input_OutputDays.TabIndex = 9;
            // 
            // input_HiddenLayerSize
            // 
            this.input_HiddenLayerSize.Location = new System.Drawing.Point(212, 122);
            this.input_HiddenLayerSize.Name = "input_HiddenLayerSize";
            this.input_HiddenLayerSize.Size = new System.Drawing.Size(100, 20);
            this.input_HiddenLayerSize.TabIndex = 10;
            // 
            // input_BiasValue
            // 
            this.input_BiasValue.Location = new System.Drawing.Point(212, 143);
            this.input_BiasValue.Name = "input_BiasValue";
            this.input_BiasValue.Size = new System.Drawing.Size(100, 20);
            this.input_BiasValue.TabIndex = 11;
            // 
            // input_TrainPercentage
            // 
            this.input_TrainPercentage.Location = new System.Drawing.Point(212, 166);
            this.input_TrainPercentage.Name = "input_TrainPercentage";
            this.input_TrainPercentage.Size = new System.Drawing.Size(100, 20);
            this.input_TrainPercentage.TabIndex = 12;
            // 
            // button_CreateElm
            // 
            this.button_CreateElm.Enabled = false;
            this.button_CreateElm.Location = new System.Drawing.Point(12, 195);
            this.button_CreateElm.Name = "button_CreateElm";
            this.button_CreateElm.Size = new System.Drawing.Size(300, 23);
            this.button_CreateElm.TabIndex = 13;
            this.button_CreateElm.Text = "Create ELM";
            this.button_CreateElm.UseVisualStyleBackColor = true;
            this.button_CreateElm.Click += new System.EventHandler(this.button_CreateElm_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(258, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Stock Prediction Specifications";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(117, 465);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 89);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(114, 564);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Fardin Mohammed";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(114, 577);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Mateusz Grossman";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(114, 590);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Filip Matracki";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 292);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Training Time:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 323);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Number of Samples:";
            // 
            // output_TrainingTime
            // 
            this.output_TrainingTime.Location = new System.Drawing.Point(117, 292);
            this.output_TrainingTime.Name = "output_TrainingTime";
            this.output_TrainingTime.ReadOnly = true;
            this.output_TrainingTime.Size = new System.Drawing.Size(100, 20);
            this.output_TrainingTime.TabIndex = 21;
            // 
            // output_SampleCount
            // 
            this.output_SampleCount.Location = new System.Drawing.Point(117, 320);
            this.output_SampleCount.Name = "output_SampleCount";
            this.output_SampleCount.ReadOnly = true;
            this.output_SampleCount.Size = new System.Drawing.Size(100, 20);
            this.output_SampleCount.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 350);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Sample to Plot:";
            // 
            // input_SelectedSample
            // 
            this.input_SelectedSample.Enabled = false;
            this.input_SelectedSample.Location = new System.Drawing.Point(117, 347);
            this.input_SelectedSample.Name = "input_SelectedSample";
            this.input_SelectedSample.Size = new System.Drawing.Size(100, 20);
            this.input_SelectedSample.TabIndex = 24;
            // 
            // button_Plot
            // 
            this.button_Plot.Enabled = false;
            this.button_Plot.Location = new System.Drawing.Point(12, 373);
            this.button_Plot.Name = "button_Plot";
            this.button_Plot.Size = new System.Drawing.Size(300, 23);
            this.button_Plot.TabIndex = 25;
            this.button_Plot.Text = "Plot Selected Sample";
            this.button_Plot.UseVisualStyleBackColor = true;
            this.button_Plot.Click += new System.EventHandler(this.button_Plot_Click);
            // 
            // chart_OpenPrice
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_OpenPrice.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_OpenPrice.Legends.Add(legend1);
            this.chart_OpenPrice.Location = new System.Drawing.Point(357, 32);
            this.chart_OpenPrice.Name = "chart_OpenPrice";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_OpenPrice.Series.Add(series1);
            this.chart_OpenPrice.Size = new System.Drawing.Size(400, 300);
            this.chart_OpenPrice.TabIndex = 26;
            this.chart_OpenPrice.Text = "Open Price Comparison";
            // 
            // chart_ClosePrice
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_ClosePrice.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_ClosePrice.Legends.Add(legend2);
            this.chart_ClosePrice.Location = new System.Drawing.Point(774, 32);
            this.chart_ClosePrice.Name = "chart_ClosePrice";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart_ClosePrice.Series.Add(series2);
            this.chart_ClosePrice.Size = new System.Drawing.Size(400, 300);
            this.chart_ClosePrice.TabIndex = 27;
            // 
            // chart_HighPrice
            // 
            chartArea3.Name = "ChartArea1";
            this.chart_HighPrice.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart_HighPrice.Legends.Add(legend3);
            this.chart_HighPrice.Location = new System.Drawing.Point(357, 350);
            this.chart_HighPrice.Name = "chart_HighPrice";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart_HighPrice.Series.Add(series3);
            this.chart_HighPrice.Size = new System.Drawing.Size(400, 300);
            this.chart_HighPrice.TabIndex = 28;
            // 
            // chart_LowPrice
            // 
            chartArea4.Name = "ChartArea1";
            this.chart_LowPrice.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart_LowPrice.Legends.Add(legend4);
            this.chart_LowPrice.Location = new System.Drawing.Point(774, 350);
            this.chart_LowPrice.Name = "chart_LowPrice";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart_LowPrice.Series.Add(series4);
            this.chart_LowPrice.Size = new System.Drawing.Size(400, 300);
            this.chart_LowPrice.TabIndex = 29;
            // 
            // button_PlotBestSample
            // 
            this.button_PlotBestSample.Enabled = false;
            this.button_PlotBestSample.Location = new System.Drawing.Point(12, 402);
            this.button_PlotBestSample.Name = "button_PlotBestSample";
            this.button_PlotBestSample.Size = new System.Drawing.Size(300, 23);
            this.button_PlotBestSample.TabIndex = 30;
            this.button_PlotBestSample.Text = "Plot Best Sample";
            this.button_PlotBestSample.UseVisualStyleBackColor = true;
            this.button_PlotBestSample.Click += new System.EventHandler(this.button_PlotBestSample_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 661);
            this.Controls.Add(this.button_PlotBestSample);
            this.Controls.Add(this.chart_LowPrice);
            this.Controls.Add(this.chart_HighPrice);
            this.Controls.Add(this.chart_ClosePrice);
            this.Controls.Add(this.chart_OpenPrice);
            this.Controls.Add(this.button_Plot);
            this.Controls.Add(this.input_SelectedSample);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.output_SampleCount);
            this.Controls.Add(this.output_TrainingTime);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_CreateElm);
            this.Controls.Add(this.input_TrainPercentage);
            this.Controls.Add(this.input_BiasValue);
            this.Controls.Add(this.input_HiddenLayerSize);
            this.Controls.Add(this.input_OutputDays);
            this.Controls.Add(this.input_InputDays);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Predict);
            this.Controls.Add(this.button_Train);
            this.Controls.Add(this.button_CSV);
            this.Name = "MainWindow";
            this.Text = "Stock Prediction ELM";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_OpenPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_ClosePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_HighPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_LowPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_CSV;
        private System.Windows.Forms.Button button_Train;
        private System.Windows.Forms.Button button_Predict;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox input_InputDays;
        private System.Windows.Forms.TextBox input_OutputDays;
        private System.Windows.Forms.TextBox input_HiddenLayerSize;
        private System.Windows.Forms.TextBox input_BiasValue;
        private System.Windows.Forms.TextBox input_TrainPercentage;
        private System.Windows.Forms.Button button_CreateElm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox output_TrainingTime;
        private System.Windows.Forms.TextBox output_SampleCount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox input_SelectedSample;
        private System.Windows.Forms.Button button_Plot;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_OpenPrice;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_ClosePrice;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_HighPrice;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_LowPrice;
        private System.Windows.Forms.Button button_PlotBestSample;
    }
}

