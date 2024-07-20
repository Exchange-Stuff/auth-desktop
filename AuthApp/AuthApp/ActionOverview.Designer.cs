namespace AuthApp
{
    partial class ActionOverview
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
            dtgvAction = new DataGridView();
            btnAdd = new Button();
            txbSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dtgvAction).BeginInit();
            SuspendLayout();
            // 
            // dtgvAction
            // 
            dtgvAction.AllowUserToAddRows = false;
            dtgvAction.AllowUserToDeleteRows = false;
            dtgvAction.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvAction.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvAction.Location = new Point(7, 39);
            dtgvAction.Name = "dtgvAction";
            dtgvAction.ReadOnly = true;
            dtgvAction.Size = new Size(374, 267);
            dtgvAction.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(7, 312);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add new..";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txbSearch
            // 
            txbSearch.Location = new Point(7, 10);
            txbSearch.Name = "txbSearch";
            txbSearch.Size = new Size(374, 23);
            txbSearch.TabIndex = 2;
            // 
            // ActionOverview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 347);
            Controls.Add(txbSearch);
            Controls.Add(btnAdd);
            Controls.Add(dtgvAction);
            Name = "ActionOverview";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Action Overview";
            ((System.ComponentModel.ISupportInitialize)dtgvAction).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtgvAction;
        private Button btnAdd;
        private TextBox txbSearch;
    }
}