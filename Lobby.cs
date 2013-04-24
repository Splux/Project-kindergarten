using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

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
                if (name == "")
                    break;
                lb_users.Items.Add(name);
            }

            lb_users.Items.Add(UserInfo.PlayerName);
            
            
            _connected = true;
            _rcvThread = new System.Threading.Thread(ReceiveThread);
            _rcvThread.IsBackground = true;
            _rcvThread.Start();

        }

        private void ReceiveThread()
        {
            

            while (_connected && _server.IsConnected())
            {
                while(!_server.Peek())
                {
                    System.Threading.Thread.Sleep(10);
                }
                string inString;
                _server.Receive(out inString);

                if (inString != string.Empty && inString != null)
                {
                    if (inString[0] == LobbyFlags.REMOVE_USER) //Player left, update list of players accordingly.
                    {
                        inString = inString.Remove(0, 1);
                        lb_users.Items.Remove(lb_users.FindString(inString));
                        lb_users.Update();
                    }
                    else if (inString[0] == LobbyFlags.ADD_USER) //Player joined, update list of players. 
                    {
                        inString = inString.Remove(0, 1);
                        lb_users.Items.Add(inString);
                        lb_users.Update();
                    }
                    else if (inString[0] == LobbyFlags.SERVER_STARTING)
                    {
                        _rcvThread.Abort();
                        closeThis();
                        IPEndPoint ServerEndPoint = new IPEndPoint(IPAddress.Parse(_ipAddress), 1337);
                        UdpClient GameServer = new UdpClient();
                        GameServer.Connect(ServerEndPoint);
                        //Start Game
                    }
                    else if (inString[0] == LobbyFlags.SERVER_STOP)
                    {
                        _rcvThread.Abort();
                        closeThis();
                        //Game closed
                    }
                    else if (inString[0] == LobbyFlags.CHAT_MESSAGE)
                    {
                        inString = inString.Remove(0, 1);
                        tb_Chat.AppendText(inString + "\n");
                    }
                }
            }
        }

        private System.Threading.Thread _rcvThread;
        private string _ipAddress;
        private string _serverName;
        private string[] _playerNames;
        private TCPConnection _server;
        private char _splitChar;
        private volatile bool _connected;

        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            _server.Send(LobbyFlags.REMOVE_USER.ToString());
            this.Dispose();
        }

        private void btn_ChatSend_Click(object sender, EventArgs e)
        {
            string ChatText = tb_WriteChat.Text;
            if (ChatText != string.Empty)
            {
                tb_WriteChat.Clear();
                tb_Chat.AppendText(UserInfo.PlayerName + ": " + ChatText + "\n");
                _server.Send(LobbyFlags.CHAT_MESSAGE.ToString() + UserInfo.PlayerName + ": " + ChatText);
            }
        }
    }
}
