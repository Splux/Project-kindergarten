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

        public void Initialize(string ipAddress)
        {
            _ipAddress = ipAddress;
            _splitChar = '/';
            _server = new TCPConnection(System.Net.IPAddress.Parse(ipAddress));
            _server.Send(UserInfo.PlayerName);

            int time = 0;
            string servername;
            do
            {
                _server.Receive(out servername);
                System.Threading.Thread.Sleep(10);
                time += 10;
            } while (servername == string.Empty && time <= 2000);
            if (servername != string.Empty)
                _serverName = servername;
            lbl_ipaddress.Text = _ipAddress;

            lbl_serverName.Text = _serverName;

            _rcvThread = null;

            string playersinlobby;
            _server.Receive(out playersinlobby);
            if (playersinlobby == string.Empty)
                this.Close();

            _playerNames = playersinlobby.Split(_splitChar);

            foreach (string name in _playerNames)
            {
                lb_users.Items.Add(name);
            }

            lb_users.Items.Add(UserInfo.PlayerName);

            _rcvThread = new System.Threading.Thread(ReceiveThread);
            _rcvThread.IsBackground = true;
            _rcvThread.Start();
        }

        private void ReceiveThread()
        {
            string inString;
            _server.Receive(out inString);

            if (inString != string.Empty)
            {
                if (inString[0] == 'x')
                {
                    inString.Remove(0, 1);
                    lb_users.Items.Remove(lb_users.FindString(inString));
                }
                else if (inString[0] == 'T')
                {

                }
            }
        }

        private System.Threading.Thread _rcvThread;
        private string _ipAddress;
        private string _serverName;
        private string[] _playerNames;
        private TCPConnection _server;
        private char _splitChar;
    }
}
