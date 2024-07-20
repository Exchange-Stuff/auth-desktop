using AuthApp.Service.DTOs;
using AuthApp.Service.Models;
using AuthApp.Service.Services;

namespace AuthApp
{
    public partial class ChangeUserPermissionGroup : Form
    {
        public List<PermissionGroupUserUpdate> PermissionGroupUserUpdates { get; set; } = new List<PermissionGroupUserUpdate>();
        private bool _isUpdate = true;
        private readonly IUserService _userService;
        public Guid UserId { get; set; }
        public ChangeUserPermissionGroup(IUserService userService)
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
            catch (Exception ex)
            {
                MessageBox.Show($"Can't show permission group list, detail: {ex.Message}", "Notice");
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _isUpdate = true;
                UserPermissionGroupUpdate userPermissionGroupUpdates = new UserPermissionGroupUpdate();
                List<Guid> permissionGroupIds = new List<Guid>();
                foreach (var item in PermissionGroupUserUpdates)
                {
                    if (item.Select)
                    {
                        permissionGroupIds.Add(item.Id);
                    }
                }
                userPermissionGroupUpdates.AccountId = UserId;
                userPermissionGroupUpdates.PermissionGroupIds = permissionGroupIds;

                var rs = await _userService.UpdateUserPermissionGroup(userPermissionGroupUpdates);
                if (rs)
                {
                    MessageBox.Show("Update success", "Notice");
                    return;
                }
                MessageBox.Show("Update fail", "Notice");
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

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty((txbSearch.Text + "").Trim()))
                {
                    List<PermissionGroupUserUpdate> newList = PermissionGroupUserUpdates.Where(x => x.Name.ToLower().Contains(txbSearch.Text.ToLower())).ToList();
                    LoadPermissionGroup(newList);
                }
                else
                {
                    LoadPermissionGroup(PermissionGroupUserUpdates);
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

        private void ChangeUserPermissionGroup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isUpdate)
            {
                if (MessageBox.Show("Do you wanna save?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnSave.PerformClick();
                    this.Close();
                }
            }
        }
    }
}
