namespace LoopSend
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.intervalTime = new System.Windows.Forms.TextBox();
            this.sendTime = new System.Windows.Forms.TextBox();
            this.sendData = new System.Windows.Forms.TextBox();
            this.selectBoard = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SendLog = new System.Windows.Forms.RichTextBox();
            this.ReceiveLog = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.disableLog = new System.Windows.Forms.CheckBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // intervalTime
            // 
            this.intervalTime.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.intervalTime.Location = new System.Drawing.Point(130, 145);
            this.intervalTime.Name = "intervalTime";
            this.intervalTime.Size = new System.Drawing.Size(116, 29);
            this.intervalTime.TabIndex = 0;
            // 
            // sendTime
            // 
            this.sendTime.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.sendTime.Location = new System.Drawing.Point(130, 189);
            this.sendTime.Name = "sendTime";
            this.sendTime.Size = new System.Drawing.Size(116, 29);
            this.sendTime.TabIndex = 1;
            // 
            // sendData
            // 
            this.sendData.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.sendData.Location = new System.Drawing.Point(130, 240);
            this.sendData.Name = "sendData";
            this.sendData.Size = new System.Drawing.Size(116, 29);
            this.sendData.TabIndex = 2;
            this.sendData.Text = "ABCDEF";
            // 
            // selectBoard
            // 
            this.selectBoard.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.selectBoard.FormattingEnabled = true;
            this.selectBoard.Location = new System.Drawing.Point(96, 96);
            this.selectBoard.Name = "selectBoard";
            this.selectBoard.Size = new System.Drawing.Size(150, 24);
            this.selectBoard.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(19, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "開發版";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(19, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "間隔時間(ms)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label3.Location = new System.Drawing.Point(19, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "傳送次數";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label4.Location = new System.Drawing.Point(19, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "傳送資料";
            // 
            // SendLog
            // 
            this.SendLog.Location = new System.Drawing.Point(26, 21);
            this.SendLog.Name = "SendLog";
            this.SendLog.Size = new System.Drawing.Size(350, 160);
            this.SendLog.TabIndex = 8;
            this.SendLog.Text = "";
            this.SendLog.TextChanged += new System.EventHandler(this.SendLog_TextChanged);
            // 
            // ReceiveLog
            // 
            this.ReceiveLog.Location = new System.Drawing.Point(26, 24);
            this.ReceiveLog.Name = "ReceiveLog";
            this.ReceiveLog.Size = new System.Drawing.Size(350, 160);
            this.ReceiveLog.TabIndex = 9;
            this.ReceiveLog.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.disableLog);
            this.groupBox1.Controls.Add(this.SendButton);
            this.groupBox1.Controls.Add(this.selectBoard);
            this.groupBox1.Controls.Add(this.intervalTime);
            this.groupBox1.Controls.Add(this.sendTime);
            this.groupBox1.Controls.Add(this.sendData);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 405);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "參數設定";
            // 
            // disableLog
            // 
            this.disableLog.AutoSize = true;
            this.disableLog.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.disableLog.Location = new System.Drawing.Point(23, 336);
            this.disableLog.Name = "disableLog";
            this.disableLog.Size = new System.Drawing.Size(120, 24);
            this.disableLog.TabIndex = 9;
            this.disableLog.Text = "關閉部分Log";
            this.disableLog.UseVisualStyleBackColor = true;
            // 
            // SendButton
            // 
            this.SendButton.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.SendButton.Location = new System.Drawing.Point(149, 336);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(97, 28);
            this.SendButton.TabIndex = 8;
            this.SendButton.Text = "執行";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SendLog);
            this.groupBox2.Location = new System.Drawing.Point(290, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 200);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Send";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ReceiveLog);
            this.groupBox3.Location = new System.Drawing.Point(290, 217);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(400, 200);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Receive";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 431);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "LoopSend";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox intervalTime;
        private System.Windows.Forms.TextBox sendTime;
        private System.Windows.Forms.TextBox sendData;
        private System.Windows.Forms.ComboBox selectBoard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox SendLog;
        private System.Windows.Forms.RichTextBox ReceiveLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox disableLog;
    }
}

