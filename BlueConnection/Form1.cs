using System;
using System.Windows.Forms;
using DarrenLee.Bluetooth;

namespace BlueConnection
{
    public partial class Form1 : Form
    {
        Bluetooth_Server blueServer = new Bluetooth_Server();
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "Not doing anything";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "wait";
            blueServer.Start();
            blueServer.IsConnected += BlueServer_IsConnected;
            blueServer.DataReceived += BlueServer_DataReceived;
        }
        private void BlueServer_IsConnected(object sender, EventArgs e)
        {
            MessageBox.Show("Connection estabiled!");
            if (InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    textBox1.Text = "connected";
                }));
            }
        }
        private void BlueServer_DataReceived(object sender, BluetoothServerEventArgs e)
        {
            if(InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    richTextBox1.AppendText(e.Message);
                }));
            }
        }

    }
}
