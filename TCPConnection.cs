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
        public TCPConnection()
        {
            this.tcpClient = new System.Net.Sockets.TcpClient();
        }
        public TCPConnection(string dnsName)
        {
            this.Open(dnsName);
        }
        public TCPConnection(System.Net.IPAddress ipAddress)
        {

        }
        ~TCPConnection()
        {
            this.Close();
        }

        public bool Close()
        {
            if (tcpClient == null)
                return false;
            try
            {
                tcpClient.Close();
                tcpClient = null;
            }
            catch (System.Net.Sockets.SocketException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                return false;
            }

            return true;
        }
        public bool Open(System.Net.IPAddress ipAddress)
        {
            if (tcpClient != null)
                if (tcpClient.Connected)
                    return false;
            tcpClient = new System.Net.Sockets.TcpClient();
            try
            {
                tcpClient.Connect(ipAddress, 1337);
            }
            catch (System.Net.Sockets.SocketException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                Log.Write(e.ToString());
                return false;
            }
            return true;
        }
        public bool Open(string dnsName)
        {
            // If tcpClient is non-null value or connected to something else, return false
            if (tcpClient != null)
            {
                if (tcpClient.Connected)
                    return false;
            }

            tcpClient = new System.Net.Sockets.TcpClient();
            try
            {
                tcpClient.Connect(dnsName, 1337);
            }
            catch (System.Net.Sockets.SocketException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                Log.Write(e.ToString());
                return false;
            }

            return true;
        }
        public void Send(string inString)
        {
            // Do nothing if no connection is open
            if (tcpClient == null)
                return;
            else if (!tcpClient.Connected)
                return;
            else if (inString == null)
                return;
            try
            {
                // Get the network stream
                tcpNetStream = tcpClient.GetStream();
                //Convert string to bytes
                byte[] sendBytes = System.Text.Encoding.ASCII.GetBytes(inString);
                // Fire away.
                tcpNetStream.Write(sendBytes, 0, sendBytes.Length);
                // Close the stream, otherwise it'll block everything else.
                tcpNetStream.Close();
            }
            catch (System.Net.Sockets.SocketException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }
        public void Receive(out string outString)
        {
            outString = string.Empty;
            // If there's no active connection - return with outString as an empty string
            if (!tcpClient.Connected)
                return;

            tcpNetStream = tcpClient.GetStream();
            // Byte array to read the networkstream into
            byte[] data = new byte[256];
            tcpNetStream.Read(data, 0, data.Length);
            // Turn bytes into a readable string
            outString = System.Text.Encoding.ASCII.GetString(data);

            tcpNetStream.Close();
        }

        #region Private variables

        System.Net.Sockets.TcpClient tcpClient = null;
        System.Net.Sockets.NetworkStream tcpNetStream;

        #endregion
    }
}
