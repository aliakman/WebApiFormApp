namespace WebApiFormApp
{
    partial class RegisterForm
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
            lblStatus = new Label();
            txtLastName = new TextBox();
            txtEmail = new TextBox();
            txtUserName = new TextBox();
            txtPassword = new TextBox();
            txtFirstName = new TextBox();
            btnSubmit = new Button();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.ForeColor = Color.FromArgb(192, 0, 0);
            lblStatus.Location = new Point(291, 78);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(170, 23);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Lütfen tüm alanları doldurun!";
            // 
            // txtLastName
            // 
            txtLastName.ForeColor = SystemColors.InfoText;
            txtLastName.Location = new Point(291, 133);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(162, 23);
            txtLastName.TabIndex = 16;
            txtLastName.Text = "LastName";
            // 
            // txtEmail
            // 
            txtEmail.ForeColor = SystemColors.InfoText;
            txtEmail.Location = new Point(291, 191);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(162, 23);
            txtEmail.TabIndex = 15;
            txtEmail.Text = "Email";
            // 
            // txtUserName
            // 
            txtUserName.ForeColor = SystemColors.InfoText;
            txtUserName.Location = new Point(291, 162);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(162, 23);
            txtUserName.TabIndex = 14;
            txtUserName.Text = "UserName";
            // 
            // txtPassword
            // 
            txtPassword.ForeColor = SystemColors.InfoText;
            txtPassword.Location = new Point(291, 220);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(162, 23);
            txtPassword.TabIndex = 13;
            txtPassword.Text = "Password";
            // 
            // txtFirstName
            // 
            txtFirstName.ForeColor = SystemColors.InfoText;
            txtFirstName.Location = new Point(291, 104);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(162, 23);
            txtFirstName.TabIndex = 12;
            txtFirstName.Text = "FirstName";
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(291, 262);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(75, 23);
            btnSubmit.TabIndex = 18;
            btnSubmit.Text = "Submit";
            btnSubmit.Click += btnSubmit_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblStatus);
            Controls.Add(txtLastName);
            Controls.Add(txtEmail);
            Controls.Add(txtUserName);
            Controls.Add(txtPassword);
            Controls.Add(txtFirstName);
            Controls.Add(btnSubmit);
            Name = "RegisterForm";
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStatus;
        private TextBox txtLastName;
        private TextBox txtEmail;
        private TextBox txtUserName;
        private TextBox txtPassword;
        private TextBox txtFirstName;
        private Button btnSubmit;
    }
}