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
    public partial class newgame : Form
    {
        System.Drawing.Bitmap myBitmap;
        Image i = Image.FromFile("Backgroundexempel.png");//upload background image to i
        Image j = Image.FromFile("knapp1.png");//upload first button to j
        Image k = Image.FromFile("knapp2.png");
        Image l = Image.FromFile("knapp3.png");
        Image m = Image.FromFile("knapp4.png");

        public newgame()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            newgame NG = new newgame();
            NG.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Create_Game CG = new Create_Game();
            CG.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu MM = new MainMenu();
            MM.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void newgame_Load(object sender, EventArgs e)
        {
            myBitmap = new Bitmap(1960, 1080);//make bitmap
            //apply bitmap to picturebox and update
            pictureBox1.Image = i;//myBitmap;
            pictureBox1.Update();
            pictureBox2.Image = j;//myBitmap;
            pictureBox2.Update();
            pictureBox3.Image = k;
            pictureBox3.Update();
            pictureBox4.Image = l;
            pictureBox4.Update();
            pictureBox5.Image = m;
            pictureBox5.Update();
            Rectangle rect = Screen.PrimaryScreen.Bounds;
            this.Width = rect.Width;
            this.Height = rect.Height;
            this.Location = new Point(0, 0);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
