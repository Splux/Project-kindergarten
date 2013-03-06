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
        #region Private variables
        private TCPConnection serverConnection;
        private bool _dragging;
        private Point _startPoint = new Point(0, 0);
        private int _fullBorderXSize = 677;
        private int _minBorderXSize = 285;
        #endregion

        public loginmenu()
        {
            InitializeComponent();
            this.Show();
        }

        private void loginmenu_Load(object sender, EventArgs e)
        {
            //serverConnection = new TCPConnection(System.Net.IPAddress.Parse("172.20.0.172"));
            serverConnection = new TCPConnection("asdfs");

            // Add eventhandlers for window-dragging functionality
            this.MouseDown += new MouseEventHandler(onMouseDown);
            this.MouseUp += new MouseEventHandler(onMouseUp);
            this.MouseMove += new MouseEventHandler(onMouseMove);
            _dragging = false;

            #region Make stuff disappear
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
            #endregion
            this.Size = new Size(285, 265);


            MainMenu menu = new MainMenu();
            menu.Show();
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
            if (rcvData[0] == '0')
            {
                this.Hide();
                MainMenu menu = new MainMenu();
                menu.Show();
            }
            this.Hide();
            MainMenu mesnu = new MainMenu();
            mesnu.Show();
        }

        private bool isValidRegister()
        {
            // Check so both passwords are correct and not empty
            if (string.IsNullOrEmpty(textBox_RegPw.Text))
            {
                System.Windows.Forms.MessageBox.Show("Enter password.");
                return false;
            }
            // Compare regpw + confirmation pw
            if (textBox_RegPw.Text.CompareTo(textBox_ConfirmPw.Text) != 0)
            {
                System.Windows.Forms.MessageBox.Show("Password mismatch.");
                return false;
            }
            // check for valid username
            if (string.IsNullOrEmpty(textBox_RegUsrname.Text))
            {
                System.Windows.Forms.MessageBox.Show("Enter a username.");
                return false;
            }
            // check for invalid characters in loginmail/usrname/pw
            if (textBox_LoginEmail.Text.Contains('@'))
            {
                System.Windows.Forms.MessageBox.Show("Don't use '@' in mail >:(");
                return false;
            }

            if (textBox_ConfirmPw.Text.Contains('\\') || textBox_RegPw.Text.Contains('\\') || textBox_RegUsrname.Text.Contains('\\'))
            {
                System.Windows.Forms.MessageBox.Show("Don't use '\\' in password or username");
                return false;
            }

            return true;
        }

        private void btn_Register1_Click(object sender, EventArgs e)
        {
            // Check so both password is valid
            if (!isValidRegister())
            {
                textBox_RegPw.Text = string.Empty;
                textBox_ConfirmPw.Text = string.Empty;
                return;
            }
            
            System.Windows.Forms.MessageBox.Show("3" + '\\' + textBox_RegUsrname.Text + '\\' +
                textBox_RegPw.Text + '\\' + textBox_LoginEmail.Text);

            string sendData = "3" + textBox_RegUsrname.Text + '\\' +
                textBox_RegPw.Text + '\\' + textBox_LoginEmail.Text;

            System.Windows.Forms.MessageBox.Show(sendData);

            serverConnection.Send(sendData);
            string retVal;
            serverConnection.Receive(out retVal);

            // retVal[0] should be 3, else something failed
            if (string.IsNullOrEmpty(retVal))
            {
                MessageBox.Show("WHAT");
                textBox_ConfirmPw.Clear();
                textBox_LoginEmail.Clear();
                textBox_RegPw.Clear();
                textBox_RegUsrname.Clear();
                return;
            }
            else if (retVal[0] != '3')
            {
                System.Windows.Forms.MessageBox.Show("Registration failed");
                return;
            }

            System.Windows.Forms.MessageBox.Show("Registration successful!");
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
            for (int i = this.Size.Width; i <= _fullBorderXSize; i += 3)
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
            for (int i = this.Size.Width; i >= _minBorderXSize; i -= 3)
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