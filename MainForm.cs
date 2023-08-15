using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace RS232Communication
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
        int say = 0;
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            //SeriPorttan Dizi gelecek ve gelen dizi değerleri içerisinde eğer belirlenen 4 değer varsa kalan 7 adetle birlikte 11 değeri de alacağız da alacağız.

            //string receivedData = serialPort.ReadExisting();
            string receivedDatam = serialPort.ReadLine();
            //Invoke(new Action(() => richTextBoxReceivedData.AppendText($"{say++} - " + receivedData)));

            char[] karakterler = receivedDatam.ToCharArray();

            for (int i = 0; i < karakterler.Length; i++)
            {
                listBox1.Text += karakterler;
            }
            this.Invoke((MethodInvoker)delegate
            {
                DataWriter(richTextBoxReceivedData, receivedDatam);
            });

            bool existing = receivedDatam.Contains("abcd");

            if (existing)
                MessageBox.Show("Aranan Değer bulundu!");
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
                        serialPort.BaudRate = int.Parse(comboBaudRate.Text); // Set your desired baud rate
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
                DataWriter(richTextBoxReceivedData, "Outgoing Message: " + textBoxSendData.Text + "\n");
            }
        }

        private void txtBaudRate_Click(object sender, EventArgs e)
        {
            comboDataBit.Text = string.Empty;
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

/*
 * 
 ToCharArray => stringiniz charlarına ayırarak size char dizisi olarak teslim eder.
            ornekMetin = txtGirisAlani.Text;
            char[] karakterler = ornekMetin.ToCharArray();

 Split => Metninizi özel bir karakterden birden fazla parçaya ayırmanıza olanak sağlayan metottur. Aynı anda birden fazla özel karakterde verebilirsiniz.
            string mailAdresleri = txtGirisAlani.Text;
            string[] adresler = mailAdresleri.Split(';', ',');
            foreach (string item in adresler)
            {
                MessageBox.Show(item);
            }

 Substring => 1.Kullanım => Metninizden, parametrede gönderdiğiniz indexten başlayarak, geri kalan kısmını çekip almanıza olanak ağlar.
        Substring => 2.Kullanım => Metninizden, ilk parametrede gönderdiğiniz indexten başlayarak, ikinci parametrede verdiğiniz eğer  kadarlık kısmını çekip almanıza olanak sağlar.
        ornekMetin = txtGirisAlani.Text;
        1.Kullanım
        string ornekBir = ornekMetin.Substring(0,4);
        MessageBox.Show(ornekBir);
        2.Kullanım
        string ornekIki = ornekMetin.Substring(3, 2);
        MessageBox.Show(ornekIki);
 
*/