namespace WebApiFormApp
{
    partial class LoginRegisterForm
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
            btnRegister = new Button();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            txtRegLastName = new TextBox();
            txtRegEmail = new TextBox();
            txtRegUserName = new TextBox();
            textRegPw = new TextBox();
            txtRegFirstName = new TextBox();
            pnlReg = new Panel();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnToLogin = new Button();
            pnlLogin = new Panel();
            label2 = new Label();
            label1 = new Label();
            btnToReg = new Button();
            pnlReg.SuspendLayout();
            pnlLogin.SuspendLayout();
            SuspendLayout();
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(120, 212);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 23);
            btnRegister.TabIndex = 9;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(128, 125);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(87, 96);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(162, 23);
            txtPassword.TabIndex = 30;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(87, 67);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(162, 23);
            txtEmail.TabIndex = 33;
            // 
            // txtRegLastName
            // 
            txtRegLastName.ForeColor = SystemColors.WindowText;
            txtRegLastName.Location = new Point(80, 96);
            txtRegLastName.Name = "txtRegLastName";
            txtRegLastName.Size = new Size(162, 23);
            txtRegLastName.TabIndex = 24;
            // 
            // txtRegEmail
            // 
            txtRegEmail.ForeColor = SystemColors.WindowText;
            txtRegEmail.Location = new Point(80, 154);
            txtRegEmail.Name = "txtRegEmail";
            txtRegEmail.Size = new Size(162, 23);
            txtRegEmail.TabIndex = 23;
            // 
            // txtRegUserName
            // 
            txtRegUserName.ForeColor = SystemColors.WindowText;
            txtRegUserName.Location = new Point(80, 125);
            txtRegUserName.Name = "txtRegUserName";
            txtRegUserName.Size = new Size(162, 23);
            txtRegUserName.TabIndex = 22;
            // 
            // textRegPw
            // 
            textRegPw.ForeColor = SystemColors.WindowText;
            textRegPw.Location = new Point(80, 183);
            textRegPw.Name = "textRegPw";
            textRegPw.Size = new Size(162, 23);
            textRegPw.TabIndex = 21;
            // 
            // txtRegFirstName
            // 
            txtRegFirstName.ForeColor = SystemColors.WindowText;
            txtRegFirstName.Location = new Point(80, 67);
            txtRegFirstName.Name = "txtRegFirstName";
            txtRegFirstName.Size = new Size(162, 23);
            txtRegFirstName.TabIndex = 26;
            // 
            // pnlReg
            // 
            pnlReg.Controls.Add(label7);
            pnlReg.Controls.Add(label6);
            pnlReg.Controls.Add(label5);
            pnlReg.Controls.Add(label3);
            pnlReg.Controls.Add(label4);
            pnlReg.Controls.Add(btnToLogin);
            pnlReg.Controls.Add(txtRegFirstName);
            pnlReg.Controls.Add(btnRegister);
            pnlReg.Controls.Add(textRegPw);
            pnlReg.Controls.Add(txtRegLastName);
            pnlReg.Controls.Add(txtRegUserName);
            pnlReg.Controls.Add(txtRegEmail);
            pnlReg.Location = new Point(259, 23);
            pnlReg.Name = "pnlReg";
            pnlReg.Size = new Size(264, 288);
            pnlReg.TabIndex = 27;
            pnlReg.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(32, 162);
            label7.Name = "label7";
            label7.Size = new Size(39, 15);
            label7.TabIndex = 37;
            label7.Text = "Email:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 133);
            label6.Name = "label6";
            label6.Size = new Size(68, 15);
            label6.TabIndex = 36;
            label6.Text = "User Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 186);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 35;
            label5.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 104);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 34;
            label3.Text = "Last Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 70);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 33;
            label4.Text = "First Name:";
            // 
            // btnToLogin
            // 
            btnToLogin.Location = new Point(97, 241);
            btnToLogin.Name = "btnToLogin";
            btnToLogin.Size = new Size(122, 23);
            btnToLogin.TabIndex = 27;
            btnToLogin.Text = "To The Login Screen";
            btnToLogin.UseVisualStyleBackColor = true;
            btnToLogin.Click += btnToLogin_Click;
            // 
            // pnlLogin
            // 
            pnlLogin.Controls.Add(label2);
            pnlLogin.Controls.Add(label1);
            pnlLogin.Controls.Add(btnToReg);
            pnlLogin.Controls.Add(txtEmail);
            pnlLogin.Controls.Add(txtPassword);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Location = new Point(259, 23);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(275, 288);
            pnlLogin.TabIndex = 28;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 99);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 32;
            label2.Text = "Password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 70);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 31;
            label1.Text = "Email:";
            // 
            // btnToReg
            // 
            btnToReg.BackColor = Color.Transparent;
            btnToReg.Location = new Point(103, 153);
            btnToReg.Name = "btnToReg";
            btnToReg.Size = new Size(121, 23);
            btnToReg.TabIndex = 28;
            btnToReg.Text = "Create New User";
            btnToReg.UseVisualStyleBackColor = false;
            btnToReg.Click += btnToReg_Click;
            // 
            // LoginRegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlLogin);
            Controls.Add(pnlReg);
            Name = "LoginRegisterForm";
            Text = "LoginRegisterForm";
            pnlReg.ResumeLayout(false);
            pnlReg.PerformLayout();
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnRegister;
        private Button btnLogin;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private TextBox txtRegLastName;
        private TextBox txtRegEmail;
        private TextBox txtRegUserName;
        private TextBox textRegPw;
        private TextBox txtRegFirstName;
        private Panel pnlReg;
        private Button btnToLogin;
        private Panel pnlLogin;
        private Button btnToReg;
        private Label label2;
        private Label label1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label4;
    }
}