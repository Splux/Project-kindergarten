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
            pb_Back.Image = new Bitmap(216, 116);
            Bitmap temp = new Bitmap(pb_Back.Image);
            Graphics graph = Graphics.FromImage(temp);
            graph.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            graph.DrawString("Back", new Font("Arial", 25, FontStyle.Bold), Brushes.White, new PointF(0, 0));
            
            pb_Back.Image = temp;
            pb_Back.Update();

            pictureBox1.Image = new Bitmap(@"Backgroundexempel.png");
            pictureBox1.Update();
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
    }
}
