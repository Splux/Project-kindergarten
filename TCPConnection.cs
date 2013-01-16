/*
 * Wrapper class for TCPConnections
 * Programmer: Marcus Östlund
 * 
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_kindergarten
{
    class TCPConnection
    {
        #region Private variables

        private System.Net.Sockets.TcpClient _tcpClient = null;
        private System.Net.Sockets.NetworkStream _tcpNetStream;
        private System.IO.StreamReader _streamReader;
        //private System.Threading.Mutex _rcvMutex;
        private System.Threading.Thread _rcvThread = null;
        private string _rcvString = null;

        private bool _stillAlive = true;

        private List<string> _rcvStrings = new List<string>();

        public string RcvString
        {
            get
            {
                lock (_rcvString)
                {
                    return _rcvString;
                }
            }
            set
            {
                //lock (_rcvString)
                //{
                //    _rcvString = value;
                //}
            }
        }

        #endregion

        public TCPConnection()
        {
            _tcpClient = null;
        }
        public TCPConnection(string dnsName)
        {
            if(!this.Open(dnsName))
                System.Windows.Forms.MessageBox.Show("Failed to connect to remote server");
        }
        public TCPConnection(System.Net.IPAddress ipAddress)
        {
            if (!this.Open(ipAddress))
                System.Windows.Forms.MessageBox.Show("Failed to connect to remote server");
            if (_tcpClient != null)
            {
                _rcvThread = new System.Threading.Thread(Receive);
                _rcvThread.Start();
            }
        }
        ~TCPConnection()
        {
            this.Close();
        }

        // There will most likely only be one object in the list, but I was bored and did it this way and just 
        // now realized another way to do it. Stupid me.
        // Well, well, at least I can request two things, get both and add to the list and then have different
        // functions take care of both of them instead of only having a string and then overwriting one of them 
        // which would lead to missing data.
        public string GetString(char id)
        {
            // Check so it isn't empty
            if (_rcvStrings.Count < 1)
                return string.Empty;


            string[] strings;
            lock (_rcvStrings) // Lock for threadsafety
            {
                strings = _rcvStrings.ToArray();
            }
            
            //for (int i = 0; i < strings.Length; i++)
            //{
            //    if(strings[i][0] == id)
            //    {
            //        lock (_rcvStrings) // Threadsafety
            //        {
            //            _rcvStrings.Remove(strings[i]);
            //        }
            //        return strings[i];
            //    }
            //}

            lock (_rcvStrings)
            {
                foreach (string str in _rcvStrings)
                {
                    if (str[0] == id)
                        return str;
                }
            }

            // Couldn't find requested string
            return string.Empty;
        }

        public bool IsConnected()
        {
            if (_tcpClient == null)
                return false;
            else
                return _tcpClient.Connected ? true : false;
        }

        public bool Close()
        {
            if (_tcpClient == null)
                return false;
            // Try to close and null the client
            try
            {
                _tcpClient.Close();
                _tcpClient = null;
            }
            catch (System.Net.Sockets.SocketException e)
            {
                //System.Windows.Forms.MessageBox.Show("Failed to close connection");
                Log.Write(e.ToString());
                return false;
            }

            _stillAlive = false;
            _rcvThread.Join();

            return true;
        }
        public bool Open(System.Net.IPAddress ipAddress)
        {
            // If tcpClient is non-null and connected to something, return false
            if (_tcpClient != null)
                if (_tcpClient.Connected)
                    return false;
            // Create new TcpClient and try to connect to remote server
            _tcpClient = new System.Net.Sockets.TcpClient();
            try
            {
                _tcpClient.Connect(ipAddress, 1337);
            }
                // Output error to fail and tell the user that they're wrong.
            catch (System.Net.Sockets.SocketException e)
            {
                //System.Windows.Forms.MessageBox.Show("Failed to open connection");
                Log.Write(e.ToString());
                _tcpClient = null;
                return false;
            }
            return true;
        }
        public bool Open(string dnsName)
        {
            // If tcpClient is non-null value or connected to something else, return false
            if (_tcpClient != null)
            {
                if (_tcpClient.Connected)
                    return false;
            }

            _tcpClient = new System.Net.Sockets.TcpClient();
            try
            {
                _tcpClient.Connect(dnsName, 1337);
            }
            // In case of emergency...
            catch (System.Net.Sockets.SocketException e)
            {
                //System.Windows.Forms.MessageBox.Show("Failed to open connection");
                Log.Write(e.ToString());
                return false;
            }

            return true;
        }
        public void Send(string inString)
        {
            // Do nothing if no connection is open
            if (_tcpClient == null)
                return;
            else if (!_tcpClient.Connected)
                return;
            else if (inString == null)
                return;
            try
            {
                // Get the network stream
                _tcpNetStream = _tcpClient.GetStream();
                //Convert string to bytes
                byte[] sendBytes = System.Text.Encoding.ASCII.GetBytes(inString);
                // Fire away.
                _tcpNetStream.Write(sendBytes, 0, sendBytes.Length);
                
                // Close the stream, otherwise it'll block everything else.
                //_tcpNetStream.Close();
            }
            catch (System.Net.Sockets.SocketException e)
            {
                System.Windows.Forms.MessageBox.Show("Couldn't send information to server\n " +
                "Please check your internet connection");
                Log.Write(e.ToString());
            }
        }
        public void Receive(out string outString)
        {
            outString = string.Empty;
            // If there's no active connection - return with outString as an empty string
            if (!_tcpClient.Connected)
                return;

            _streamReader = new System.IO.StreamReader(_tcpClient.GetStream());
            outString = _streamReader.ReadLine();

            //tcpNetStream = tcpClient.GetStream();
            // Byte array to read the networkstream into
            //byte[] data = new byte[256];
            //tcpNetStream.Read(data, 0, data.Length);
            
            // Turn bytes into a readable string
            //outString = System.Text.Encoding.ASCII.GetString(data);

            _tcpNetStream.Close();
        }

        public void Receive()
        {
            if (!_tcpClient.Connected)
            {
                System.Windows.Forms.MessageBox.Show("Not connected to server...");
                return;
            }

            using (_streamReader = new System.IO.StreamReader(_tcpClient.GetStream()))
            {
                bool stillConnected = true;
                string rcv;
                while (stillConnected && _stillAlive)
                {
                    rcv = _streamReader.ReadLine();
                    lock (_rcvStrings)
                    {
                        _rcvStrings.Add(rcv);
                    }

                    if (_rcvString == null)
                    {
                        stillConnected = false;
                    }
                }
            }
        }
    }
}
// Dat series of closing brackets...

/*Todo: 
 * 
 *fix the multithreaded version (and testc it)
 *make sure it is threadsafe
 *try not to fail
 */