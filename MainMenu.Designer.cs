namespace Project_kindergarten
{
    partial class MainMenu
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
            this.pb_Background = new System.Windows.Forms.PictureBox();
            this.pb_FindGame = new System.Windows.Forms.PictureBox();
            this.pb_CreateGame = new System.Windows.Forms.PictureBox();
            this.pb_Options = new System.Windows.Forms.PictureBox();
            this.pb_Exit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_FindGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_CreateGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Options)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Exit)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_Background
            // 
            this.pb_Background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Background.Location = new System.Drawing.Point(0, 0);
            this.pb_Background.Name = "pb_Background";
            this.pb_Background.Size = new System.Drawing.Size(1366, 780);
            this.pb_Background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Background.TabIndex = 0;
            this.pb_Background.TabStop = false;
            this.pb_Background.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pb_FindGame
            // 
            this.pb_FindGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_FindGame.Location = new System.Drawing.Point(68, 55);
            this.pb_FindGame.Name = "pb_FindGame";
            this.pb_FindGame.Size = new System.Drawing.Size(252, 134);
            this.pb_FindGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_FindGame.TabIndex = 1;
            this.pb_FindGame.TabStop = false;
            this.pb_FindGame.Click += new System.EventHandler(this.pb_FindGame_Click);
            // 
            // pb_CreateGame
            // 
            this.pb_CreateGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_CreateGame.Location = new System.Drawing.Point(68, 236);
            this.pb_CreateGame.Name = "pb_CreateGame";
            this.pb_CreateGame.Size = new System.Drawing.Size(252, 134);
            this.pb_CreateGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_CreateGame.TabIndex = 2;
            this.pb_CreateGame.TabStop = false;
            this.pb_CreateGame.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pb_Options
            // 
            this.pb_Options.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_Options.Location = new System.Drawing.Point(68, 417);
            this.pb_Options.Name = "pb_Options";
            this.pb_Options.Size = new System.Drawing.Size(252, 134);
            this.pb_Options.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Options.TabIndex = 3;
            this.pb_Options.TabStop = false;
            this.pb_Options.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pb_Exit
            // 
            this.pb_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_Exit.Location = new System.Drawing.Point(68, 595);
            this.pb_Exit.Name = "pb_Exit";
            this.pb_Exit.Size = new System.Drawing.Size(252, 134);
            this.pb_Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Exit.TabIndex = 4;
            this.pb_Exit.TabStop = false;
            this.pb_Exit.Click += new System.EventHandler(this.pb_Exit_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(1366, 780);
            this.ControlBox = false;
            this.Controls.Add(this.pb_Exit);
            this.Controls.Add(this.pb_Options);
            this.Controls.Add(this.pb_CreateGame);
            this.Controls.Add(this.pb_FindGame);
            this.Controls.Add(this.pb_Background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainMenu";
            this.ShowIcon = false;
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.handleKeypress);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Background)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_FindGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_CreateGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Options)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Exit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Background;
        private System.Windows.Forms.PictureBox pb_FindGame;
        private System.Windows.Forms.PictureBox pb_CreateGame;
        private System.Windows.Forms.PictureBox pb_Options;
        private System.Windows.Forms.PictureBox pb_Exit;
    }
}