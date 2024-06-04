namespace AuthApp
{
    partial class AddUserToGroup
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
            dtgvUser = new DataGridView();
            txtSearchUser = new TextBox();
            btnAddUser = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgvUser).BeginInit();
            SuspendLayout();
            // 
            // dtgvUser
            // 
            dtgvUser.AllowUserToAddRows = false;
            dtgvUser.AllowUserToDeleteRows = false;
            dtgvUser.AllowUserToResizeColumns = false;
            dtgvUser.AllowUserToResizeRows = false;
            dtgvUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvUser.Location = new Point(5, 34);
            dtgvUser.MultiSelect = false;
            dtgvUser.Name = "dtgvUser";
            dtgvUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvUser.Size = new Size(616, 215);
            dtgvUser.TabIndex = 0;
            dtgvUser.CellValueChanged += dtgvUser_CellValueChanged;
            dtgvUser.CurrentCellDirtyStateChanged += dtgvUser_CurrentCellDirtyStateChanged;
            // 
            // txtSearchUser
            // 
            txtSearchUser.Location = new Point(5, 5);
            txtSearchUser.Name = "txtSearchUser";
            txtSearchUser.Size = new Size(171, 23);
            txtSearchUser.TabIndex = 1;
            txtSearchUser.TextChanged += txtSearchUser_TextChanged;
            // 
            // btnAddUser
            // 
            btnAddUser.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddUser.Location = new Point(5, 256);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(75, 23);
            btnAddUser.TabIndex = 2;
            btnAddUser.Text = "Add";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // AddUserToGroup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(626, 291);
            Controls.Add(btnAddUser);
            Controls.Add(txtSearchUser);
            Controls.Add(dtgvUser);
            Name = "AddUserToGroup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add User";
            ((System.ComponentModel.ISupportInitialize)dtgvUser).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtgvUser;
        private TextBox txtSearchUser;
        private Button btnAddUser;
    }
}