using AuthApp.Service.Models;
using AuthApp.Service.Services;

namespace AuthApp
{
    public partial class AddNewUser : Form
    {
        private readonly IUserService _userService;
        private bool _isUpdate = true;
        public List<PermissionGroupUserUpdate> PermissionGroupUserUpdates { get; set; } = new List<PermissionGroupUserUpdate>();

        public AddNewUser(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
            Application.ApplicationExit += new EventHandler(Cut);
        }

        private async void Cut(object sender, EventArgs e)
        {
            await _userService.Logout();
            Application.Exit();
        }

        public void LoadPermissionGroup(List<PermissionGroupUserUpdate> permissionGroupUsers)
        {
            try
            {
                dtgvPermissionGroup.DataSource = null!;
                dtgvPermissionGroup.Columns.Clear();
                dtgvPermissionGroup.Rows.Clear();
                dtgvPermissionGroup.AutoGenerateColumns = false;
                DataGridViewCheckBoxColumn dtchkc = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "Select",
                    Name = "Select"
                };
                dtgvPermissionGroup.Columns.Add(dtchkc);
                dtgvPermissionGroup.Columns.Add("PermissionGroupName", "Permission Group Name");
                dtgvPermissionGroup.Columns["Select"].Width = 50;
                dtgvPermissionGroup.RowHeadersVisible = false;
                dtgvPermissionGroup.AllowUserToAddRows = false;
                foreach (var item in permissionGroupUsers)
                {
                    var row = new DataGridViewRow();
                    row.CreateCells(dtgvPermissionGroup);
                    row.Cells[0].Value = item.Select;
                    row.Cells[1].Value = item.Name;
                    row.Tag = item.Id;
                    dtgvPermissionGroup.Rows.Add(row);
                }
                dtgvPermissionGroup.CurrentCell = null;
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Notice");
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Some problem happened, detail: " + ex.Message);
                return;
            }
        }

        private void dtgvPermissionGroup_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgvPermissionGroup.IsCurrentCellDirty)
            {
                dtgvPermissionGroup.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtgvPermissionGroup_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgvPermissionGroup.SelectedCells.Count > 0)
                {
                    _isUpdate = false;
                    var permissionGroupId = (Guid)dtgvPermissionGroup.Rows[e.RowIndex].Tag!;
                    if (permissionGroupId != Guid.Empty)
                    {
                        var permisisionGroup = PermissionGroupUserUpdates.FirstOrDefault(x => x.Id == permissionGroupId);
                        if (permisisionGroup != null!)
                        {
                            PermissionGroupUserUpdates.FirstOrDefault(x => x.Id == permissionGroupId)!.Select = (bool)dtgvPermissionGroup.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                            LoadPermissionGroup(PermissionGroupUserUpdates);
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Notice");
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Some problem happened, detail: " + ex.Message);
                return;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty((txbUsername.Text + "").Trim()) ||
              string.IsNullOrEmpty((txbPassword.Text + "").Trim()) ||
              string.IsNullOrEmpty((txbConfirmPassword.Text + "").Trim()) ||
              string.IsNullOrEmpty((txbName.Text + "").Trim())
              )
                {

                    MessageBox.Show("All filed required", "Notice");
                    return;
                }
                if (txbUsername.Text.Split(" ").Length > 1)
                {
                    MessageBox.Show("Not contain [space] please", "Notice");
                    return;
                }
                var account = await _userService.GetAccounts(txbUsername.Text.Trim());
                if (account != null && account.Count > 0)
                {
                    MessageBox.Show("Username already exist");
                    return;
                }
                if (txbUsername.Text.Length <= 5)
                {
                    MessageBox.Show("Username length >5");
                    return;
                }
                if (txbPassword.Text.Length <= 5)
                {
                    MessageBox.Show("Password length >5");
                    return;
                }
                if (txbConfirmPassword.Text.Length <= 5)
                {
                    MessageBox.Show("Password length >5");
                    return;
                }
                if (txbName.Text.Length <= 1)
                {
                    MessageBox.Show("Name length >1");
                    return;
                }
                if (txbPassword.Text != txbConfirmPassword.Text)
                {
                    MessageBox.Show("Two password miss match");
                    return;
                }
                AccountCreateModel accountCreateModel = new AccountCreateModel
                {
                    Name = txbUsername.Text,
                    Password = txbPassword.Text,
                    Username = txbUsername.Text
                };
                List<Guid> permissionGroupIds = new List<Guid>();
                foreach (var item in PermissionGroupUserUpdates)
                {
                    if (item.Select)
                    {
                        permissionGroupIds.Add(item.Id);
                    }
                }
                if (permissionGroupIds.Count > 0)
                {
                    accountCreateModel.PermisisonGroupIds = permissionGroupIds;
                }
                var rs = await _userService.CreateAccount(accountCreateModel);
                if (rs)
                {
                    MessageBox.Show("Create success", "Notice");
                    this.Close();
                    return;
                }
                MessageBox.Show("Create fail", "Notice");
                return;
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Notice");
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Some problem happened, detail: " + ex.Message);
                return;
            }
        }
    }
}
