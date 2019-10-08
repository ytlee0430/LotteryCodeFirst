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
            this.SuspendLayout();
            // 
            // btnInitialSimulate
            // 
            this.btnInitialSimulate.Location = new System.Drawing.Point(12, 12);
            this.btnInitialSimulate.Name = "btnInitialSimulate";
            this.btnInitialSimulate.Size = new System.Drawing.Size(101, 23);
            this.btnInitialSimulate.TabIndex = 0;
            this.btnInitialSimulate.Text = "Initial Simulate";
            this.btnInitialSimulate.UseVisualStyleBackColor = true;
            this.btnInitialSimulate.Visible = false;
            this.btnInitialSimulate.Click += new System.EventHandler(this.btnInitialSimulate_Click);
            // 
            // btnUpdateData
            // 
            this.btnUpdateData.Location = new System.Drawing.Point(12, 77);
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
            this.cbxLotteryType.Location = new System.Drawing.Point(12, 51);
            this.cbxLotteryType.Name = "cbxLotteryType";
            this.cbxLotteryType.Size = new System.Drawing.Size(101, 20);
            this.cbxLotteryType.TabIndex = 2;
            // 
            // LotteryFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbxLotteryType);
            this.Controls.Add(this.btnUpdateData);
            this.Controls.Add(this.btnInitialSimulate);
            this.Name = "LotteryFrom";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInitialSimulate;
        private System.Windows.Forms.Button btnUpdateData;
        private System.Windows.Forms.ComboBox cbxLotteryType;
    }
}

