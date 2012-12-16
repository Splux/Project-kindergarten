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
    public partial class loginmenu : Form
    {
        public loginmenu()
        {
            InitializeComponent();
            this.Show();
        }

        private void loginmenu_Load(object sender, EventArgs e)
        {
            //byte[] ipaddr = System.Text.ASCIIEncoding.ASCII.GetBytes("172.20.0.123");
            //serverConnection = new TCPConnection(System.Net.IPAddress.Parse("172.20.0.123"));
            serverConnection = new TCPConnection("asdfs");

            // Add eventhandlers for window-dragging functionality
            this.MouseDown += new MouseEventHandler(onMouseDown);
            this.MouseUp += new MouseEventHandler(onMouseUp);
            this.MouseMove += new MouseEventHandler(onMouseMove);
            _dragging = false;

            // Set visibility of register menu to false.
            textBox_RegUsrname.Visible = false;
            textBox_RegPw.Visible = false;
            textBox_ConfirmPw.Visible = false;
            textBox_LoginEmail.Visible = false;

            btn_Register1.Visible = false;

            lbl_RegConfPw.Visible = false;
            lbl_RegEmail.Visible = false;
            lbl_RegPw.Visible = false;
            lbl_RegUser.Visible = false;

            pb_Border.Visible = false;

            this.Size = new Size(330, 265);
        }


        #region Windowdragging
        void onMouseMove(object sender, MouseEventArgs e)
        {
            // Change windowlocation if left mouse is pressed
            if (_dragging)
            {
                Point mousePos = new Point(e.X, e.Y);
                Point onScreenCoord = PointToScreen(mousePos);
                this.Location = new Point(onScreenCoord.X - _startPoint.X, onScreenCoord.Y - _startPoint.Y);
            }
        }

        private void onMouseDown(object sender, MouseEventArgs e)
        {
            // If left button, make window draggable
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                _dragging = true;
                _startPoint = new Point(e.X, e.Y);
            }
        }

        private void onMouseUp(object sender, MouseEventArgs e)
        {
            // If left mousebutton was released, set dragging to false
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
                _dragging = false;
        }

        #endregion

        #region Private variables
        private TCPConnection serverConnection;
        private bool _dragging;
        private Point _startPoint = new Point(0, 0);
        #endregion

        private void btn_Login_Click(object sender, EventArgs e)
        {
            // Keeping this messagebox, in case I need to disable all this again
            //MessageBox.Show("This section is commented out for testing purpose");
            if (textBox_Username.Text == "" || textBox_Password.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Enter both username and/or password");
                return;
            }
            string sendData = "0" + textBox_Username.Text + '\\' + textBox_Password.Text;
            //System.Windows.Forms.MessageBox.Show(textBox_Username.ToString());
            string rcvData;
            serverConnection.Send(sendData);
            serverConnection.Receive(out rcvData);
            if (string.IsNullOrEmpty(rcvData))
            {
                System.Windows.Forms.MessageBox.Show("Something went wrong!\n Blame our monkeys.");
                return;
            }
            if (rcvData[0] == '1')
            {

            }
        }

        private void btn_Register1_Click(object sender, EventArgs e)
        {
            if (!textBox_ConfirmPw.Text.Equals(textBox_RegPw.Text))
            {
                System.Windows.Forms.MessageBox.Show("Password mismatch");
                textBox_ConfirmPw.Clear();
                textBox_RegPw.Clear();
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showRegObjects()
        {
            // Set visibility of register menu to true
            // Textboxes
            textBox_RegUsrname.Visible = true;
            textBox_RegPw.Visible = true;
            textBox_ConfirmPw.Visible = true;
            textBox_LoginEmail.Visible = true;
            // Button
            btn_Register1.Visible = true;
            // Labels
            lbl_RegConfPw.Visible = true;
            lbl_RegEmail.Visible = true;
            lbl_RegPw.Visible = true;
            lbl_RegUser.Visible = true;
            // Border
            pb_Border.Visible = true;
            //pb_Border.Update();

            // Set size so we can see it again
            for (int i = this.Size.Width; i <= 677; i += 3)
            {
                this.Size = new Size(i, this.Size.Height);
            }
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            // do it in a thread to avoid a bug I can't solve.
            System.Threading.Thread th = new System.Threading.Thread(showRegObjects);
            th.Start();
            
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            

            // Set size so we cannot see it again.
            for (int i = this.Size.Width; i >= 330; i -= 3)
            {
                Size = new Size(i, this.Size.Height);
            }

            // Set visibility of register menu to false.
            textBox_RegUsrname.Visible = false;
            textBox_RegPw.Visible = false;
            textBox_ConfirmPw.Visible = false;
            textBox_LoginEmail.Visible = false;

            btn_Register1.Visible = false;

            lbl_RegConfPw.Visible = false;
            lbl_RegEmail.Visible = false;
            lbl_RegPw.Visible = false;
            lbl_RegUser.Visible = false;

            pb_Border.Visible = false;
        }

        private void loginmenuKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        
    }
}