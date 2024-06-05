namespace AuthApp
{
    partial class UpdatePermissionGroup
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
            dtgvPermission = new DataGridView();
            txbSearch = new TextBox();
            btnSave = new Button();
            lbPermissionGroupName = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgvPermission).BeginInit();
            SuspendLayout();
            // 
            // dtgvPermission
            // 
            dtgvPermission.AllowUserToAddRows = false;
            dtgvPermission.AllowUserToDeleteRows = false;
            dtgvPermission.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvPermission.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvPermission.Location = new Point(4, 36);
            dtgvPermission.Name = "dtgvPermission";
            dtgvPermission.Size = new Size(746, 299);
            dtgvPermission.TabIndex = 0;
            dtgvPermission.CellValueChanged += dtgvPermission_CellValueChanged;
            dtgvPermission.CurrentCellDirtyStateChanged += dtgvPermission_CurrentCellDirtyStateChanged;
            // 
            // txbSearch
            // 
            txbSearch.Location = new Point(4, 7);
            txbSearch.Name = "txbSearch";
            txbSearch.Size = new Size(150, 23);
            txbSearch.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(4, 341);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(84, 33);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lbPermissionGroupName
            // 
            lbPermissionGroupName.AutoSize = true;
            lbPermissionGroupName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbPermissionGroupName.Location = new Point(160, 15);
            lbPermissionGroupName.Name = "lbPermissionGroupName";
            lbPermissionGroupName.Size = new Size(136, 15);
            lbPermissionGroupName.TabIndex = 3;
            lbPermissionGroupName.Text = "Permission Group Name";
            // 
            // UpdatePermissionGroup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 379);
            Controls.Add(lbPermissionGroupName);
            Controls.Add(btnSave);
            Controls.Add(txbSearch);
            Controls.Add(dtgvPermission);
            Name = "UpdatePermissionGroup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Update Permission Group";
            ((System.ComponentModel.ISupportInitialize)dtgvPermission).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtgvPermission;
        private TextBox txbSearch;
        private Button btnSave;
        public Label lbPermissionGroupName;
    }
}