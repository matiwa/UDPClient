using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace UDPClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BConnect_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string host = textBox1.Text;
            int port = (int)numericUpDown1.Value;
            try
            {
                UdpClient klient = new UdpClient(host, port);
                Byte[] dane = Encoding.ASCII.GetBytes(textBox2.Text);
                klient.Send(dane, dane.Length);
                listBox1.Items.Add("Send a message to the host " + host + ", on the port: " + port);
                klient.Close();
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Error: The message could not be sent!");
                MessageBox.Show(ex.ToString(), "Error");
            }
        }
    }
}
