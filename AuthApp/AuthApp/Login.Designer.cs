namespace AuthApp
{
    partial class Login
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
            components = new System.ComponentModel.Container();
            txbUsername = new TextBox();
            txbPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnLogin = new Button();
            progressBar1 = new ProgressBar();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // txbUsername
            // 
            txbUsername.Location = new Point(12, 34);
            txbUsername.Name = "txbUsername";
            txbUsername.Size = new Size(290, 23);
            txbUsername.TabIndex = 0;
            txbUsername.Text = "admin";
            // 
            // txbPassword
            // 
            txbPassword.Location = new Point(12, 92);
            txbPassword.Name = "txbPassword";
            txbPassword.Size = new Size(290, 23);
            txbPassword.TabIndex = 1;
            txbPassword.Text = "adminadmin";
            txbPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(69, 17);
            label1.TabIndex = 2;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 72);
            label2.Name = "label2";
            label2.Size = new Size(66, 17);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(12, 130);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 63);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(290, 23);
            progressBar1.Step = 50;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 5;
            progressBar1.Visible = false;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Login
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 165);
            Controls.Add(progressBar1);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txbPassword);
            Controls.Add(txbUsername);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbUsername;
        private TextBox txbPassword;
        private Label label1;
        private Label label2;
        private Button btnLogin;
        private ProgressBar progressBar1;
        private ErrorProvider errorProvider1;
    }
}