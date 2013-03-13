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

    public partial class MainMenu : Form
    {
        #region variables
        Bitmap bm;
        #endregion


        System.Drawing.Bitmap myBitmap;
        Image imgBackground;
        Image imgFindGame;
        Image imgCreateGame;
        Image imgOptions;
        Image imgExit;

        public MainMenu()
        {
            try
            {
                imgBackground = Image.FromFile("Backgroundexempel.png");//upload background image
                imgFindGame = Image.FromFile("knapp1.png");
                imgCreateGame = Image.FromFile("knapp2.png");
                imgOptions = Image.FromFile("knapp3.png");
                imgExit = Image.FromFile("knapp4.png");
            }
            catch (System.Exception ex)
            {
            	
            }
            InitializeComponent();
        }
        ~MainMenu()
        {
            Application.Exit();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            //Paint += new PaintEventHandler(updateScreen);
            //bm = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height,
            //    System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            //Graphics gr = Graphics.FromImage(bm);
            //Rectangle rec = new Rectangle(100, 100, 200, 200);
            //Pen pen = new Pen(Color.White, 4);
            //gr.DrawRectangle(pen, rec);
            
            //gr.Dispose();
        

            //graphicsObj.DrawImage(i, 0, 0, pictureBox1.Size.Width, pictureBox1.Size.Height);//draw image on graphicsObj
            //graphicsObj.DrawImage(j, 0, 0, pictureBox2.Size.Width, pictureBox2.Size.Height);
            myBitmap = new Bitmap(1960, 1080);//make bitmap
            //apply bitmap to picturebox and update
            pictureBox1.Image = imgBackground;//myBitmap;
            pictureBox1.Update();
            pictureBox2.Image = imgFindGame;//myBitmap;
            pictureBox2.Update();
            pictureBox3.Image = imgCreateGame;
            pictureBox3.Update();
            pictureBox4.Image = imgOptions;
            pictureBox4.Update();
            pictureBox5.Image = imgExit;
            pictureBox5.Update();
            Rectangle rect = Screen.PrimaryScreen.Bounds;
            this.Width = rect.Width;
            this.Height = rect.Height;
            this.Location = new Point(0,0);


            //rita knappar osv


            //graphicsObj.Dispose();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            newgame NG = new newgame();
            NG.Show();
        }

        //private void pictureBox2_MouseHover(object sender, EventArgs e)
        //{
        //    pictureBox2.Image = i;
        //}

        //private void pictureBox2_MouseLeave(object sender, EventArgs e)
        //{
        //    pictureBox2.Image = j;
        //}

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Create_Game CG = new Create_Game ();
            CG.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            //gr.Clear(Color.Blue);
            //gr.DrawImage(bm, 0, 0, bm.Width, bm.Height);

            //gr.Dispose();
        }

        private void handleKeypress(object sender, KeyEventArgs ke)
        {
            if (ke.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


    }
}
