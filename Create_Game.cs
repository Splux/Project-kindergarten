﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_kindergarten
{
    public partial class Create_Game : Form
    {
        System.Drawing.Bitmap myBitmap;

        public Create_Game()
        {
            InitializeComponent();
            tb_ServerName.Text = UserInfo.PlayerName + "'s server";
        }

        private void Create_Game_Load(object sender, EventArgs e)
        {
            myBitmap = new Bitmap(1366, 768);

            Image bgimg = Image.FromFile("Backgroundexempel.png");


            pb_BackGround.Image = bgimg;//myBitmap;
            pb_BackGround.Update();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tb_Password.Update();
        }

        private void tb_Password_TextChanged(object sender, EventArgs e)
        {
            if (cb_HideChar.Checked == true)
                tb_Password.UseSystemPasswordChar = true;
            else
                tb_Password.UseSystemPasswordChar = false;
        }

        private void pb_ShowMap_Click(object sender, EventArgs e)
        {
        }

        private void rb_MapOne_CheckChanged(object sender, EventArgs e)
        {
            Image map1 = Image.FromFile("map1.png");

            pb_ShowMap.Image = map1;
            pb_ShowMap.Update();
            if (rb_MapOne.Checked == true)
            {
                lbl_MapName.Text = "Map 1";
            }
        }

        private void rb_MapTwo_CheckedChanged(object sender, EventArgs e)
        {
            Image map2 = Image.FromFile("map2.png");

            pb_ShowMap.Image = map2;
            pb_ShowMap.Update();

            if (rb_MapTwo.Checked == true)
            {
                lbl_MapName.Text = "Map 2";
            }
        }

        private void btn_CreateGame_Click(object sender, EventArgs e)
        {
            if(UserInfo.TcpClient.IsConnected())
            {
                UserInfo.TcpClient.Send(Flags.HOST_REQUEST);

                int time = 0;
                string rcv;
                do
                {
                    UserInfo.TcpClient.Receive(out rcv);
                    time += 50;
                } while (rcv == string.Empty && time <= 5000);

                if(rcv == string.Empty)
                {
                    MessageBox.Show("Server not created; random error");
                    return;
                }
                else
                {
                    if(rcv == Flags.HOST_CREATION_SUCCESS)
                    {
                        HostLobby lobby = new HostLobby(tb_ServerName.Text);
                        this.Hide();
                        lobby.ShowDialog();
                        this.Show();

                        if(UserInfo.TcpClient.Peek())
                        {
                            string strRcv;
                            UserInfo.TcpClient.Receive(out strRcv);
                            if(strRcv == string.Empty || strRcv == "")
                            {
                                MessageBox.Show("Something just happened...");
                            }
                            else
                            {
                                if(strRcv[0] == Flags.HOST_SUCCESSFUL_REMOVE[0])
                                {
                                    MessageBox.Show("Host removed");
                                }
                            }
                        }
                    }
                    else if(rcv == Flags.HOST_SUCCESSFUL_REMOVE)
                    {
                        // what
                        MessageBox.Show("Removed server from main server");
                    }
                }
            }
        }
    }
}