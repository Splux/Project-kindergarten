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
        
        public HostLobby(string servername)
        {
            InitializeComponent();
            Initialize(servername);
        }
        ~HostLobby()
        {
            cleanup();
        }

        private void Initialize(string servername)
        {
            System.Net.IPHostEntry hosts = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            string local_ip = string.Empty;
            foreach(System.Net.IPAddress ip in hosts.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    local_ip = ip.ToString();
            }

            _connectedClients = new List<Client>();

            lbl_ipaddress.Text = local_ip;
            lbl_serverName.Text = servername;

            lb_Users.Items.Add(UserInfo.PlayerName);

            _serverName = servername;

            _serverListener = new TcpListener(System.Net.IPAddress.Parse(local_ip), 1337);
            _serverListener.Start();

            _newConnectionThread = new System.Threading.Thread(AcceptClients);
            _newConnectionThread.IsBackground = true;
            _newConnectionThread.Start();

            _sendThread = new System.Threading.Thread(BroadcastThread);
            _sendThread.IsBackground = true;
            _sendThread.Start();
        }

        private void addUserToListbox(string user)
        {
            if(lb_Users.InvokeRequired)
            {
                lb_Users.BeginInvoke(new Action(delegate() { lb_Users.Items.Add(user); }));
                return;
            }
            lb_Users.Items.Add(user);
        }

        private void removeUserFromListbox(int id)
        {
            if(lb_Users.InvokeRequired)
            {
                lb_Users.BeginInvoke(new Action(delegate() { lb_Users.Items.RemoveAt(id); }));
                return;
            }
            lb_Users.Items.RemoveAt(id);
        }

        private void removeUser(int user)
        {
            lock (_connectedClients)
            {
                _connectedClients[user - 1].Stop();
                _connectedClients.RemoveAt(user - 1);
            }
            removeUserFromListbox(user);
        }

        private void BroadcastThread()
        {
            while(_running)
            {
                if(_newClient)
                {
                    _newClient = false;
                    lock(lb_Users)
                    {
                        addUserToListbox(_strClient);
                        _strClient = "";
                    }
                }
                for(int i = 0; i < _connectedClients.Count; i++)
                {
                    // Check for new incoming messages
                    if(_connectedClients[i].NewMessage)
                    {
                        string messageToSend = _connectedClients[i].ClientMessage;
                        _connectedClients[i].ClientMessage = "";
                        _connectedClients[i].NewMessage = false;

                        // check if someone is exiting
                        if (messageToSend[0] == LobbyFlags.REMOVE_USER)
                        {
                            removeUser(i + 1);
                            break;
                        }
                        

                        for(int j = 0; j < _connectedClients.Count; j++)
                        {
                            if(j != i)
                            {
                                _connectedClients[i].Send(messageToSend);
                            }
                        }
                        if (messageToSend[0] == LobbyFlags.CHAT_MESSAGE)
                        {
                            string str = messageToSend.Remove(0, 1);
                            tb_ChatReceived.Text += str + Environment.NewLine;
                        }
                        _connectedClients[i].NewMessage = false;
                    }
                }
            }
        }

        private void AcceptClients()
        {
            //_connectedClients = new List<Client>();
            while(_running)
            {
                if (!_serverListener.Pending())
                {
                    System.Threading.Thread.Sleep(100);
                    continue;
                }
                TcpClient client = _serverListener.AcceptTcpClient();
                string playerlist = "";
                System.Net.IPEndPoint ipep = (System.Net.IPEndPoint)client.Client.RemoteEndPoint;
                System.Net.IPAddress ipad = ipep.Address;
                
                // 
                foreach (string str in lb_Users.Items)
                {
                    if (str == "")
                        break;
                    if (str == "\n")
                        continue;
                    playerlist += str;
                    playerlist += "/";
                }
                System.IO.StreamReader sr = new System.IO.StreamReader(client.GetStream());

                // Wait for client to send us something
                while (sr.Peek() < 0)
                {
                    System.Threading.Thread.Sleep(10);
                }
                // Receive
                string clientname = sr.ReadLine();
                //HostLobby.lb_Users.Items.Add(clientname);
                //lb_Users.Items.Add(clientname);
                Client newclient = new Client(client, _serverName, playerlist);

                _strClient = clientname;
                _newClient = true;

                lock (_connectedClients)
                {
                    _connectedClients.Add(newclient);
                }
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            // TODO: make some code

            foreach(Client c in _connectedClients)
            {
                c.Send(LobbyFlags.GAME_STARTING.ToString());
            }

            Game game = new Game();
            game.InitializeGame();
            this.Hide();
            game.ShowDialog();
        }

        private void HostLobby_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                cleanup();
        }

        private void cleanup()
        {
            _sendThread.Abort();
            _newConnectionThread.Abort();

            _serverListener.Stop();

            UserInfo.TcpClient.Send(Flags.HOST_REQUEST);

            this.Close();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            foreach (Client cl in _connectedClients)
            {
                cl.Send(LobbyFlags.SERVER_STOP.ToString());
            }
            cleanup();
        }

        #region Variables
        private string _ipAddress;
        private string _serverName;
        private TcpListener _serverListener;
        private System.Threading.Thread _newConnectionThread;
        private System.Threading.Thread _sendThread;
        private List<Client> _connectedClients;

        private volatile bool _running = true;
        private volatile bool _newClient = false;
        private volatile string _strClient = "";
        #endregion

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                tb_ChatReceived.Text +=  UserInfo.PlayerName + ": " + tb_ChatMessage.Text + Environment.NewLine;
                foreach(Client c in _connectedClients)
                {
                    
                    c.Send(LobbyFlags.CHAT_MESSAGE + UserInfo.PlayerName + ": " + tb_ChatMessage.Text);
                    
                }
                tb_ChatMessage.Clear();
            }
        }

        //private void OnClose(object sender, FormClosingEventArgs e)
        //{
        //    cleanup();
        //}

        
    }

    class Client
    {
        public Client()
        {
            _tcpClient = null;
            _rcvThread = null;
        }

        public NetworkStream ClientStream
        {
            get { return _tcpClient.GetStream(); }
            set { }
        }

        public Client(TcpClient client, string servername, string playerlist)
        {
            _tcpClient = new TCPConnection(client);
            // peek and then readline
            
            _tcpClient.Send(servername);
            _tcpClient.Send(playerlist);
            

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
            _rcvThread.Abort();
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
            _tcpClient.Send(msg);
        }

        private void handleReceivedData(string rcv)
        {
            lock (_clientMessage)
            {
                _clientMessage = rcv;
                _newMessage = true;
            }
        }

        private void receiveThread()
        {
            //System.IO.StreamReader reader = new System.IO.StreamReader(_tcpClient.GetStream());
            while (_running && _tcpClient.IsConnected())
            {
                string rcv = string.Empty;
                if(_tcpClient != null)
                    _tcpClient.Receive(out rcv);
                handleReceivedData(rcv);
            }
        }

        private TCPConnection _tcpClient;
        private System.Threading.Thread _rcvThread;
        private string _clientMessage = "";
        private volatile bool _running = true;
        private volatile bool _newMessage = false;
    }
}
