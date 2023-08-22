namespace RS232Communication
{
    partial class RS_MainForm
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
            this.serialPortComboBox = new System.Windows.Forms.ComboBox();
            this.richTextBoxReceivedData = new System.Windows.Forms.RichTextBox();
            this.textBoxSendData = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClean = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBaudRate = new System.Windows.Forms.ComboBox();
            this.comboDataBit = new System.Windows.Forms.ComboBox();
            this.comboStopBit = new System.Windows.Forms.ComboBox();
            this.comboParity = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPortComboBox
            // 
            this.serialPortComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.serialPortComboBox.FormattingEnabled = true;
            this.serialPortComboBox.Location = new System.Drawing.Point(122, 29);
            this.serialPortComboBox.Name = "serialPortComboBox";
            this.serialPortComboBox.Size = new System.Drawing.Size(101, 32);
            this.serialPortComboBox.Sorted = true;
            this.serialPortComboBox.TabIndex = 0;
            this.serialPortComboBox.Text = "Bağlı Cihaz Yok";
            // 
            // richTextBoxReceivedData
            // 
            this.richTextBoxReceivedData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBoxReceivedData.Location = new System.Drawing.Point(8, 12);
            this.richTextBoxReceivedData.Name = "richTextBoxReceivedData";
            this.richTextBoxReceivedData.Size = new System.Drawing.Size(538, 426);
            this.richTextBoxReceivedData.TabIndex = 1;
            this.richTextBoxReceivedData.Text = "";
            // 
            // textBoxSendData
            // 
            this.textBoxSendData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxSendData.Location = new System.Drawing.Point(8, 444);
            this.textBoxSendData.Name = "textBoxSendData";
            this.textBoxSendData.Size = new System.Drawing.Size(538, 29);
            this.textBoxSendData.TabIndex = 2;
            this.textBoxSendData.Text = "Sending Write Message:";
            this.textBoxSendData.Click += new System.EventHandler(this.textBoxSendData_Click);
            this.textBoxSendData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSendData_KeyPress);
            // 
            // buttonClose
            // 
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonClose.Location = new System.Drawing.Point(16, 540);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(177, 55);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonOpen.Location = new System.Drawing.Point(11, 444);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(182, 55);
            this.buttonOpen.TabIndex = 5;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = false;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBoxReceivedData);
            this.panel1.Controls.Add(this.textBoxSendData);
            this.panel1.Controls.Add(this.btnClean);
            this.panel1.Controls.Add(this.buttonSend);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(224, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 622);
            this.panel1.TabIndex = 7;
            // 
            // btnClean
            // 
            this.btnClean.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClean.Location = new System.Drawing.Point(8, 540);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(538, 55);
            this.btnClean.TabIndex = 3;
            this.btnClean.Text = "Clean";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonSend.Location = new System.Drawing.Point(8, 479);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(538, 55);
            this.buttonSend.TabIndex = 3;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonOpen);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.buttonClose);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBaudRate);
            this.panel2.Controls.Add(this.comboDataBit);
            this.panel2.Controls.Add(this.comboStopBit);
            this.panel2.Controls.Add(this.comboParity);
            this.panel2.Controls.Add(this.serialPortComboBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(-5, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(229, 622);
            this.panel2.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(7, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Baud Rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(7, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Data Bit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(7, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Stop Bit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(7, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Parity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Com Port";
            // 
            // comboBaudRate
            // 
            this.comboBaudRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBaudRate.FormattingEnabled = true;
            this.comboBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "750",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "31250",
            "38400",
            "57600",
            "74880",
            "115200"});
            this.comboBaudRate.Location = new System.Drawing.Point(122, 252);
            this.comboBaudRate.Name = "comboBaudRate";
            this.comboBaudRate.Size = new System.Drawing.Size(101, 32);
            this.comboBaudRate.TabIndex = 0;
            this.comboBaudRate.Text = "2400";
            // 
            // comboDataBit
            // 
            this.comboDataBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboDataBit.FormattingEnabled = true;
            this.comboDataBit.Items.AddRange(new object[] {
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboDataBit.Location = new System.Drawing.Point(122, 197);
            this.comboDataBit.Name = "comboDataBit";
            this.comboDataBit.Size = new System.Drawing.Size(101, 32);
            this.comboDataBit.TabIndex = 0;
            this.comboDataBit.Text = "8";
            // 
            // comboStopBit
            // 
            this.comboStopBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboStopBit.FormattingEnabled = true;
            this.comboStopBit.Items.AddRange(new object[] {
            "One",
            "OnePointFive",
            "Two"});
            this.comboStopBit.Location = new System.Drawing.Point(122, 141);
            this.comboStopBit.Name = "comboStopBit";
            this.comboStopBit.Size = new System.Drawing.Size(101, 32);
            this.comboStopBit.TabIndex = 0;
            this.comboStopBit.Text = "One";
            // 
            // comboParity
            // 
            this.comboParity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboParity.FormattingEnabled = true;
            this.comboParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.comboParity.Location = new System.Drawing.Point(122, 85);
            this.comboParity.Name = "comboParity";
            this.comboParity.Size = new System.Drawing.Size(101, 32);
            this.comboParity.TabIndex = 0;
            this.comboParity.Text = "Mark";
            // 
            // RS_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 622);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "RS_MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RS-232";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox serialPortComboBox;
        private System.Windows.Forms.RichTextBox richTextBoxReceivedData;
        private System.Windows.Forms.TextBox textBoxSendData;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboStopBit;
        private System.Windows.Forms.ComboBox comboParity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboDataBit;
        private System.Windows.Forms.ComboBox comboBaudRate;
        private System.Windows.Forms.Button btnClean;
    }
}