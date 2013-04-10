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
            TCPConnection con = new TCPConnection(System.Net.IPAddress.Parse(GrabbarnasIP.ipAddress));

            con.Send(Flags.LOGIN_REQUEST  + "test" + "\\" + "test");
            string loge;
            int time = 0;
            do
            {
                con.Receive(out loge);
                System.Threading.Thread.Sleep(50);
            }
            while (time <= 5000 && string.IsNullOrEmpty(loge));

            if (string.IsNullOrEmpty(loge))
            {
                MessageBox.Show("Okay...");
                return;
            }
            if (loge[0] == Flags.LOGIN_SUCCESSFUL[0])
            {
                // Send request to server
                con.Send(Flags.FIND_SERVER_REQUEST);
                int timer = 0;
                string rcv = string.Empty;
                // Try for 5sec to get a result from server
                do
                {
                    con.Receive(out rcv);
                    System.Threading.Thread.Sleep(50);
                    timer += 50;
                } while (timer <= 5000 && rcv == string.Empty);

                con.Close();

                if (rcv == string.Empty)
                {
                    MessageBox.Show("NO");
                    return;
                }

                //MessageBox.Show(rcv);

                string[] hosts = rcv.Split('\\');

                lb_Serverlist.Text = string.Empty;

                // Clear the list, check if there are any servers in host and if there are any servers
                // we will loop through it and add to the list
                lb_Serverlist.Items.Clear();
                if (hosts == null)
                {
                    lb_Serverlist.Items.Add("No servers");
                    lb_Serverlist.Items.Add("Click refresh to search again");
                    return;
                }

                foreach (string str in hosts)
                {
                    lb_Serverlist.Items.Add(str);
                }
            }
            else
                MessageBox.Show("failure");
            con.Close();
        }
    }
}
