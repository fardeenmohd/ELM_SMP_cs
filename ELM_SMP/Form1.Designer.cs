namespace ELM_SMP
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_CSV
            // 
            this.button_CSV.Location = new System.Drawing.Point(16, 41);
            this.button_CSV.Name = "button_CSV";
            this.button_CSV.Size = new System.Drawing.Size(300, 23);
            this.button_CSV.TabIndex = 0;
            this.button_CSV.Text = "Open File";
            this.button_CSV.UseVisualStyleBackColor = true;
            this.button_CSV.Click += new System.EventHandler(this.openCSV_btn_Click);
            // 
            // button_Train
            // 
            this.button_Train.Location = new System.Drawing.Point(16, 220);
            this.button_Train.Name = "button_Train";
            this.button_Train.Size = new System.Drawing.Size(300, 23);
            this.button_Train.TabIndex = 1;
            this.button_Train.Text = "Train";
            this.button_Train.UseVisualStyleBackColor = true;
            this.button_Train.Click += new System.EventHandler(this.button_Train_Click);
            // 
            // button_Predict
            // 
            this.button_Predict.Location = new System.Drawing.Point(16, 249);
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
            this.label1.Location = new System.Drawing.Point(13, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of Input Days:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number of Output Days:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Number of Hidden Layer Neurons:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Input Layer Bias Value:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Train Percentage";
            // 
            // input_InputDays
            // 
            this.input_InputDays.Location = new System.Drawing.Point(216, 70);
            this.input_InputDays.Name = "input_InputDays";
            this.input_InputDays.Size = new System.Drawing.Size(100, 20);
            this.input_InputDays.TabIndex = 8;
            // 
            // input_OutputDays
            // 
            this.input_OutputDays.Location = new System.Drawing.Point(216, 95);
            this.input_OutputDays.Name = "input_OutputDays";
            this.input_OutputDays.Size = new System.Drawing.Size(100, 20);
            this.input_OutputDays.TabIndex = 9;
            // 
            // input_HiddenLayerSize
            // 
            this.input_HiddenLayerSize.Location = new System.Drawing.Point(216, 118);
            this.input_HiddenLayerSize.Name = "input_HiddenLayerSize";
            this.input_HiddenLayerSize.Size = new System.Drawing.Size(100, 20);
            this.input_HiddenLayerSize.TabIndex = 10;
            // 
            // input_BiasValue
            // 
            this.input_BiasValue.Location = new System.Drawing.Point(216, 139);
            this.input_BiasValue.Name = "input_BiasValue";
            this.input_BiasValue.Size = new System.Drawing.Size(100, 20);
            this.input_BiasValue.TabIndex = 11;
            // 
            // input_TrainPercentage
            // 
            this.input_TrainPercentage.Location = new System.Drawing.Point(216, 162);
            this.input_TrainPercentage.Name = "input_TrainPercentage";
            this.input_TrainPercentage.Size = new System.Drawing.Size(100, 20);
            this.input_TrainPercentage.TabIndex = 12;
            // 
            // button_CreateElm
            // 
            this.button_CreateElm.Location = new System.Drawing.Point(16, 191);
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
            this.label6.Location = new System.Drawing.Point(8, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(258, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Stock Prediction Specifications";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 295);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 96);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(111, 329);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Fardin Mohammed";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(111, 354);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Mateusz Grossman";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(111, 378);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Filip Matracki";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 403);
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
            this.Name = "Form1";
            this.Text = "Stock Prediction ELM";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
    }
}

