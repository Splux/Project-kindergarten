namespace Project_kindergarten
{
    partial class Create_Game
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_CreateGame = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_ServerName = new System.Windows.Forms.Label();
            this.tb_ServerName = new System.Windows.Forms.TextBox();
            this.rb_MapOne = new System.Windows.Forms.RadioButton();
            this.rb_MapTwo = new System.Windows.Forms.RadioButton();
            this.lbl_Map = new System.Windows.Forms.Label();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.cb_HideChar = new System.Windows.Forms.CheckBox();
            this.pb_ShowMap = new System.Windows.Forms.PictureBox();
            this.lbl_MapName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ShowMap)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1366, 768);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btn_CreateGame
            // 
            this.btn_CreateGame.Location = new System.Drawing.Point(1150, 681);
            this.btn_CreateGame.Name = "btn_CreateGame";
            this.btn_CreateGame.Size = new System.Drawing.Size(204, 75);
            this.btn_CreateGame.TabIndex = 5;
            this.btn_CreateGame.Text = "Create Game!";
            this.btn_CreateGame.UseVisualStyleBackColor = true;
            this.btn_CreateGame.Click += new System.EventHandler(this.btn_CreateGame_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(940, 681);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(204, 75);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "Cancel!";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbl_ServerName
            // 
            this.lbl_ServerName.AutoSize = true;
            this.lbl_ServerName.BackColor = System.Drawing.SystemColors.ControlText;
            this.lbl_ServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ServerName.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_ServerName.Location = new System.Drawing.Point(12, 9);
            this.lbl_ServerName.Name = "lbl_ServerName";
            this.lbl_ServerName.Size = new System.Drawing.Size(109, 20);
            this.lbl_ServerName.TabIndex = 7;
            this.lbl_ServerName.Text = "Server Name: ";
            // 
            // tb_ServerName
            // 
            this.tb_ServerName.BackColor = System.Drawing.SystemColors.InfoText;
            this.tb_ServerName.ForeColor = System.Drawing.SystemColors.Window;
            this.tb_ServerName.Location = new System.Drawing.Point(16, 32);
            this.tb_ServerName.Name = "tb_ServerName";
            this.tb_ServerName.Size = new System.Drawing.Size(220, 20);
            this.tb_ServerName.TabIndex = 8;
            this.tb_ServerName.Text = "<Player Name\'s> Server";
            // 
            // rb_MapOne
            // 
            this.rb_MapOne.AutoSize = true;
            this.rb_MapOne.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rb_MapOne.ForeColor = System.Drawing.SystemColors.Control;
            this.rb_MapOne.Location = new System.Drawing.Point(16, 145);
            this.rb_MapOne.Name = "rb_MapOne";
            this.rb_MapOne.Size = new System.Drawing.Size(55, 17);
            this.rb_MapOne.TabIndex = 9;
            this.rb_MapOne.TabStop = true;
            this.rb_MapOne.Text = "Map 1";
            this.rb_MapOne.UseVisualStyleBackColor = false;
            this.rb_MapOne.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rb_MapTwo
            // 
            this.rb_MapTwo.AutoSize = true;
            this.rb_MapTwo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rb_MapTwo.ForeColor = System.Drawing.SystemColors.Control;
            this.rb_MapTwo.Location = new System.Drawing.Point(16, 168);
            this.rb_MapTwo.Name = "rb_MapTwo";
            this.rb_MapTwo.Size = new System.Drawing.Size(55, 17);
            this.rb_MapTwo.TabIndex = 10;
            this.rb_MapTwo.TabStop = true;
            this.rb_MapTwo.Text = "Map 2";
            this.rb_MapTwo.UseVisualStyleBackColor = false;
            this.rb_MapTwo.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // lbl_Map
            // 
            this.lbl_Map.AutoSize = true;
            this.lbl_Map.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Map.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Map.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Map.Location = new System.Drawing.Point(12, 122);
            this.lbl_Map.Name = "lbl_Map";
            this.lbl_Map.Size = new System.Drawing.Size(44, 20);
            this.lbl_Map.TabIndex = 11;
            this.lbl_Map.Text = "Map:";
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Password.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Password.Location = new System.Drawing.Point(12, 227);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(82, 20);
            this.lbl_Password.TabIndex = 12;
            this.lbl_Password.Text = "Password:";
            // 
            // tb_Password
            // 
            this.tb_Password.BackColor = System.Drawing.SystemColors.MenuText;
            this.tb_Password.ForeColor = System.Drawing.SystemColors.Window;
            this.tb_Password.Location = new System.Drawing.Point(16, 250);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(100, 20);
            this.tb_Password.TabIndex = 13;
            this.tb_Password.Text = "<Enter Password>";
            this.tb_Password.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // cb_HideChar
            // 
            this.cb_HideChar.AutoSize = true;
            this.cb_HideChar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cb_HideChar.ForeColor = System.Drawing.SystemColors.Control;
            this.cb_HideChar.Location = new System.Drawing.Point(16, 277);
            this.cb_HideChar.Name = "cb_HideChar";
            this.cb_HideChar.Size = new System.Drawing.Size(101, 17);
            this.cb_HideChar.TabIndex = 14;
            this.cb_HideChar.Text = "Hide characters";
            this.cb_HideChar.UseVisualStyleBackColor = false;
            this.cb_HideChar.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pb_ShowMap
            // 
            this.pb_ShowMap.Location = new System.Drawing.Point(481, 69);
            this.pb_ShowMap.Name = "pb_ShowMap";
            this.pb_ShowMap.Size = new System.Drawing.Size(400, 400);
            this.pb_ShowMap.TabIndex = 15;
            this.pb_ShowMap.TabStop = false;
            this.pb_ShowMap.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // lbl_MapName
            // 
            this.lbl_MapName.AutoSize = true;
            this.lbl_MapName.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_MapName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MapName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_MapName.Location = new System.Drawing.Point(478, 16);
            this.lbl_MapName.Name = "lbl_MapName";
            this.lbl_MapName.Size = new System.Drawing.Size(104, 20);
            this.lbl_MapName.TabIndex = 16;
            this.lbl_MapName.Text = "<Map Name>";
            this.lbl_MapName.Click += new System.EventHandler(this.label4_Click);
            // 
            // Create_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.lbl_MapName);
            this.Controls.Add(this.pb_ShowMap);
            this.Controls.Add(this.cb_HideChar);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.lbl_Map);
            this.Controls.Add(this.rb_MapTwo);
            this.Controls.Add(this.rb_MapOne);
            this.Controls.Add(this.tb_ServerName);
            this.Controls.Add(this.lbl_ServerName);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_CreateGame);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Create_Game";
            this.Text = "Create_Game";
            this.Load += new System.EventHandler(this.Create_Game_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ShowMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_CreateGame;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_ServerName;
        private System.Windows.Forms.TextBox tb_ServerName;
        private System.Windows.Forms.RadioButton rb_MapOne;
        private System.Windows.Forms.RadioButton rb_MapTwo;
        private System.Windows.Forms.Label lbl_Map;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.CheckBox cb_HideChar;
        private System.Windows.Forms.PictureBox pb_ShowMap;
        private System.Windows.Forms.Label lbl_MapName;
    }
}