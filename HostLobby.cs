using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Project_kindergarten
{
    public partial class HostLobby : Form
    {
        
        public HostLobby()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            System.Net.IPHostEntry hosts = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            string local_ip = string.Empty;
            foreach(System.Net.IPAddress ip in hosts.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    local_ip = ip.ToString();
            }

            _serverListener = new TcpListener(System.Net.IPAddress.Parse(local_ip), 1337);
            _serverListener.Start();

            _newConnectionThread = new System.Threading.Thread(AcceptClients);
            _newConnectionThread.IsBackground = true;
            _newConnectionThread.Start();
        }

        private void SendThread()
        {
            while(_running)
            {
                for(int i = 0; i < _connectedClients.Count; i++)
                {
                    if(_connectedClients[i].NewMessage)
                    {
                        string messageToSend = _connectedClients[i].ClientMessage;
                        for(int j = 0; j < _connectedClients.Count; j++)
                        {
                            if(j != i)
                            {
                                _connectedClients[i].Send(messageToSend);
                            }
                        }
                        _connectedClients[i].NewMessage = false;
                    }
                }
            }
        }

        private void AcceptClients()
        {
            _connectedClients = new List<Client>();
            while(_running)
            {
                if (!_serverListener.Pending())
                {
                    System.Threading.Thread.Sleep(100);
                    continue;
                }
                TcpClient client = _serverListener.AcceptTcpClient();
                Client newclient = new Client(client, _serverName);
                lock (_connectedClients)
                {
                    _connectedClients.Add(newclient);
                }
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            // TODO: make some code
        }

        private void HostLobby_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                cleanup();
        }

        private void cleanup()
        {
            _running = false;

            _serverListener.Stop();
        }

        #region Variables
        private string _ipAddress;
        private string _serverName;
        private TcpListener _serverListener;
        private System.Threading.Thread _newConnectionThread;
        private System.Threading.Thread _sendThread;
        private List<Client> _connectedClients;

        private volatile bool _running = true;
        #endregion

        
    }

    class Client
    {
        public Client()
        {
            _tcpClient = null;
            _rcvThread = null;
        }
        public Client(TcpClient client, string servername)
        {
            _tcpClient = client;
            System.IO.StreamWriter sw = new System.IO.StreamWriter(_tcpClient.GetStream());
            sw.WriteLine(servername);
            sw.Flush();
            _rcvThread = new System.Threading.Thread(receiveThread);
            _rcvThread.IsBackground = true;
            _rcvThread.Start();
        }
        ~Client()
        {
            Stop();
        }

        public void Stop()
        {
            _running = false;
            if(_tcpClient != null)
            {
                _tcpClient.Close();
                _tcpClient = null;
            }
            _rcvThread.Join();
        }

        public string ClientMessage
        {
            get { lock (_clientMessage) { return _clientMessage; } }
            set {}
        }
        public bool NewMessage
        {
            get { return _newMessage; }
            set { _newMessage = value; }
        }

        public void Send(string msg)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(_tcpClient.GetStream());
            sw.WriteLine(msg);
            sw.Flush();
        }

        private void handleReceivedData(string rcv)
        {
            lock (_clientMessage)
            {
                _clientMessage = rcv;
            }
        }

        private void receiveThread()
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(_tcpClient.GetStream());
            while (_running && _tcpClient.Connected)
            {
                string rcv = string.Empty;
                try
                {
                    rcv = reader.ReadLine();
                    handleReceivedData(rcv);
                }
                catch(Exception e)
                {
                    Log.Write(e.ToString());
                    return;
                }
            }
        }

        private TcpClient _tcpClient;
        private System.Threading.Thread _rcvThread;
        private string _clientMessage;
        private volatile bool _running = true;
        private volatile bool _newMessage = false;
    }
}
