using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace RS232CommunicationExample
{
    public partial class MainForm : Form
    {
        private SerialPort serialPort;

        public MainForm()
        {
            InitializeComponent();

            // Populate the ComboBox with available serial ports
            string[] availablePorts = SerialPort.GetPortNames();
            serialPortComboBox.Items.AddRange(availablePorts);
            serialPortComboBox.Text = availablePorts[0];
            serialPort = new SerialPort();
            serialPort.DataReceived += SerialPort_DataReceived;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            buttonClose.Enabled = false;
            buttonOpen.Enabled = true;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string receivedData = serialPort.ReadExisting();
            Invoke(new Action(() => richTextBoxReceivedData.AppendText(receivedData)));
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                serialPort.PortName = serialPortComboBox.SelectedItem.ToString();
                buttonClose.Enabled = true;
                if (txtBaudRate.Text == "DESİRED BAUD RATE :" || txtBaudRate.Text == "")
                {
                    MessageBox.Show("Lütfen bir sayısal Baud Değeri Giriniz","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    serialPort.BaudRate = int.Parse(txtBaudRate.Text); // Set your desired baud rate
                    serialPort.Open();
                    buttonOpen.Enabled = false;
                    buttonClose.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message} Com Erişimi Reddetti, Hata!, {MessageBoxButtons.OK}, {MessageBoxIcon.Error}");
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
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine(textBoxSendData.Text);
            }
        }


        private void txtBaudRate_Click(object sender, EventArgs e)
        {
            txtBaudRate.Text = string.Empty;
        }

        private void textBoxSendData_Click(object sender, EventArgs e)
        {
            textBoxSendData.Text = string.Empty;
        }
    }
}
