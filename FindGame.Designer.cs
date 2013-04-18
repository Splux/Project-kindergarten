namespace Project_kindergarten
{
    partial class FindGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindGame));
            this.lb_Serverlist = new System.Windows.Forms.ListBox();
            this.pb_Back = new System.Windows.Forms.PictureBox();
            this._btnDesign = new System.Windows.Forms.Button();
            this.btn_joinGame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Back)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_Serverlist
            // 
            this.lb_Serverlist.FormattingEnabled = true;
            this.lb_Serverlist.Location = new System.Drawing.Point(405, 101);
            this.lb_Serverlist.Name = "lb_Serverlist";
            this.lb_Serverlist.Size = new System.Drawing.Size(552, 355);
            this.lb_Serverlist.TabIndex = 5;
            // 
            // pb_Back
            // 
            this.pb_Back.Location = new System.Drawing.Point(12, 561);
            this.pb_Back.Name = "pb_Back";
            this.pb_Back.Size = new System.Drawing.Size(216, 116);
            this.pb_Back.TabIndex = 6;
            this.pb_Back.TabStop = false;
            this.pb_Back.Click += new System.EventHandler(this.pb_Back_Click);
            // 
            // _btnDesign
            // 
            this._btnDesign.Location = new System.Drawing.Point(527, 54);
            this._btnDesign.Name = "_btnDesign";
            this._btnDesign.Size = new System.Drawing.Size(265, 41);
            this._btnDesign.TabIndex = 7;
            this._btnDesign.Text = "Refresh";
            this._btnDesign.UseVisualStyleBackColor = true;
            this._btnDesign.Click += new System.EventHandler(this.refreshServerList);
            // 
            // btn_joinGame
            // 
            this.btn_joinGame.Location = new System.Drawing.Point(672, 462);
            this.btn_joinGame.Name = "btn_joinGame";
            this.btn_joinGame.Size = new System.Drawing.Size(285, 66);
            this.btn_joinGame.TabIndex = 8;
            this.btn_joinGame.Text = "Join game";
            this.btn_joinGame.UseVisualStyleBackColor = true;
            this.btn_joinGame.Click += new System.EventHandler(this.btn_joinGame_Click);
            // 
            // FindGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1366, 780);
            this.ControlBox = false;
            this.Controls.Add(this.btn_joinGame);
            this.Controls.Add(this._btnDesign);
            this.Controls.Add(this.pb_Back);
            this.Controls.Add(this.lb_Serverlist);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FindGame";
            this.ShowIcon = false;
            this.Text = "newgame";
            this.Load += new System.EventHandler(this.newgame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Back)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_Serverlist;
        private System.Windows.Forms.PictureBox pb_Back;
        private System.Windows.Forms.Button _btnDesign;
        private System.Windows.Forms.Button btn_joinGame;
    }
}