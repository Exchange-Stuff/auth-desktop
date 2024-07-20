namespace AuthApp
{
    partial class AddAction
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
            txbActionName = new TextBox();
            label1 = new Label();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // txbActionName
            // 
            txbActionName.Location = new Point(12, 36);
            txbActionName.Name = "txbActionName";
            txbActionName.Size = new Size(213, 23);
            txbActionName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 1;
            label1.Text = "Action name:";
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(150, 71);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // AddAction
            // 
            AcceptButton = btnAdd;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(237, 106);
            Controls.Add(btnAdd);
            Controls.Add(label1);
            Controls.Add(txbActionName);
            Name = "AddAction";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Action";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbActionName;
        private Label label1;
        private Button btnAdd;
    }
}