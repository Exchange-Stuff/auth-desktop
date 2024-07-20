namespace AuthApp
{
    partial class ChangeUserPermissionGroup
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
            dtgvPermissionGroup = new DataGridView();
            txbSearch = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnSave = new Button();
            lbId = new Label();
            lbUsername = new Label();
            lbEmail = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgvPermissionGroup).BeginInit();
            SuspendLayout();
            // 
            // dtgvPermissionGroup
            // 
            dtgvPermissionGroup.AllowUserToAddRows = false;
            dtgvPermissionGroup.AllowUserToDeleteRows = false;
            dtgvPermissionGroup.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvPermissionGroup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvPermissionGroup.Location = new Point(4, 40);
            dtgvPermissionGroup.Name = "dtgvPermissionGroup";
            dtgvPermissionGroup.Size = new Size(442, 269);
            dtgvPermissionGroup.TabIndex = 0;
            dtgvPermissionGroup.CellValueChanged += dtgvPermissionGroup_CellValueChanged;
            dtgvPermissionGroup.CurrentCellDirtyStateChanged += dtgvPermissionGroup_CurrentCellDirtyStateChanged;
            // 
            // txbSearch
            // 
            txbSearch.Location = new Point(4, 11);
            txbSearch.Name = "txbSearch";
            txbSearch.Size = new Size(187, 23);
            txbSearch.TabIndex = 1;
            txbSearch.TextChanged += txbSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(459, 9);
            label1.Name = "label1";
            label1.Size = new Size(111, 25);
            label1.TabIndex = 2;
            label1.Text = "Information";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(461, 50);
            label2.Name = "label2";
            label2.Size = new Size(22, 17);
            label2.TabIndex = 3;
            label2.Text = "Id:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(461, 89);
            label3.Name = "label3";
            label3.Size = new Size(70, 17);
            label3.TabIndex = 4;
            label3.Text = "Username:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(461, 132);
            label4.Name = "label4";
            label4.Size = new Size(42, 17);
            label4.TabIndex = 5;
            label4.Text = "Email:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(4, 318);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbId.Location = new Point(489, 48);
            lbId.Name = "lbId";
            lbId.Size = new Size(47, 19);
            lbId.TabIndex = 7;
            lbId.Text = "label5";
            // 
            // lbUsername
            // 
            lbUsername.AutoSize = true;
            lbUsername.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbUsername.Location = new Point(537, 89);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(47, 19);
            lbUsername.TabIndex = 8;
            lbUsername.Text = "label6";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbEmail.Location = new Point(511, 132);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(47, 19);
            lbEmail.TabIndex = 9;
            lbEmail.Text = "label7";
            // 
            // ChangeUserPermissionGroup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 352);
            Controls.Add(lbEmail);
            Controls.Add(lbUsername);
            Controls.Add(lbId);
            Controls.Add(btnSave);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txbSearch);
            Controls.Add(dtgvPermissionGroup);
            Name = "ChangeUserPermissionGroup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Change Permission Group";
            FormClosing += ChangeUserPermissionGroup_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dtgvPermissionGroup).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtgvPermissionGroup;
        private TextBox txbSearch;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnSave;
        public Label lbId;
        public Label lbUsername;
        public Label lbEmail;
    }
}