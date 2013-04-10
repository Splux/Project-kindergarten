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
        System.Drawing.Bitmap myBitmap;
        

        public FindGame()
        {
            InitializeComponent();

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



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void pb_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string[] splitString(string str, char split)
        {
            try
            {
                return str.Split(split);
            }
            catch (Exception e)
            {
                Log.Write(e.ToString());
                MessageBox.Show("SEriosly?");
            }
            return null;
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
                foreach(string str in servers)
                {
                    lb_Serverlist.Items.Add(str);
                }
            }
        }
    }
}
