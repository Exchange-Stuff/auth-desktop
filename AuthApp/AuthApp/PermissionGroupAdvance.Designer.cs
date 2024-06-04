namespace AuthApp
{
    partial class PermissionGroupAdvance
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
            btnSave = new Button();
            txbSearchResource = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dtgvPermissions).BeginInit();
            SuspendLayout();
            // 
            // dtgvPermissions
            // 
            dtgvPermissions.AllowUserToAddRows = false;
            dtgvPermissions.AllowUserToDeleteRows = false;
            dtgvPermissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvPermissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvPermissions.Location = new Point(6, 5);
            dtgvPermissions.Name = "dtgvPermissions";
            dtgvPermissions.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dtgvPermissions.Size = new Size(545, 273);
            dtgvPermissions.TabIndex = 0;
            dtgvPermissions.CellValueChanged += dtgvPermissions_CellValueChanged;
            dtgvPermissions.CurrentCellDirtyStateChanged += dtgvPermissions_CurrentCellDirtyStateChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(476, 284);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txbSearchResource
            // 
            txbSearchResource.Location = new Point(6, 284);
            txbSearchResource.Name = "txbSearchResource";
            txbSearchResource.Size = new Size(135, 23);
            txbSearchResource.TabIndex = 2;
            txbSearchResource.TextChanged += txbSearchResource_TextChanged;
            // 
            // PermissionGroupAdvance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(556, 324);
            Controls.Add(txbSearchResource);
            Controls.Add(btnSave);
            Controls.Add(dtgvPermissions);
            Name = "PermissionGroupAdvance";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Permission Group Advance";
            FormClosing += PermissionGroupAdvance_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dtgvPermissions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtgvPermissions;
        private Button btnSave;
        private TextBox txbSearchResource;
    }
}