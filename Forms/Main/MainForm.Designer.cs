namespace WebApiFormApp
{
    partial class MainForm
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
            dgvUsers = new DataGridView();
            btnUserUpdate = new Button();
            txtLastName = new TextBox();
            txtID = new TextBox();
            txtFirstName = new TextBox();
            txtUserName = new TextBox();
            btnDelete = new Button();
            txtRole = new TextBox();
            btnAddRoleToUser = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(122, 25);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.Size = new Size(537, 173);
            dgvUsers.TabIndex = 0;
            // 
            // btnUserUpdate
            // 
            btnUserUpdate.Location = new Point(12, 325);
            btnUserUpdate.Name = "btnUserUpdate";
            btnUserUpdate.Size = new Size(75, 23);
            btnUserUpdate.TabIndex = 1;
            btnUserUpdate.Text = "Update";
            btnUserUpdate.UseVisualStyleBackColor = true;
            // 
            // txtLastName
            // 
            txtLastName.ForeColor = SystemColors.InfoText;
            txtLastName.Location = new Point(12, 267);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(162, 23);
            txtLastName.TabIndex = 22;
            txtLastName.Text = "LastName";
            // 
            // txtID
            // 
            txtID.ForeColor = SystemColors.InfoText;
            txtID.Location = new Point(12, 238);
            txtID.Name = "txtID";
            txtID.Size = new Size(162, 23);
            txtID.TabIndex = 20;
            txtID.Text = "ID";
            // 
            // txtFirstName
            // 
            txtFirstName.ForeColor = SystemColors.InfoText;
            txtFirstName.Location = new Point(12, 296);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(162, 23);
            txtFirstName.TabIndex = 18;
            txtFirstName.Text = "FirstName";
            // 
            // txtUserName
            // 
            txtUserName.ForeColor = SystemColors.InfoText;
            txtUserName.Location = new Point(180, 237);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(162, 23);
            txtUserName.TabIndex = 24;
            txtUserName.Text = "UserName";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(180, 266);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 23;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // txtRole
            // 
            txtRole.ForeColor = SystemColors.InfoText;
            txtRole.Location = new Point(348, 238);
            txtRole.Name = "txtRole";
            txtRole.Size = new Size(162, 23);
            txtRole.TabIndex = 26;
            txtRole.Text = "RoleName";
            // 
            // btnAddRoleToUser
            // 
            btnAddRoleToUser.Location = new Point(348, 267);
            btnAddRoleToUser.Name = "btnAddRoleToUser";
            btnAddRoleToUser.Size = new Size(75, 23);
            btnAddRoleToUser.TabIndex = 25;
            btnAddRoleToUser.Text = "Add Role";
            btnAddRoleToUser.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtRole);
            Controls.Add(btnAddRoleToUser);
            Controls.Add(txtUserName);
            Controls.Add(btnDelete);
            Controls.Add(txtLastName);
            Controls.Add(txtID);
            Controls.Add(txtFirstName);
            Controls.Add(btnUserUpdate);
            Controls.Add(dgvUsers);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvUsers;
        private Button btnUserUpdate;
        private TextBox txtLastName;
        private TextBox txtEmail;
        private TextBox txtID;
        private TextBox txtPassword;
        private TextBox txtFirstName;
        private TextBox txtUserName;
        private Button btnDelete;
        private TextBox txtRole;
        private Button btnAddRoleToUser;
    }
}
