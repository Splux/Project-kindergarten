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
            serverConnection = new TCPConnection(System.Net.IPAddress.Parse("172.20.0.123"));

            // Add eventhandlers for window-dragging functionality
            this.MouseDown += new MouseEventHandler(onMouseDown);
            this.MouseUp += new MouseEventHandler(onMouseUp);
            this.MouseMove += new MouseEventHandler(onMouseMove);
            _dragging = false;
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

        private void btn_Register_Click(object sender, EventArgs e)
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

        
    }
}
