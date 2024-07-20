namespace AuthApp
{
    partial class AddNewUser
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
            label1 = new Label();
            txbUsername = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txbPassword = new TextBox();
            label4 = new Label();
            txbConfirmPassword = new TextBox();
            label5 = new Label();
            txbName = new TextBox();
            btnAdd = new Button();
            dtgvPermissionGroup = new DataGridView();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgvPermissionGroup).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(97, 21);
            label1.TabIndex = 0;
            label1.Text = "Information";
            // 
            // txbUsername
            // 
            txbUsername.Location = new Point(12, 72);
            txbUsername.MaxLength = 50;
            txbUsername.Name = "txbUsername";
            txbUsername.Size = new Size(188, 23);
            txbUsername.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 54);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 2;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 112);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 4;
            label3.Text = "Password:";
            // 
            // txbPassword
            // 
            txbPassword.Location = new Point(12, 130);
            txbPassword.MaxLength = 50;
            txbPassword.Name = "txbPassword";
            txbPassword.Size = new Size(188, 23);
            txbPassword.TabIndex = 3;
            txbPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 172);
            label4.Name = "label4";
            label4.Size = new Size(107, 15);
            label4.TabIndex = 6;
            label4.Text = "Confirm password:";
            // 
            // txbConfirmPassword
            // 
            txbConfirmPassword.Location = new Point(12, 190);
            txbConfirmPassword.MaxLength = 50;
            txbConfirmPassword.Name = "txbConfirmPassword";
            txbConfirmPassword.Size = new Size(188, 23);
            txbConfirmPassword.TabIndex = 5;
            txbConfirmPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 235);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 8;
            label5.Text = "Name:";
            // 
            // txbName
            // 
            txbName.Location = new Point(12, 253);
            txbName.MaxLength = 50;
            txbName.Name = "txbName";
            txbName.Size = new Size(188, 23);
            txbName.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.Location = new Point(12, 291);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dtgvPermissionGroup
            // 
            dtgvPermissionGroup.AllowUserToAddRows = false;
            dtgvPermissionGroup.AllowUserToDeleteRows = false;
            dtgvPermissionGroup.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvPermissionGroup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvPermissionGroup.Location = new Point(246, 72);
            dtgvPermissionGroup.Name = "dtgvPermissionGroup";
            dtgvPermissionGroup.RowTemplate.Height = 25;
            dtgvPermissionGroup.Size = new Size(303, 268);
            dtgvPermissionGroup.TabIndex = 10;
            dtgvPermissionGroup.CellValueChanged += dtgvPermissionGroup_CellValueChanged;
            dtgvPermissionGroup.CurrentCellDirtyStateChanged += dtgvPermissionGroup_CurrentCellDirtyStateChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(243, 19);
            label6.Name = "label6";
            label6.Size = new Size(56, 21);
            label6.TabIndex = 11;
            label6.Text = "Group";
            // 
            // AddNewUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 352);
            Controls.Add(label6);
            Controls.Add(dtgvPermissionGroup);
            Controls.Add(btnAdd);
            Controls.Add(label5);
            Controls.Add(txbName);
            Controls.Add(label4);
            Controls.Add(txbConfirmPassword);
            Controls.Add(label3);
            Controls.Add(txbPassword);
            Controls.Add(label2);
            Controls.Add(txbUsername);
            Controls.Add(label1);
            Name = "AddNewUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New User";
            ((System.ComponentModel.ISupportInitialize)dtgvPermissionGroup).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txbUsername;
        private Label label2;
        private Label label3;
        private TextBox txbPassword;
        private Label label4;
        private TextBox txbConfirmPassword;
        private Label label5;
        private TextBox txbName;
        private Button btnAdd;
        private DataGridView dtgvPermissionGroup;
        private Label label6;
    }
}