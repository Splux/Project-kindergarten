namespace Project_kindergarten
{
    partial class VerifyUser
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
            this.btn_Send = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.tb_Verification = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(12, 76);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(137, 41);
            this.btn_Send.TabIndex = 1;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(155, 76);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(117, 41);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            // 
            // tb_Verification
            // 
            this.tb_Verification.Location = new System.Drawing.Point(12, 50);
            this.tb_Verification.MaxLength = 10;
            this.tb_Verification.Name = "tb_Verification";
            this.tb_Verification.Size = new System.Drawing.Size(260, 20);
            this.tb_Verification.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter verification code:";
            // 
            // VerifyUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 129);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Verification);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Send);
            this.Name = "VerifyUser";
            this.Text = "User verification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.TextBox tb_Verification;
        private System.Windows.Forms.Label label1;
    }
}