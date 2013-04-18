/*
 * Wrapper class for TCP Connections
 * Programmer: Marcus Östlund
 * 
 * */

/*Todo: 
 * 
 *fix the multithreaded version (and testc it)
 *fix singlethreaded version
 *make sure it is threadsafe
 *try not to fail
 */

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
        private System.IO.StreamReader _streamReader;
        private System.IO.StreamWriter _streamWriter;

        public System.Net.Sockets.NetworkStream GetStream()
        {
            return _tcpClient.GetStream();
        }

        #endregion

        public TCPConnection()
        {
            _tcpClient = null;
        }
        public TCPConnection(System.Net.Sockets.TcpClient client)
        {
            _tcpClient = client;
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
        }
        ~TCPConnection()
        {
            this.Close();
        }

        public bool IsConnected()
        {
            if (_tcpClient == null)
                return false;
            try
            {
                _streamWriter.WriteLine("123");
                _streamWriter.Flush();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
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

            //_stillAlive = false;

            //_rcvThread.Join();

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

            //Log.Write("Sending\n\n");

            //System.Windows.Forms.MessageBox.Show("Sending");

            // Do nothing if no connection is open
            if (_tcpClient == null)
                return;
            else if (!_tcpClient.Connected)
            {
                System.Windows.Forms.MessageBox.Show("failed to send information to server");
                return;
            }
            else if (inString == null || inString == string.Empty)
            {
                System.Windows.Forms.MessageBox.Show("inString == null || inString == string.empty");
                return;
            }
            try
            {
                // Try to write
                _streamWriter = new System.IO.StreamWriter(_tcpClient.GetStream());
                _streamWriter.WriteLine(inString);
                _streamWriter.Flush();
            }
            catch (Exception e)
            {
                // Probably not connected anymore
                System.Windows.Forms.MessageBox.Show("Couldn't send information to server\n " +
                "Please check your internet connection");
                Log.Write(e.ToString());
            }
            //System.Windows.Forms.MessageBox.Show("So good, so far...");
        }

        public bool Peek()
        {
            _streamReader = new System.IO.StreamReader(_tcpClient.GetStream());

            // > 0 == something to read
            if (_streamReader.Peek() > 0)
            {
                return true;
            }
            return false;
        }

        public void Receive(out string outString)
        {
            outString = string.Empty;
            // If there's no active connection - return with outString as an empty string
            if (_tcpClient == null)
                return;
            if (!_tcpClient.Connected)
            {
                //System.Windows.Forms.MessageBox.Show("Connection dropped, dunno why");
                Log.Write("Lost connection...\n\n\n");
                return;
            }

            _streamReader = new System.IO.StreamReader(_tcpClient.GetStream());
            try
            {
                outString = _streamReader.ReadLine();
            }
            catch (Exception e)
            {
                Log.Write("\n\n" + e.ToString());
            }

            //_streamReader.Close();

            //tcpNetStream = tcpClient.GetStream();
            // //Byte array to read the networkstream into
            //byte[] data = new byte[256];
            //tcpNetStream.Read(data, 0, data.Length);

            // //Turn bytes into a readable string
            //outString = System.Text.Encoding.ASCII.GetString(data);

            ////_tcpNetStream.Close();
        }
    }
}
// Dat series of closing brackets...