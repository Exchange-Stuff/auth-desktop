namespace AuthApp
{
    partial class UserOverview
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
            txbSearch = new TextBox();
            btnChange = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgvUser).BeginInit();
            SuspendLayout();
            // 
            // dtgvUser
            // 
            dtgvUser.AllowUserToAddRows = false;
            dtgvUser.AllowUserToDeleteRows = false;
            dtgvUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvUser.Location = new Point(4, 42);
            dtgvUser.MultiSelect = false;
            dtgvUser.Name = "dtgvUser";
            dtgvUser.ReadOnly = true;
            dtgvUser.Size = new Size(561, 308);
            dtgvUser.TabIndex = 0;
            // 
            // txbSearch
            // 
            txbSearch.Location = new Point(4, 12);
            txbSearch.Name = "txbSearch";
            txbSearch.Size = new Size(187, 23);
            txbSearch.TabIndex = 2;
            txbSearch.TextChanged += txbSearch_TextChanged;
            // 
            // btnChange
            // 
            btnChange.Location = new Point(4, 359);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(75, 23);
            btnChange.TabIndex = 3;
            btnChange.Text = "More..";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // UserOverview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 398);
            Controls.Add(btnChange);
            Controls.Add(txbSearch);
            Controls.Add(dtgvUser);
            Name = "UserOverview";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User Overview";
            ((System.ComponentModel.ISupportInitialize)dtgvUser).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtgvUser;
        private TextBox txbSearch;
        private Button btnChange;
    }
}