namespace Lottery.View
{
    partial class LotteryFrom
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInitialSimulate = new System.Windows.Forms.Button();
            this.btnUpdateData = new System.Windows.Forms.Button();
            this.cbxLotteryType = new System.Windows.Forms.ComboBox();
            this.btnAnalyzeDat = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxResult = new System.Windows.Forms.TextBox();
            this.cbxVariableOne = new System.Windows.Forms.ComboBox();
            this.cbxAnalyzeType = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxVariableEndValue = new System.Windows.Forms.ComboBox();
            this.tbxExpectShoot = new System.Windows.Forms.TextBox();
            this.btnCalculateExpectValue = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxExpectValueCount = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxVariableTwo = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInitialSimulate
            // 
            this.btnInitialSimulate.Location = new System.Drawing.Point(13, 13);
            this.btnInitialSimulate.Name = "btnInitialSimulate";
            this.btnInitialSimulate.Size = new System.Drawing.Size(101, 23);
            this.btnInitialSimulate.TabIndex = 0;
            this.btnInitialSimulate.Text = "Initial Simulate";
            this.btnInitialSimulate.UseVisualStyleBackColor = true;
            this.btnInitialSimulate.Click += new System.EventHandler(this.btnInitialSimulate_Click);
            // 
            // btnUpdateData
            // 
            this.btnUpdateData.Location = new System.Drawing.Point(13, 145);
            this.btnUpdateData.Name = "btnUpdateData";
            this.btnUpdateData.Size = new System.Drawing.Size(101, 23);
            this.btnUpdateData.TabIndex = 1;
            this.btnUpdateData.Text = "Update Data";
            this.btnUpdateData.UseVisualStyleBackColor = true;
            this.btnUpdateData.Click += new System.EventHandler(this.btnUpdateData_Click);
            // 
            // cbxLotteryType
            // 
            this.cbxLotteryType.FormattingEnabled = true;
            this.cbxLotteryType.Location = new System.Drawing.Point(13, 82);
            this.cbxLotteryType.Name = "cbxLotteryType";
            this.cbxLotteryType.Size = new System.Drawing.Size(101, 20);
            this.cbxLotteryType.TabIndex = 2;
            // 
            // btnAnalyzeDat
            // 
            this.btnAnalyzeDat.Location = new System.Drawing.Point(13, 145);
            this.btnAnalyzeDat.Name = "btnAnalyzeDat";
            this.btnAnalyzeDat.Size = new System.Drawing.Size(101, 23);
            this.btnAnalyzeDat.TabIndex = 3;
            this.btnAnalyzeDat.Text = "Analyze Data";
            this.btnAnalyzeDat.UseVisualStyleBackColor = true;
            this.btnAnalyzeDat.Click += new System.EventHandler(this.btnAnalyzeDat_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnInitialSimulate);
            this.panel1.Controls.Add(this.btnUpdateData);
            this.panel1.Controls.Add(this.cbxLotteryType);
            this.panel1.Location = new System.Drawing.Point(8, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(131, 184);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "Lottery Type";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Salmon;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cbxVariableTwo);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbxResult);
            this.panel2.Controls.Add(this.cbxVariableOne);
            this.panel2.Controls.Add(this.cbxAnalyzeType);
            this.panel2.Controls.Add(this.btnAnalyzeDat);
            this.panel2.Location = new System.Drawing.Point(169, 7);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(351, 184);
            this.panel2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "Analyze Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Period";
            // 
            // tbxResult
            // 
            this.tbxResult.AcceptsReturn = true;
            this.tbxResult.AcceptsTab = true;
            this.tbxResult.AllowDrop = true;
            this.tbxResult.Location = new System.Drawing.Point(133, 19);
            this.tbxResult.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxResult.Multiline = true;
            this.tbxResult.Name = "tbxResult";
            this.tbxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxResult.Size = new System.Drawing.Size(206, 150);
            this.tbxResult.TabIndex = 5;
            // 
            // cbxVariableOne
            // 
            this.cbxVariableOne.FormattingEnabled = true;
            this.cbxVariableOne.Location = new System.Drawing.Point(13, 75);
            this.cbxVariableOne.Name = "cbxVariableOne";
            this.cbxVariableOne.Size = new System.Drawing.Size(101, 20);
            this.cbxVariableOne.TabIndex = 4;
            // 
            // cbxAnalyzeType
            // 
            this.cbxAnalyzeType.FormattingEnabled = true;
            this.cbxAnalyzeType.Location = new System.Drawing.Point(13, 31);
            this.cbxAnalyzeType.Name = "cbxAnalyzeType";
            this.cbxAnalyzeType.Size = new System.Drawing.Size(101, 20);
            this.cbxAnalyzeType.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Moccasin;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cbxVariableEndValue);
            this.panel3.Controls.Add(this.tbxExpectShoot);
            this.panel3.Controls.Add(this.btnCalculateExpectValue);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cbxExpectValueCount);
            this.panel3.Location = new System.Drawing.Point(555, 7);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(351, 184);
            this.panel3.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 64);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "Max Period";
            // 
            // cbxVariableEndValue
            // 
            this.cbxVariableEndValue.FormattingEnabled = true;
            this.cbxVariableEndValue.Location = new System.Drawing.Point(13, 82);
            this.cbxVariableEndValue.Name = "cbxVariableEndValue";
            this.cbxVariableEndValue.Size = new System.Drawing.Size(101, 20);
            this.cbxVariableEndValue.TabIndex = 10;
            // 
            // tbxExpectShoot
            // 
            this.tbxExpectShoot.AcceptsReturn = true;
            this.tbxExpectShoot.AcceptsTab = true;
            this.tbxExpectShoot.AllowDrop = true;
            this.tbxExpectShoot.Location = new System.Drawing.Point(135, 19);
            this.tbxExpectShoot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxExpectShoot.Multiline = true;
            this.tbxExpectShoot.Name = "tbxExpectShoot";
            this.tbxExpectShoot.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxExpectShoot.Size = new System.Drawing.Size(206, 150);
            this.tbxExpectShoot.TabIndex = 10;
            // 
            // btnCalculateExpectValue
            // 
            this.btnCalculateExpectValue.Location = new System.Drawing.Point(13, 134);
            this.btnCalculateExpectValue.Name = "btnCalculateExpectValue";
            this.btnCalculateExpectValue.Size = new System.Drawing.Size(101, 34);
            this.btnCalculateExpectValue.TabIndex = 12;
            this.btnCalculateExpectValue.Text = "Calculate expect value";
            this.btnCalculateExpectValue.UseVisualStyleBackColor = true;
            this.btnCalculateExpectValue.Click += new System.EventHandler(this.btnCalculateExpectValue_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "Expect Value Iterate Count";
            // 
            // cbxExpectValueCount
            // 
            this.cbxExpectValueCount.FormattingEnabled = true;
            this.cbxExpectValueCount.Location = new System.Drawing.Point(13, 31);
            this.cbxExpectValueCount.Name = "cbxExpectValueCount";
            this.cbxExpectValueCount.Size = new System.Drawing.Size(101, 20);
            this.cbxExpectValueCount.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 101);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "Variable Two";
            // 
            // cbxVariableTwo
            // 
            this.cbxVariableTwo.FormattingEnabled = true;
            this.cbxVariableTwo.Location = new System.Drawing.Point(13, 119);
            this.cbxVariableTwo.Name = "cbxVariableTwo";
            this.cbxVariableTwo.Size = new System.Drawing.Size(101, 20);
            this.cbxVariableTwo.TabIndex = 10;
            // 
            // LotteryFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 206);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "LotteryFrom";
            this.Text = "Lottery Analyzer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInitialSimulate;
        private System.Windows.Forms.Button btnUpdateData;
        private System.Windows.Forms.ComboBox cbxLotteryType;
        private System.Windows.Forms.Button btnAnalyzeDat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbxAnalyzeType;
        private System.Windows.Forms.ComboBox cbxVariableOne;
        private System.Windows.Forms.TextBox tbxResult;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxExpectValueCount;
        private System.Windows.Forms.TextBox tbxExpectShoot;
        private System.Windows.Forms.Button btnCalculateExpectValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxVariableEndValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxVariableTwo;
    }
}

