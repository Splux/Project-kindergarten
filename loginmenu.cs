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
            serverConnection = new TCPConnection("framtidadnsnamn");
        }

        #region Private variables
        private TCPConnection serverConnection;
        #endregion

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (textBox_Username.Text == "" || textBox_Password.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Enter both username and/or password");
                return;
            }
            string sendData = textBox_Username.Text + '\\' + textBox_Password.Text;
            System.Windows.Forms.MessageBox.Show(textBox_Username.ToString());
            serverConnection.Send(sendData);
            string rcvData;
            serverConnection.Receive(out rcvData);
            if (string.IsNullOrEmpty(rcvData))
            {
                System.Windows.Forms.MessageBox.Show("Something went wrong!");
                return;
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
    }
}
