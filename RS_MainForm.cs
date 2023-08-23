using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace RS232Communication
{
    public partial class RS_MainForm : Form
    {
        private SerialPort serialPort;
        public RS_MainForm()
        {
            InitializeComponent();

            string[] availablePorts = SerialPort.GetPortNames();
            serialPortComboBox.Items.AddRange(availablePorts);
            if (availablePorts.Length <= 0) return;
            serialPortComboBox.Text = availablePorts[0];
            serialPort = new SerialPort();
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), comboParity.Text);
            serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), comboStopBit.Text); ;
            serialPort.DataBits = Convert.ToInt32(comboDataBit.Text);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            buttonClose.Enabled = false;
            buttonOpen.Enabled = true;
            buttonSend.Enabled = false;
        }

        private void textBoxSendData_TextChanged(object sender, EventArgs e)
        {
            textBoxSendData.TextChanged -= textBoxSendData_TextChanged;

            string textWithoutSeparators = textBoxSendData.Text.Replace("-", "");

            string newText = InsertSeparators(textWithoutSeparators, 2, "-");

            textBoxSendData.Text = newText;

            textBoxSendData.SelectionStart = textWithoutSeparators.Length + (textWithoutSeparators.Length / 2);

            textBoxSendData.TextChanged += textBoxSendData_TextChanged;
        }

        private string InsertSeparators(string input, int interval, string separator)
        {
            if (input.Length >= 22)
                MessageBox.Show("En çok 11 karakter");
            for (int i = interval; i < input.Length; i += interval + separator.Length)
            {
                input = input.Insert(i, separator);
            }
            return input;
        }


        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string receivedDatam = serialPort.ReadLine();

            bool existing = receivedDatam.Replace("-", " ").Trim().Contains("06 07 81");
            bool NoExisting = receivedDatam.Replace("-", " ").Trim().Contains("06 07 81 01");
            var cont = receivedDatam[27].ToString()+ receivedDatam[28].ToString();

            this.Invoke((MethodInvoker)delegate
            {
                if (existing == true && NoExisting == false && cont != "01")
                {
                    var date = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ":" + DateTime.Now.Millisecond;
                    var hexDataYaz = receivedDatam + " - " + date;
                    File.AppendAllText(@"C:\Users\ibrahim.benli\Desktop\RS323Test.txt", hexDataYaz + Environment.NewLine);

                    richTextBoxReceivedData.Text += receivedDatam + " " + Environment.NewLine;
                }
            });
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (serialPort == null)
            {
                MessageBox.Show("Bağlanacak Cihaz Bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!serialPort.IsOpen)
            {
                serialPort.PortName = serialPortComboBox.SelectedItem.ToString();
                try
                {
                    if (Convert.ToInt32(comboDataBit.Text).GetType() == typeof(string) || comboDataBit.Text == "")
                    {
                        MessageBox.Show("Lütfen bir sayısal Baud Değeri Giriniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        serialPort.BaudRate = int.Parse(comboBaudRate.Text); //Set your desired baud rate
                        serialPort.Open();
                        buttonOpen.Enabled = false;
                        buttonClose.Enabled = true;
                        buttonSend.Enabled = true;
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message} Com Erişimi Reddetti!");
                    return;
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                buttonOpen.Enabled = true;
                buttonClose.Enabled = false;
                buttonSend.Enabled = false;
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine(textBoxSendData.Text);
            }
        }
        private void textBoxSendData_Click(object sender, EventArgs e)
        {
            textBoxSendData.Text = string.Empty;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            richTextBoxReceivedData.Text = string.Empty;
        }

        private void textBoxSendData_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Backspace ve hexadecimal characters (0-9, A-F) izin verme durumu
            if (!char.IsControl(e.KeyChar) && !Uri.IsHexDigit(e.KeyChar))
            {
                e.Handled = true; //hexdecimal değilse tuşa basamasın
            }
        }
    }
}