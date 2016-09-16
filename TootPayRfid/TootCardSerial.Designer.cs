namespace TootPayRfid
{
    partial class TootCardSerial
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
            this.components = new System.ComponentModel.Container();
            this.rfidSerialPort = new System.IO.Ports.SerialPort(this.components);
            this.dataLabel = new System.Windows.Forms.Label();
            this.dataTextBox = new System.Windows.Forms.TextBox();
            this.logsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rfidSerialPort
            // 
            this.rfidSerialPort.PortName = "COM4";
            this.rfidSerialPort.RtsEnable = true;
            this.rfidSerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.rfidSerialPort_DataReceived);
            // 
            // dataLabel
            // 
            this.dataLabel.AutoSize = true;
            this.dataLabel.Location = new System.Drawing.Point(15, 15);
            this.dataLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.Size = new System.Drawing.Size(63, 25);
            this.dataLabel.TabIndex = 0;
            this.dataLabel.Text = "Data:";
            // 
            // dataTextBox
            // 
            this.dataTextBox.Location = new System.Drawing.Point(87, 12);
            this.dataTextBox.Name = "dataTextBox";
            this.dataTextBox.ReadOnly = true;
            this.dataTextBox.Size = new System.Drawing.Size(561, 31);
            this.dataTextBox.TabIndex = 1;
            this.dataTextBox.TextChanged += new System.EventHandler(this.dataTextBox_TextChanged);
            // 
            // logsRichTextBox
            // 
            this.logsRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logsRichTextBox.Location = new System.Drawing.Point(12, 49);
            this.logsRichTextBox.Name = "logsRichTextBox";
            this.logsRichTextBox.ReadOnly = true;
            this.logsRichTextBox.Size = new System.Drawing.Size(636, 347);
            this.logsRichTextBox.TabIndex = 2;
            this.logsRichTextBox.Text = "";
            // 
            // TootCardSerial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 408);
            this.Controls.Add(this.logsRichTextBox);
            this.Controls.Add(this.dataTextBox);
            this.Controls.Add(this.dataLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "TootCardSerial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Toot Card Scan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TootCardSerial_FormClosing);
            this.Load += new System.EventHandler(this.TootCardSerial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort rfidSerialPort;
        private System.Windows.Forms.Label dataLabel;
        private System.Windows.Forms.TextBox dataTextBox;
        private System.Windows.Forms.RichTextBox logsRichTextBox;
    }
}

