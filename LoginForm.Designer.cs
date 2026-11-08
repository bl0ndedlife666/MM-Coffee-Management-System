namespace CoffeeManagementSystem
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblBEANS = new Label();
            pnlBranding = new Panel();
            lblTagline = new Label();
            label1 = new Label();
            lblUser = new Label();
            txtUsername = new TextBox();
            lblPass = new Label();
            txtPassword = new TextBox();
            label2 = new Label();
            btnLogin = new Button();
            btnExit = new Button();
            pnlBranding.SuspendLayout();
            SuspendLayout();
            // 
            // lblBEANS
            // 
            lblBEANS.AutoSize = true;
            lblBEANS.BackColor = Color.Transparent;
            lblBEANS.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBEANS.ForeColor = Color.White;
            lblBEANS.Location = new Point(44, 77);
            lblBEANS.Name = "lblBEANS";
            lblBEANS.Size = new Size(185, 65);
            lblBEANS.TabIndex = 0;
            lblBEANS.Text = "BEANS";
            // 
            // pnlBranding
            // 
            pnlBranding.BackColor = Color.FromArgb(30, 41, 59);
            pnlBranding.Controls.Add(lblTagline);
            pnlBranding.Controls.Add(lblBEANS);
            pnlBranding.Location = new Point(2, 1);
            pnlBranding.Name = "pnlBranding";
            pnlBranding.Size = new Size(292, 418);
            pnlBranding.TabIndex = 1;
            // 
            // lblTagline
            // 
            lblTagline.AutoSize = true;
            lblTagline.BackColor = Color.Transparent;
            lblTagline.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTagline.ForeColor = Color.FromArgb(168, 180, 199);
            lblTagline.Location = new Point(62, 156);
            lblTagline.Name = "lblTagline";
            lblTagline.Size = new Size(153, 30);
            lblTagline.TabIndex = 2;
            lblTagline.Text = "Coffee Shop Management\nand Analytics System";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(402, 55);
            label1.Name = "label1";
            label1.Size = new Size(123, 25);
            label1.TabIndex = 2;
            label1.Text = "User Login";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUser.Location = new Point(402, 108);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(66, 14);
            lblUser.TabIndex = 3;
            lblUser.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(395, 125);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(291, 33);
            txtUsername.TabIndex = 4;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPass.Location = new Point(402, 188);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(66, 14);
            lblPass.TabIndex = 5;
            lblPass.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(395, 205);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Enter your password";
            txtPassword.Size = new Size(291, 33);
            txtPassword.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(395, 78);
            label2.Name = "label2";
            label2.Size = new Size(174, 14);
            label2.TabIndex = 7;
            label2.Text = "Sign in to access your account";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(40, 99, 233);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(393, 283);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(92, 41);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "Sign In";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(185, 74, 72);
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = SystemColors.Window;
            btnExit.Location = new Point(594, 283);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(92, 41);
            btnExit.TabIndex = 9;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 240, 231);
            ClientSize = new Size(800, 420);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(txtPassword);
            Controls.Add(lblPass);
            Controls.Add(txtUsername);
            Controls.Add(lblUser);
            Controls.Add(label1);
            Controls.Add(pnlBranding);
            Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Coffee Management System-Login";
            pnlBranding.ResumeLayout(false);
            pnlBranding.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBEANS;
        private Panel pnlBranding;
        private Label lblTagline;
        private Label label1;
        private Label lblUser;
        private TextBox txtUsername;
        private Label lblPass;
        private TextBox txtPassword;
        private Label label2;
        private Button btnLogin;
        private Button btnExit;
    }
}
