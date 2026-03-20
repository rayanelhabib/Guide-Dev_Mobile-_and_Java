namespace passage_1dai
{
    partial class login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBx_Username = new System.Windows.Forms.TextBox();
            this.txtBx_Password = new System.Windows.Forms.TextBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.lkLbl_Inscription = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // txtBx_Username
            // 
            this.txtBx_Username.Location = new System.Drawing.Point(212, 134);
            this.txtBx_Username.Name = "txtBx_Username";
            this.txtBx_Username.Size = new System.Drawing.Size(100, 20);
            this.txtBx_Username.TabIndex = 3;
            // 
            // txtBx_Password
            // 
            this.txtBx_Password.Location = new System.Drawing.Point(212, 204);
            this.txtBx_Password.Name = "txtBx_Password";
            this.txtBx_Password.Size = new System.Drawing.Size(100, 20);
            this.txtBx_Password.TabIndex = 4;
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(212, 273);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(100, 23);
            this.btn_Login.TabIndex = 5;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            // 
            // lkLbl_Inscription
            // 
            this.lkLbl_Inscription.AutoSize = true;
            this.lkLbl_Inscription.Location = new System.Drawing.Point(209, 340);
            this.lkLbl_Inscription.Name = "lkLbl_Inscription";
            this.lkLbl_Inscription.Size = new System.Drawing.Size(55, 13);
            this.lkLbl_Inscription.TabIndex = 6;
            this.lkLbl_Inscription.TabStop = true;
            this.lkLbl_Inscription.Text = "Inscription";
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 429);
            this.Controls.Add(this.lkLbl_Inscription);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.txtBx_Password);
            this.Controls.Add(this.txtBx_Username);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "login";
            this.Text = "login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBx_Username;
        private System.Windows.Forms.TextBox txtBx_Password;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.LinkLabel lkLbl_Inscription;
    }
}