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


        public MainMenu()
        {
            InitializeComponent();
        }
        ~MainMenu()
        {
            Application.Exit();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            Paint += new PaintEventHandler(updateScreen);
            bm = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics gr = Graphics.FromImage(bm);
            Rectangle rec = new Rectangle(100, 100, 200, 200);
            Pen pen = new Pen(Color.White, 4);
            gr.DrawRectangle(pen, rec);
            
            gr.Dispose();
        }

        void updateScreen(object sender, PaintEventArgs e)
        {
            //throw new NotImplementedException();
            Graphics gr = e.Graphics;

            gr.Clear(Color.Blue);
            gr.DrawImage(bm, 0, 0, bm.Width, bm.Height);

            gr.Dispose();
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
