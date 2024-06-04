namespace AuthApp
{
    partial class AddPermissionGroup
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
            dtgvPermissions = new DataGridView();
            btnAddUser = new Button();
            btnFinish = new Button();
            txbSearch = new TextBox();
            dtgvUser = new DataGridView();
            btnRemoveUser = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgvPermissions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgvUser).BeginInit();
            SuspendLayout();
            // 
            // dtgvPermissions
            // 
            dtgvPermissions.AllowUserToAddRows = false;
            dtgvPermissions.AllowUserToDeleteRows = false;
            dtgvPermissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvPermissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvPermissions.Location = new Point(5, 34);
            dtgvPermissions.Name = "dtgvPermissions";
            dtgvPermissions.Size = new Size(586, 278);
            dtgvPermissions.TabIndex = 0;
            dtgvPermissions.CellValueChanged += dtgvPermissions_CellValueChanged;
            dtgvPermissions.CurrentCellDirtyStateChanged += dtgvPermissions_CurrentCellDirtyStateChanged;
            // 
            // btnAddUser
            // 
            btnAddUser.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddUser.Location = new Point(780, 5);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(75, 23);
            btnAddUser.TabIndex = 1;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnFinish
            // 
            btnFinish.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFinish.Location = new Point(5, 318);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new Size(113, 30);
            btnFinish.TabIndex = 2;
            btnFinish.Text = "Finish";
            btnFinish.UseVisualStyleBackColor = true;
            btnFinish.Click += btnFinish_Click;
            // 
            // txbSearch
            // 
            txbSearch.Location = new Point(5, 5);
            txbSearch.Name = "txbSearch";
            txbSearch.Size = new Size(147, 23);
            txbSearch.TabIndex = 3;
            txbSearch.TextChanged += txbSearch_TextChanged;
            // 
            // dtgvUser
            // 
            dtgvUser.AllowUserToAddRows = false;
            dtgvUser.AllowUserToDeleteRows = false;
            dtgvUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvUser.Location = new Point(597, 33);
            dtgvUser.Name = "dtgvUser";
            dtgvUser.ReadOnly = true;
            dtgvUser.Size = new Size(258, 279);
            dtgvUser.TabIndex = 4;
            // 
            // btnRemoveUser
            // 
            btnRemoveUser.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemoveUser.Location = new Point(597, 318);
            btnRemoveUser.Name = "btnRemoveUser";
            btnRemoveUser.Size = new Size(98, 23);
            btnRemoveUser.TabIndex = 5;
            btnRemoveUser.Text = "Remove User";
            btnRemoveUser.UseVisualStyleBackColor = true;
            btnRemoveUser.Click += btnRemoveUser_Click;
            // 
            // AddPermissionGroup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(859, 357);
            Controls.Add(btnRemoveUser);
            Controls.Add(dtgvUser);
            Controls.Add(txbSearch);
            Controls.Add(btnFinish);
            Controls.Add(btnAddUser);
            Controls.Add(dtgvPermissions);
            Name = "AddPermissionGroup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Group";
            FormClosed += AddPermissionGroup_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dtgvPermissions).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgvUser).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtgvPermissions;
        private Button btnAddUser;
        private Button btnFinish;
        private TextBox txbSearch;
        private DataGridView dtgvUser;
        private Button btnRemoveUser;
    }
}