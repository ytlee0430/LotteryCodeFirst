﻿namespace Lottery.View
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
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxVariableTwo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxResult = new System.Windows.Forms.TextBox();
            this.cbxVariableOne = new System.Windows.Forms.ComboBox();
            this.cbxAnalyzeType = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbxShowBIngo = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxSelectCount = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxVariableEndValue = new System.Windows.Forms.ComboBox();
            this.tbxExpectShoot = new System.Windows.Forms.TextBox();
            this.btnCalculateExpectValue = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxExpectValueCount = new System.Windows.Forms.ComboBox();
            this.btnCalculateCost = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInitialSimulate
            // 
            this.btnInitialSimulate.Location = new System.Drawing.Point(20, 22);
            this.btnInitialSimulate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInitialSimulate.Name = "btnInitialSimulate";
            this.btnInitialSimulate.Size = new System.Drawing.Size(152, 38);
            this.btnInitialSimulate.TabIndex = 0;
            this.btnInitialSimulate.Text = "Initial Simulate";
            this.btnInitialSimulate.UseVisualStyleBackColor = true;
            this.btnInitialSimulate.Click += new System.EventHandler(this.btnInitialSimulate_Click);
            // 
            // btnUpdateData
            // 
            this.btnUpdateData.Location = new System.Drawing.Point(20, 242);
            this.btnUpdateData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdateData.Name = "btnUpdateData";
            this.btnUpdateData.Size = new System.Drawing.Size(152, 38);
            this.btnUpdateData.TabIndex = 1;
            this.btnUpdateData.Text = "Update Data";
            this.btnUpdateData.UseVisualStyleBackColor = true;
            this.btnUpdateData.Click += new System.EventHandler(this.btnUpdateData_Click);
            // 
            // cbxLotteryType
            // 
            this.cbxLotteryType.FormattingEnabled = true;
            this.cbxLotteryType.Location = new System.Drawing.Point(20, 137);
            this.cbxLotteryType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxLotteryType.Name = "cbxLotteryType";
            this.cbxLotteryType.Size = new System.Drawing.Size(150, 28);
            this.cbxLotteryType.TabIndex = 2;
            // 
            // btnAnalyzeDat
            // 
            this.btnAnalyzeDat.Location = new System.Drawing.Point(18, 262);
            this.btnAnalyzeDat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAnalyzeDat.Name = "btnAnalyzeDat";
            this.btnAnalyzeDat.Size = new System.Drawing.Size(152, 38);
            this.btnAnalyzeDat.TabIndex = 3;
            this.btnAnalyzeDat.Text = "Analyze Data";
            this.btnAnalyzeDat.UseVisualStyleBackColor = true;
            this.btnAnalyzeDat.Click += new System.EventHandler(this.btnAnalyzeDat_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnInitialSimulate);
            this.panel1.Controls.Add(this.btnUpdateData);
            this.panel1.Controls.Add(this.cbxLotteryType);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 475);
            this.panel1.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Simulate Answer:43-49";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
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
            this.panel2.Location = new System.Drawing.Point(254, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(526, 475);
            this.panel2.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Variable Two";
            // 
            // cbxVariableTwo
            // 
            this.cbxVariableTwo.FormattingEnabled = true;
            this.cbxVariableTwo.Location = new System.Drawing.Point(20, 198);
            this.cbxVariableTwo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxVariableTwo.Name = "cbxVariableTwo";
            this.cbxVariableTwo.Size = new System.Drawing.Size(150, 28);
            this.cbxVariableTwo.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Analyze Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Period";
            // 
            // tbxResult
            // 
            this.tbxResult.AcceptsReturn = true;
            this.tbxResult.AcceptsTab = true;
            this.tbxResult.AllowDrop = true;
            this.tbxResult.Location = new System.Drawing.Point(206, 15);
            this.tbxResult.Multiline = true;
            this.tbxResult.Name = "tbxResult";
            this.tbxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxResult.Size = new System.Drawing.Size(307, 447);
            this.tbxResult.TabIndex = 5;
            // 
            // cbxVariableOne
            // 
            this.cbxVariableOne.FormattingEnabled = true;
            this.cbxVariableOne.Location = new System.Drawing.Point(20, 125);
            this.cbxVariableOne.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxVariableOne.Name = "cbxVariableOne";
            this.cbxVariableOne.Size = new System.Drawing.Size(150, 28);
            this.cbxVariableOne.TabIndex = 4;
            // 
            // cbxAnalyzeType
            // 
            this.cbxAnalyzeType.FormattingEnabled = true;
            this.cbxAnalyzeType.Location = new System.Drawing.Point(20, 52);
            this.cbxAnalyzeType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxAnalyzeType.Name = "cbxAnalyzeType";
            this.cbxAnalyzeType.Size = new System.Drawing.Size(150, 28);
            this.cbxAnalyzeType.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Moccasin;
            this.panel3.Controls.Add(this.btnCalculateCost);
            this.panel3.Controls.Add(this.cbxShowBIngo);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.cbxSelectCount);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cbxVariableEndValue);
            this.panel3.Controls.Add(this.tbxExpectShoot);
            this.panel3.Controls.Add(this.btnCalculateExpectValue);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cbxExpectValueCount);
            this.panel3.Location = new System.Drawing.Point(832, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(536, 475);
            this.panel3.TabIndex = 6;
            // 
            // cbxShowBIngo
            // 
            this.cbxShowBIngo.AutoSize = true;
            this.cbxShowBIngo.Location = new System.Drawing.Point(24, 292);
            this.cbxShowBIngo.Name = "cbxShowBIngo";
            this.cbxShowBIngo.Size = new System.Drawing.Size(120, 24);
            this.cbxShowBIngo.TabIndex = 15;
            this.cbxShowBIngo.Text = "Show Bingo";
            this.cbxShowBIngo.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Seelct Count";
            // 
            // cbxSelectCount
            // 
            this.cbxSelectCount.FormattingEnabled = true;
            this.cbxSelectCount.Location = new System.Drawing.Point(20, 228);
            this.cbxSelectCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxSelectCount.Name = "cbxSelectCount";
            this.cbxSelectCount.Size = new System.Drawing.Size(150, 28);
            this.cbxSelectCount.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Max Period";
            // 
            // cbxVariableEndValue
            // 
            this.cbxVariableEndValue.FormattingEnabled = true;
            this.cbxVariableEndValue.Location = new System.Drawing.Point(20, 137);
            this.cbxVariableEndValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxVariableEndValue.Name = "cbxVariableEndValue";
            this.cbxVariableEndValue.Size = new System.Drawing.Size(150, 28);
            this.cbxVariableEndValue.TabIndex = 10;
            // 
            // tbxExpectShoot
            // 
            this.tbxExpectShoot.AcceptsReturn = true;
            this.tbxExpectShoot.AcceptsTab = true;
            this.tbxExpectShoot.AllowDrop = true;
            this.tbxExpectShoot.Location = new System.Drawing.Point(216, 14);
            this.tbxExpectShoot.Multiline = true;
            this.tbxExpectShoot.Name = "tbxExpectShoot";
            this.tbxExpectShoot.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxExpectShoot.Size = new System.Drawing.Size(307, 447);
            this.tbxExpectShoot.TabIndex = 10;
            // 
            // btnCalculateExpectValue
            // 
            this.btnCalculateExpectValue.Location = new System.Drawing.Point(20, 338);
            this.btnCalculateExpectValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCalculateExpectValue.Name = "btnCalculateExpectValue";
            this.btnCalculateExpectValue.Size = new System.Drawing.Size(152, 57);
            this.btnCalculateExpectValue.TabIndex = 12;
            this.btnCalculateExpectValue.Text = "Calculate expect value";
            this.btnCalculateExpectValue.UseVisualStyleBackColor = true;
            this.btnCalculateExpectValue.Click += new System.EventHandler(this.btnCalculateExpectValue_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Expect Value Iterate Count";
            // 
            // cbxExpectValueCount
            // 
            this.cbxExpectValueCount.FormattingEnabled = true;
            this.cbxExpectValueCount.Location = new System.Drawing.Point(20, 52);
            this.cbxExpectValueCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxExpectValueCount.Name = "cbxExpectValueCount";
            this.cbxExpectValueCount.Size = new System.Drawing.Size(150, 28);
            this.cbxExpectValueCount.TabIndex = 10;
            // 
            // btnCalculateCost
            // 
            this.btnCalculateCost.Location = new System.Drawing.Point(20, 423);
            this.btnCalculateCost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCalculateCost.Name = "btnCalculateCost";
            this.btnCalculateCost.Size = new System.Drawing.Size(152, 38);
            this.btnCalculateCost.TabIndex = 9;
            this.btnCalculateCost.Text = "Calculate Cost";
            this.btnCalculateCost.UseVisualStyleBackColor = true;
            this.btnCalculateCost.Click += new System.EventHandler(this.btnCalculateCost_Click);
            // 
            // LotteryFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1403, 512);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxSelectCount;
        private System.Windows.Forms.CheckBox cbxShowBIngo;
        private System.Windows.Forms.Button btnCalculateCost;
    }
}

