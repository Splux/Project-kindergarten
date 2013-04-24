namespace Project_kindergarten
{
    partial class Lobby
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void closeThis()
        {
            Close();
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_serverName = new System.Windows.Forms.Label();
            this.lbl_ipaddress = new System.Windows.Forms.Label();
            this.lb_users = new System.Windows.Forms.ListBox();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.tb_Chat = new System.Windows.Forms.TextBox();
            this.lbl_chat = new System.Windows.Forms.Label();
            this.btn_ChatSend = new System.Windows.Forms.Button();
            this.tb_WriteChat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_serverName
            // 
            this.lbl_serverName.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_serverName.Location = new System.Drawing.Point(12, 9);
            this.lbl_serverName.Name = "lbl_serverName";
            this.lbl_serverName.Size = new System.Drawing.Size(1366, 50);
            this.lbl_serverName.TabIndex = 0;
            this.lbl_serverName.Text = "Default servername";
            this.lbl_serverName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_ipaddress
            // 
            this.lbl_ipaddress.AutoSize = true;
            this.lbl_ipaddress.Location = new System.Drawing.Point(16, 59);
            this.lbl_ipaddress.Name = "lbl_ipaddress";
            this.lbl_ipaddress.Size = new System.Drawing.Size(72, 13);
            this.lbl_ipaddress.TabIndex = 1;
            this.lbl_ipaddress.Text = "No ip address";
            // 
            // lb_users
            // 
            this.lb_users.FormattingEnabled = true;
            this.lb_users.Location = new System.Drawing.Point(19, 85);
            this.lb_users.Name = "lb_users";
            this.lb_users.Size = new System.Drawing.Size(181, 238);
            this.lb_users.TabIndex = 2;
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Location = new System.Drawing.Point(19, 694);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(181, 48);
            this.btn_disconnect.TabIndex = 3;
            this.btn_disconnect.Text = "Disconnect";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_Disconnect_Click);
            // 
            // tb_Chat
            // 
            this.tb_Chat.BackColor = System.Drawing.SystemColors.Window;
            this.tb_Chat.Location = new System.Drawing.Point(321, 85);
            this.tb_Chat.Multiline = true;
            this.tb_Chat.Name = "tb_Chat";
            this.tb_Chat.ReadOnly = true;
            this.tb_Chat.Size = new System.Drawing.Size(545, 339);
            this.tb_Chat.TabIndex = 4;
            // 
            // lbl_chat
            // 
            this.lbl_chat.AutoSize = true;
            this.lbl_chat.Location = new System.Drawing.Point(321, 63);
            this.lbl_chat.Name = "lbl_chat";
            this.lbl_chat.Size = new System.Drawing.Size(29, 13);
            this.lbl_chat.TabIndex = 5;
            this.lbl_chat.Text = "Chat";
            // 
            // btn_ChatSend
            // 
            this.btn_ChatSend.Location = new System.Drawing.Point(790, 431);
            this.btn_ChatSend.Name = "btn_ChatSend";
            this.btn_ChatSend.Size = new System.Drawing.Size(75, 23);
            this.btn_ChatSend.TabIndex = 8;
            this.btn_ChatSend.Text = "Send";
            this.btn_ChatSend.UseVisualStyleBackColor = true;
            this.btn_ChatSend.Click += new System.EventHandler(this.btn_ChatSend_Click);
            // 
            // tb_WriteChat
            // 
            this.tb_WriteChat.Location = new System.Drawing.Point(324, 433);
            this.tb_WriteChat.Name = "tb_WriteChat";
            this.tb_WriteChat.Size = new System.Drawing.Size(460, 20);
            this.tb_WriteChat.TabIndex = 7;
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.tb_WriteChat);
            this.Controls.Add(this.btn_ChatSend);
            this.Controls.Add(this.lbl_chat);
            this.Controls.Add(this.tb_Chat);
            this.Controls.Add(this.btn_disconnect);
            this.Controls.Add(this.lb_users);
            this.Controls.Add(this.lbl_ipaddress);
            this.Controls.Add(this.lbl_serverName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Lobby";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Lobby";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_serverName;
        private System.Windows.Forms.Label lbl_ipaddress;
        private System.Windows.Forms.ListBox lb_users;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.TextBox tb_Chat;
        private System.Windows.Forms.Label lbl_chat;
        private System.Windows.Forms.Button btn_ChatSend;
        private System.Windows.Forms.TextBox tb_WriteChat;
    }
}