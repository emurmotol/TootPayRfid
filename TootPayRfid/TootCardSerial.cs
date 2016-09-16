using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TootPayRfid
{
    delegate void IncommingDelegate(string text);

    public partial class TootCardSerial : Form
    {
        IncommingDelegate incommingDelegate;
        int dataSize = 44;

        public TootCardSerial()
        {
            InitializeComponent();
            incommingDelegate = new IncommingDelegate(appendText);
        }

        void appendText(string text)
        {
            string _text = this.dataTextBox.Text + text;
            this.dataTextBox.Text = _text;
        }

        private void rfidSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort incomming = (SerialPort)sender;
            int incommingBytes = incomming.BytesToRead;

            char[] incommingBuffer = new char[incommingBytes];
            incomming.Read(incommingBuffer, 0, incommingBytes);

            String tempString = new String(incommingBuffer);
            this.BeginInvoke(incommingDelegate, tempString);
        }

        private void dataTextBox_TextChanged(object sender, EventArgs e)
        {
            string tag = (sender as TextBox).Text;

            if (tag.Length == dataSize)
            {
                String data = new String(tag.ToCharArray());

                logsRichTextBox.AppendText(string.Format("\n[{0}]: Formatting data...", timestamp()));
                string _data = data.TrimEnd();
                
                logsRichTextBox.AppendText(string.Format("\n[{0}]: Data received: {1}.", timestamp(), _data));
                logsRichTextBox.AppendText(string.Format("\n[{0}]: Data received index count: {1}.", timestamp(), _data.Length));

                logsRichTextBox.AppendText(string.Format("\n[{0}]: Getting serial from data...", timestamp()));
                string _tag = _data.Split(' ').Last().TrimEnd();

                logsRichTextBox.AppendText(string.Format("\n[{0}]: Serial: {1}.", timestamp(), _tag));
                logsRichTextBox.AppendText(string.Format("\n[{0}]: Serial index count: {1}.", timestamp(), _tag.Length));
                patchTagToServer(_tag);
            }
        }

        private void patchTagToServer(string tag)
        {
            try
            {
                logsRichTextBox.AppendText(string.Format("\n[{0}]: Patching serial to tootpay server...", timestamp()));
                MySqlConnection mySqlConnection = new MySqlConnection();
                mySqlConnection.ConnectionString = Properties.Resources.mySqlConnectionString;
                mySqlConnection.Open();

                MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlCommand.CommandText = "insert into serials(tag) values(@tag)";
                mySqlCommand.Parameters.AddWithValue("@tag", tag);

                if (mySqlCommand.ExecuteNonQuery() == 1)
                {
                    logsRichTextBox.AppendText(string.Format("\n[{0}]: Row inserted!", timestamp()));
                }
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                logsRichTextBox.AppendText(string.Format("\n[{0}]: Error! {1}", timestamp(), ex.Message));
            }
            finally
            {
                closePort();
                dataTextBox.ResetText();
                logsRichTextBox.AppendText(string.Format("\n[{0}]: Data cleared!", timestamp()));
                openPort(true);
            }
        }

        private string timestamp()
        {
            return DateTime.Now.ToString();
        }

        private void openPort(bool newLine)
        {
            try
            {
                if (!rfidSerialPort.IsOpen)
                {
                    rfidSerialPort.Open();

                    if (newLine)
                    {
                        logsRichTextBox.AppendText(string.Format("\n[{0}]: Port opened!", timestamp()));
                    }
                    else
                    {
                        logsRichTextBox.AppendText(string.Format("[{0}]: Port opened!", timestamp()));
                    }
                }
            }
            catch (Exception ex)
            {
                logsRichTextBox.AppendText(string.Format("\n[{0}]: Error! {1}", timestamp(), ex.Message));
            }
            logsRichTextBox.AppendText(string.Format("\n[{0}]: Listening on port {1}...", timestamp(), rfidSerialPort.PortName));
        }

        private void closePort()
        {
            try
            {
                if (rfidSerialPort.IsOpen)
                {
                    rfidSerialPort.Close();
                    logsRichTextBox.AppendText(string.Format("\n[{0}]: Port closed!", timestamp()));
                }
            }
            catch (Exception ex)
            {
                logsRichTextBox.AppendText(string.Format("\n[{0}]: Error! {1}", timestamp(), ex.Message));
            }
        }

        private void TootCardSerial_Load(object sender, EventArgs e)
        {
            openPort(false);
        }

        private void TootCardSerial_FormClosing(object sender, FormClosingEventArgs e)
        {
            closePort();
        }
    }
}
