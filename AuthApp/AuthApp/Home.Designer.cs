namespace AuthApp
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnRefresh = new Button();
            menuStrip1 = new MenuStrip();
            groupsToolStripMenuItem = new ToolStripMenuItem();
            toolStripAddGroup = new ToolStripMenuItem();
            usersToolStripMenuItem = new ToolStripMenuItem();
            userPermissionToolStripMenuItem = new ToolStripMenuItem();
            addNewToolStripMenuItem = new ToolStripMenuItem();
            actionsToolStripMenuItem = new ToolStripMenuItem();
            mngToolStripActionMng = new ToolStripMenuItem();
            profileToolStripMenuItem = new ToolStripMenuItem();
            changePasswordToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            resourceToolStripMenuItem = new ToolStripMenuItem();
            toolScriptAddResource = new ToolStripMenuItem();
            txbSearch = new TextBox();
            label1 = new Label();
            label2 = new Label();
            dtgvPermissionGroup = new DataGridView();
            dtgvPermissions = new DataGridView();
            btnAdvance = new Button();
            btnChange = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvPermissionGroup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgvPermissions).BeginInit();
            SuspendLayout();
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnRefresh.Location = new Point(719, 36);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(69, 30);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { groupsToolStripMenuItem, usersToolStripMenuItem, actionsToolStripMenuItem, profileToolStripMenuItem, resourceToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // groupsToolStripMenuItem
            // 
            groupsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripAddGroup });
            groupsToolStripMenuItem.Name = "groupsToolStripMenuItem";
            groupsToolStripMenuItem.Size = new Size(57, 20);
            groupsToolStripMenuItem.Text = "Groups";
            // 
            // toolStripAddGroup
            // 
            toolStripAddGroup.Name = "toolStripAddGroup";
            toolStripAddGroup.Size = new Size(96, 22);
            toolStripAddGroup.Text = "Add";
            toolStripAddGroup.Click += toolStripAddGroup_Click;
            // 
            // usersToolStripMenuItem
            // 
            usersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { userPermissionToolStripMenuItem, addNewToolStripMenuItem });
            usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            usersToolStripMenuItem.Size = new Size(69, 20);
            usersToolStripMenuItem.Text = "Accounts";
            // 
            // userPermissionToolStripMenuItem
            // 
            userPermissionToolStripMenuItem.Name = "userPermissionToolStripMenuItem";
            userPermissionToolStripMenuItem.Size = new Size(180, 22);
            userPermissionToolStripMenuItem.Text = "Advance";
            userPermissionToolStripMenuItem.Click += userPermissionToolStripMenuItem_Click;
            // 
            // addNewToolStripMenuItem
            // 
            addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            addNewToolStripMenuItem.Size = new Size(180, 22);
            addNewToolStripMenuItem.Text = "Add new";
            addNewToolStripMenuItem.Click += addNewToolStripMenuItem_Click;
            // 
            // actionsToolStripMenuItem
            // 
            actionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mngToolStripActionMng });
            actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            actionsToolStripMenuItem.Size = new Size(59, 20);
            actionsToolStripMenuItem.Text = "Actions";
            // 
            // mngToolStripActionMng
            // 
            mngToolStripActionMng.Name = "mngToolStripActionMng";
            mngToolStripActionMng.Size = new Size(117, 22);
            mngToolStripActionMng.Text = "Manage";
            mngToolStripActionMng.Click += mngToolStripActionMng_Click;
            // 
            // profileToolStripMenuItem
            // 
            profileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { changePasswordToolStripMenuItem, logoutToolStripMenuItem });
            profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            profileToolStripMenuItem.Size = new Size(53, 20);
            profileToolStripMenuItem.Text = "Profile";
            // 
            // changePasswordToolStripMenuItem
            // 
            changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            changePasswordToolStripMenuItem.Size = new Size(168, 22);
            changePasswordToolStripMenuItem.Text = "Change password";
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(168, 22);
            logoutToolStripMenuItem.Text = "Logout";
            // 
            // resourceToolStripMenuItem
            // 
            resourceToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolScriptAddResource });
            resourceToolStripMenuItem.Name = "resourceToolStripMenuItem";
            resourceToolStripMenuItem.Size = new Size(67, 20);
            resourceToolStripMenuItem.Text = "Resource";
            // 
            // toolScriptAddResource
            // 
            toolScriptAddResource.Name = "toolScriptAddResource";
            toolScriptAddResource.Size = new Size(96, 22);
            toolScriptAddResource.Text = "Add";
            toolScriptAddResource.Click += toolScriptAddResource_Click;
            // 
            // txbSearch
            // 
            txbSearch.Location = new Point(12, 342);
            txbSearch.Name = "txbSearch";
            txbSearch.Size = new Size(168, 23);
            txbSearch.TabIndex = 5;
            txbSearch.TextChanged += txbSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 36);
            label1.Name = "label1";
            label1.Size = new Size(168, 25);
            label1.TabIndex = 6;
            label1.Text = "Permission groups";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(332, 36);
            label2.Name = "label2";
            label2.Size = new Size(112, 25);
            label2.TabIndex = 7;
            label2.Text = "Permissions";
            // 
            // dtgvPermissionGroup
            // 
            dtgvPermissionGroup.AllowUserToAddRows = false;
            dtgvPermissionGroup.AllowUserToDeleteRows = false;
            dtgvPermissionGroup.AllowUserToResizeColumns = false;
            dtgvPermissionGroup.AllowUserToResizeRows = false;
            dtgvPermissionGroup.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvPermissionGroup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvPermissionGroup.Location = new Point(12, 72);
            dtgvPermissionGroup.MultiSelect = false;
            dtgvPermissionGroup.Name = "dtgvPermissionGroup";
            dtgvPermissionGroup.ReadOnly = true;
            dtgvPermissionGroup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvPermissionGroup.Size = new Size(314, 264);
            dtgvPermissionGroup.TabIndex = 8;
            dtgvPermissionGroup.SelectionChanged += dtgvPermissionGroup_SelectionChanged;
            // 
            // dtgvPermissions
            // 
            dtgvPermissions.AllowUserToAddRows = false;
            dtgvPermissions.AllowUserToDeleteRows = false;
            dtgvPermissions.AllowUserToResizeColumns = false;
            dtgvPermissions.AllowUserToResizeRows = false;
            dtgvPermissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvPermissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvPermissions.Location = new Point(332, 72);
            dtgvPermissions.Name = "dtgvPermissions";
            dtgvPermissions.ReadOnly = true;
            dtgvPermissions.Size = new Size(456, 264);
            dtgvPermissions.TabIndex = 9;
            // 
            // btnAdvance
            // 
            btnAdvance.Location = new Point(186, 340);
            btnAdvance.Name = "btnAdvance";
            btnAdvance.Size = new Size(75, 25);
            btnAdvance.TabIndex = 10;
            btnAdvance.Text = "Detail..";
            btnAdvance.UseVisualStyleBackColor = true;
            btnAdvance.Click += btnAdvance_Click;
            // 
            // btnChange
            // 
            btnChange.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnChange.Location = new Point(267, 340);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(75, 25);
            btnChange.TabIndex = 11;
            btnChange.Text = "Advance";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 380);
            Controls.Add(btnChange);
            Controls.Add(btnAdvance);
            Controls.Add(dtgvPermissions);
            Controls.Add(dtgvPermissionGroup);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txbSearch);
            Controls.Add(btnRefresh);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvPermissionGroup).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgvPermissions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnRefresh;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem usersToolStripMenuItem;
        private ToolStripMenuItem userPermissionToolStripMenuItem;
        private ToolStripMenuItem profileToolStripMenuItem;
        private ToolStripMenuItem changePasswordToolStripMenuItem;
        private TextBox txbSearch;
        private ToolStripMenuItem groupsToolStripMenuItem;
        private ToolStripMenuItem actionsToolStripMenuItem;
        private Label label1;
        private Label label2;
        private ToolStripMenuItem toolStripAddGroup;
        private ToolStripMenuItem mngToolStripActionMng;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private DataGridView dtgvPermissionGroup;
        private DataGridView dtgvPermissions;
        private Button btnAdvance;
        private Button btnChange;
        private ToolStripMenuItem resourceToolStripMenuItem;
        private ToolStripMenuItem toolScriptAddResource;
        private ToolStripMenuItem addNewToolStripMenuItem;
    }
}
