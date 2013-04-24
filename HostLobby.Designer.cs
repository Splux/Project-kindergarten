namespace Project_kindergarten
{
    partial class HostLobby
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_serverName = new System.Windows.Forms.Label();
            this.lbl_ipaddress = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.lb_Users = new System.Windows.Forms.ListBox();
            this.btn_Exit = new System.Windows.Forms.Button();
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
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(1146, 685);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(208, 71);
            this.btn_Start.TabIndex = 2;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            this.btn_Start.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HostLobby_KeyUp);
            // 
            // lb_Users
            // 
            this.lb_Users.FormattingEnabled = true;
            this.lb_Users.Location = new System.Drawing.Point(19, 80);
            this.lb_Users.Name = "lb_Users";
            this.lb_Users.Size = new System.Drawing.Size(120, 251);
            this.lb_Users.TabIndex = 4;
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btn_Exit.Location = new System.Drawing.Point(19, 685);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(246, 71);
            this.btn_Exit.TabIndex = 5;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // HostLobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.lb_Users);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.lbl_ipaddress);
            this.Controls.Add(this.lbl_serverName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HostLobby";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "HostLobby";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_serverName;
        private System.Windows.Forms.Label lbl_ipaddress;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.ListBox lb_Users;
        private System.Windows.Forms.Button btn_Exit;
    }
}