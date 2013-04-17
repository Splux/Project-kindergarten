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
    public partial class FindGame : Form
    {
        private System.Drawing.Bitmap myBitmap;
        private System.Collections.Specialized.StringDictionary _serverList;

        public FindGame()
        {
            InitializeComponent();
            _serverList = new System.Collections.Specialized.StringDictionary();
            // Create a bitmap and graphics object to draw a string (too bad for photoshop)
            try
            {
                pb_Back.Image = new Bitmap(@"knapp4.png");
                pb_Back.Size = new System.Drawing.Size(300, 250);
            }
            catch (System.Exception ex)
            {
                Log.Write(ex.ToString());
                MessageBox.Show("Missing resources");
                this.Close();
            }

            lb_Serverlist.Items.Add("No servers\npress update to update");

            //pictureBox1.Image = new Bitmap(@"Backgroundexempel.png");
            //pictureBox1.Update();
            
        }

        private void newgame_Load(object sender, EventArgs e)
        {
            myBitmap = new Bitmap(1960, 1080);//make bitmap
            //apply bitmap to picturebox and update
            //pictureBox1.Image = null;//myBitmap;
            //pictureBox1.Update();
            Rectangle rect = Screen.PrimaryScreen.Bounds;
            this.Width = rect.Width;
            this.Height = rect.Height;
            this.Location = new Point(0, 0);
        }

        private void pb_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refreshServerList(object sender, EventArgs e)
        {
            if (!UserInfo.TcpClient.IsConnected())
            {
                MessageBox.Show("Connection to server has dropped...");
                Application.Exit();
                return;
            }
            // Send find request to main server
            UserInfo.TcpClient.Send(Flags.FIND_SERVER_REQUEST);
            // try and receive an answer for 5sec
            string rcvString;
            int time = 0;
            do
            {
                UserInfo.TcpClient.Receive(out rcvString);
                time += 50;
            } while (rcvString == string.Empty && time <= 5000);

            if(rcvString == null || rcvString == string.Empty)
            {
                lb_Serverlist.Items.Clear();
                lb_Serverlist.Items.Add("Fuck it");
            }
            else
            {
                // Split received string and loop through a string array and add to serverlist
                string[] servers = rcvString.Split('\\');
                if (servers == null)
                    return;

                // clear and loop through all servers from main server
                lb_Serverlist.Items.Clear();
                _serverList.Clear();
                foreach(string str in servers)
                {
                    // split string again to get username + ip
                    string[] userAndIp = str.Split('/');
                    if(userAndIp == null)
                    {
                        MessageBox.Show("Find out what went wrong, you lazy fuck");
                    }
                    lb_Serverlist.Items.Add(userAndIp[0]);

                    try
                    {
                        _serverList.Add(userAndIp[0], userAndIp[1]);
                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void btn_joinGame_Click(object sender, EventArgs e)
        {
            if (_serverList.Count < 1 || lb_Serverlist.SelectedIndex == -1)
                return;

            string serverName = lb_Serverlist.SelectedItem.ToString();
            if(_serverList.ContainsKey(serverName))
            {
                Lobby lobby = new Lobby(_serverList[serverName]);
                this.Hide();
                lobby.ShowDialog();
                this.Show();
            }
        }
    }
}
