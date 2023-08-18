using Microsoft.VisualBasic;
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
        private void DataWriter(Control control, string value)//Hangi Konrtole hangi Metinsel veriyi yazdırmak istiyorsak buraya gönderdiğimizde yazan metod.
        {
            if (InvokeRequired)
            {
                Invoke(new Action<Control, string>(DataWriter), new object[] { control, value });
                return;
            }
            control.Text += value;
        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //string receivedData = serialPort.ReadExisting();
            string receivedDatam = serialPort.ReadLine();
            //Invoke(new Action(() => richTextBoxReceivedData.AppendText($"{say++} - " + receivedData)));

            char[] karakterler = receivedDatam.ToCharArray();
            this.Invoke((MethodInvoker)delegate
            {
                var date = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ":" + DateTime.Now.Millisecond;
                var hex = "";
                foreach (char c in karakterler)
                {
                    hex += String.Format("{0:X} ", Convert.ToInt32(c));
                }
                richTextBoxReceivedData.Text += hex + " " + Environment.NewLine;
                var hexDataYaz = hex + " - " + date;
                File.AppendAllText(@"C:\Users\ibrahim.benli\Desktop\test.txt", hexDataYaz + Environment.NewLine);
            });


            bool existing = receivedDatam.Contains("abcd");

            this.Invoke((MethodInvoker)delegate
            {
                if (existing)
                    MessageBox.Show($"{serialPortComboBox.Text} Aranan Değer bulundu!");
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
                //DataWriter(richTextBoxReceivedData, "\nOutMessage: " + textBoxSendData.Text);
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
    }
}