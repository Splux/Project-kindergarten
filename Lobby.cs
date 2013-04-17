using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_kindergarten
{
    public partial class Lobby : Form
    {
        public Lobby()
        {
            InitializeComponent();
        }

        public Lobby(string ipAddress)
        {
            InitializeComponent();
            _ipAddress = ipAddress;
            _server = new TCPConnection(System.Net.IPAddress.Parse(ipAddress));
            int time = 0;
            string servername;
            do
            {
                _server.Receive(out servername);
                System.Threading.Thread.Sleep(10);
                time += 10;
            } while (servername != string.Empty && time <= 2000);
            if (servername != string.Empty)
                _serverName = servername;
            lbl_ipaddress.Text = _ipAddress;

            lbl_serverName.Text = _serverName;

            _rcvThread = null;
        }


        private System.Threading.Thread _rcvThread;
        private string _ipAddress;
        private string _serverName;
        private TCPConnection _server;
    }
}
