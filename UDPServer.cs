using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Linq;
using System.Text;

namespace Project_Kindergarten
{
    public class UDP
    {
        private UdpClient udp_socket;
        private volatile bool ServerIsOnline;
        private Thread BroadcastThread;
        private List<IPAddress> adresslist = new List<IPAddress>();
        private IPEndPoint RemoteIpEndPoint;
        private IPEndPoint SendIpEndPoint;
        private int PortToSendTo;

        public UDP(IPAddress _IP, int _port, List<IPAddress> _adresslist)
        {
            adresslist = _adresslist;
            RemoteIpEndPoint = new IPEndPoint(_IP, _port);
            PortToSendTo = _port;
        }

        public void StopServer()
        {
            ServerIsOnline = false;
            BroadcastThread.Abort();
        }

        public void StartServer()
        {
            udp_socket = new UdpClient();
            udp_socket.Connect(RemoteIpEndPoint);
            udp_socket.AllowNatTraversal(true);
            ServerIsOnline = true;

            BroadcastThread = new Thread(ReceiveData);
            BroadcastThread.IsBackground = true;
            BroadcastThread.Start();

        }

        public void ReceiveData()
        {
            byte[] data = new byte[11000];

            while (ServerIsOnline == true)
            {
                data = udp_socket.Receive(ref RemoteIpEndPoint);
                BroadcastData(data);
            }
        }

        public void BroadcastData(Byte[] SendData)
        {
            foreach (IPAddress adress in adresslist)
            {
                try
                {
                    SendIpEndPoint = new IPEndPoint(adress, PortToSendTo);
                    udp_socket.Connect(SendIpEndPoint);
                    udp_socket.Send(SendData, SendData.Length);
                    udp_socket.Close();
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Failed to send data to " + adress.ToString() + ".");
                }
            }
        }
    }
}