﻿namespace Project_kindergarten
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
            // namebox
            // 
            this.lb_users.FormattingEnabled = true;
            this.lb_users.Location = new System.Drawing.Point(19, 85);
            this.lb_users.Name = "namebox";
            this.lb_users.Size = new System.Drawing.Size(181, 238);
            this.lb_users.TabIndex = 2;
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.lb_users);
            this.Controls.Add(this.lbl_ipaddress);
            this.Controls.Add(this.lbl_serverName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Lobby";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Lobby";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_serverName;
        private System.Windows.Forms.Label lbl_ipaddress;
        private System.Windows.Forms.ListBox lb_users;
    }
}