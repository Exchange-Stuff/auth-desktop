namespace AuthApp
{
    partial class PermissionGroupName
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
            txbName = new TextBox();
            label1 = new Label();
            btnNext = new Button();
            SuspendLayout();
            // 
            // txbName
            // 
            txbName.Location = new Point(12, 33);
            txbName.Name = "txbName";
            txbName.Size = new Size(235, 23);
            txbName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 1;
            label1.Text = "Name";
            // 
            // btnNext
            // 
            btnNext.Location = new Point(172, 71);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 23);
            btnNext.TabIndex = 2;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // PermissionGroupName
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(256, 106);
            Controls.Add(btnNext);
            Controls.Add(label1);
            Controls.Add(txbName);
            Name = "PermissionGroupName";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Group Name";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbName;
        private Label label1;
        private Button btnNext;
    }
}