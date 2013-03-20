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
    public partial class Create_Game : Form
    {
        System.Drawing.Bitmap myBitmap;

        public Create_Game()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Create_Game_Load(object sender, EventArgs e)
        {
            myBitmap = new Bitmap(1366, 768);

            Image bgimg = Image.FromFile("Backgroundexempel.png");


            pictureBox1.Image = bgimg;//myBitmap;
            pictureBox1.Update();
           // pictureBox2.Image = j;//myBitmap;
            //pictureBox2.Update();
            //pictureBox3.Image = k;
            //pictureBox3.Update();
            //pictureBox4.Image = l;
            //pictureBox4.Update();
            //pictureBox5.Image = m;
            //pictureBox5.Update();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Update();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            

            if (checkBox1.Checked == true)
                textBox2.UseSystemPasswordChar = true;
            else
                textBox2.UseSystemPasswordChar = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Image map1 = Image.FromFile("map1.png");

            pictureBox2.Image = map1;
            pictureBox2.Update();
            if (radioButton1.Checked == true)
            {
                label4.Text = "Map 1";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Image map2 = Image.FromFile("map2.png");

            pictureBox2.Image = map2;
            pictureBox2.Update();

            if (radioButton2.Checked == true)
            {
                label4.Text = "Map 2";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {






        }
    }
}