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
    public partial class VerifyUser : Form
    {
        public VerifyUser()
        {
            InitializeComponent();
        }

        public VerifyUser(System.Net.IPAddress serverIP, string username)
        {
            InitializeComponent();
            _serverConnection = null;
            _username = username;
            tb_Verification.Text = string.Empty;
            _serverIP = serverIP;
            this.btn_Send.Click += new EventHandler(sendVerification);
            this.btn_Close.Click += new EventHandler(closeVerifier);
        }

        void closeVerifier(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.Close();
        }

        private void sendVerification(object obj, EventArgs args)
        {
            string SendString = tb_Verification.Text;

            if (SendString == string.Empty)
            {
                System.Windows.Forms.MessageBox.Show("Verification code cannot be empty");
                this.Close();
                return;
            }
            else
            {
                _serverConnection = new TCPConnection(_serverIP);
                StringBuilder sb = new StringBuilder();
                sb.Append("C");
                sb.Append(_username);
                sb.Append("\\" + SendString);
                SendString = sb.ToString();
                _serverConnection.Send(SendString);

                int TimePassed = 0;
                string RcvString = string.Empty;

                do 
                {
                    _serverConnection.Receive(out RcvString);
                    System.Threading.Thread.Sleep(50);
                    TimePassed += 50;
                } while (RcvString == string.Empty && TimePassed <= 5000);

                if (RcvString == null)
                {
                    MessageBox.Show("NULL");
                    _userVerified = false;
                    return;
                }

                if (RcvString == string.Empty)
                {
                    _userVerified = false;
                }
                else if (RcvString[0] == 'M')
                {
                    _userVerified = false;
                }
                else
                {
                    _userVerified = true;
                }
                
            }

            this.Close();
        }

        private bool _userVerified = false;

        public bool IsVerified
        {
            get
            {
                return _userVerified;
            }
            set
            {

            }
        }

        private string _username;
        private System.Net.IPAddress _serverIP;
        private TCPConnection _serverConnection;
    }
}
