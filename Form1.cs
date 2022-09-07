using System;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;

namespace rangefinder
{
    public partial class Form1 : Form
    {
        private SerialPort port_ = null;
        private StringBuilder comReply = new StringBuilder(0x20);

        public Form1()
        {
            InitializeComponent();
        }

        private void SendCommand(object sender, EventArgs e)
        {
            if (port_ == null)
                return;

            Button btn = (Button)sender;
            if (port_.IsOpen)
            {
                byte[] command = { 0x1, 0x3, 0x0, 0xF, 0x0, 0x2, 0xF4, 0x8 };

                try
                {
                    port_.Write(command, 0, 8);

                    btn.Enabled = false;
                    btnLockTimer.Start();
                }
                catch
                {
                    MessageBox.Show("COM Device disconnected");
                    port_.Close();
                    port_ = null;
                }
            }
        }

        private void ClearOutput(object sender, EventArgs e)
        {
            outputList.Items.Clear();
        }

        private void RefreshCOMs(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            comboBox.Items.Clear();

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
                comboBox.Items.Add(port);

            outputList.Items.Insert(0, " -<- COM Ports Refreshed ->- ");
        }

        private void ConnectToCOM(object sender, EventArgs e)
        {
            if (port_ != null && port_.IsOpen)
            {
                port_.Close();
                port_ = null;
            }

            ComboBox comboBox = (ComboBox)sender;
            port_ = new SerialPort(comboBox.SelectedItem.ToString(), 9600, Parity.None, 8, StopBits.One);
            port_.DataReceived += new SerialDataReceivedEventHandler(DataRecieved);

            try
            {
                port_.Open();

                comSelector.Enabled = false;
                selectorLockTimer.Start();
            }
            catch
            {
                MessageBox.Show("COM Device busy");
                return;
            }
        }

        private void DataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialPort = (SerialPort)sender;
            
            comReply.Append(serialPort.ReadExisting());

            if (comReply.Length < 9)
                return;

            byte[] data = Encoding.ASCII.GetBytes(comReply.ToString());

            if (data[0] != 0x1) 
                return;

            if (data[1] == 0x3 && data[2] == 0x4)
            {
                string hex_view = "";
                foreach (byte b in data)
                    hex_view += String.Format("0x{0:X2} ", b);

                int value = 0;

                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(data); 
                    value = BitConverter.ToInt32(data, 2);
                }
                else 
                    value = BitConverter.ToInt32(data, 3);

                DateTime time = DateTime.Now;
                string result = String.Format("{2:D2}:{3:D2}:{4:D2} - {0}мм [ {1}]", value, hex_view, time.Hour, time.Minute, time.Second);

                outputList.Invoke((MethodInvoker)delegate
                {
                    outputList.Items.Insert(0, result);
                });
            }
            comReply.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;

            timer.Enabled = false;

            measureBtn.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;

            timer.Enabled = false;

            comSelector.Enabled = true;
            measureBtn.Enabled = true;

            measureBtn.Focus();
        }
    }
}
