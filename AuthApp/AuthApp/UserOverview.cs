using AuthApp.Service.Models;
using AuthApp.Service.Services;

namespace AuthApp
{
    public partial class UserOverview : Form
    {
        private readonly IPermissionGroupService _permissionGroupService;
        private readonly IUserService _userService;

        public List<AccountViewModel> UserAddGroupPermissions { get; set; } = new List<AccountViewModel>();
        public UserOverview(IPermissionGroupService permissionGroupService, IUserService userService)
        {
            InitializeComponent();
            _permissionGroupService = permissionGroupService;
            _userService = userService;
            Application.ApplicationExit += new EventHandler(Cut);
        }

        private async void Cut(object sender, EventArgs e)
        {
            await _permissionGroupService.Logout();
            Application.Exit();
        }

        public void LoadUser(List<AccountViewModel> userAddGroupPermissions)
        {
            try
            {
                dtgvUser.DataSource = null!;
                dtgvUser.AllowUserToAddRows = false;
                dtgvUser.Rows.Clear();
                dtgvUser.Columns.Clear();

                dtgvUser.Columns.Add("Id", "Id");
                dtgvUser.Columns.Add("Username", "Username");
                dtgvUser.Columns.Add("Email", "Email");
                dtgvUser.AutoGenerateColumns = false;
                dtgvUser.RowHeadersVisible = false;
                foreach (var item in userAddGroupPermissions)
                {
                    DataGridViewRow dtr = new DataGridViewRow();
                    dtr.CreateCells(dtgvUser);
                    dtr.Cells[0].Value = item.Id;
                    dtr.Cells[1].Value = item.Username;
                    dtr.Cells[2].Value = item.Email + "";
                    dtr.Tag = item;
                    dtgvUser.Rows.Add(dtr);
                }
                dtgvUser.CurrentCell = null!;
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

        private async void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvUser.SelectedCells.Count > 0)
                {
                    var user = dtgvUser.Rows[dtgvUser.SelectedCells[0].RowIndex].Tag as AccountViewModel;
                    if (user != null)
                    {
                        var permissionGroups = await _permissionGroupService.GetPermissionGroupDTOs();
                        List<PermissionGroupUserUpdate> permissionGroupUserUpdates = new List<PermissionGroupUserUpdate>();
                        bool isRoleExist = user.PermissionGroups != null && user.PermissionGroups.Count > 0;
                        foreach (var item in permissionGroups)
                        {
                            PermissionGroupUserUpdate permissionGroupUserUpdate = new PermissionGroupUserUpdate
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Select = false
                            };
                            if (isRoleExist)
                            {
                                if (user.PermissionGroups!.Where(x => x.Id == item.Id).Count() > 0)
                                {
                                    permissionGroupUserUpdate.Select = true;
                                }
                            }
                            permissionGroupUserUpdates.Add(permissionGroupUserUpdate);
                        }
                        ChangeUserPermissionGroup changeUserPermissionGroup = new ChangeUserPermissionGroup(_userService);
                        changeUserPermissionGroup.lbId.Text = user.Id + "";
                        changeUserPermissionGroup.lbUsername.Text = user.Username;
                        changeUserPermissionGroup.lbEmail.Text = user.Email;
                        changeUserPermissionGroup.UserId = user.Id;
                        changeUserPermissionGroup.PermissionGroupUserUpdates = permissionGroupUserUpdates;
                        changeUserPermissionGroup.LoadPermissionGroup(permissionGroupUserUpdates);
                        changeUserPermissionGroup.ShowDialog();
                        UserAddGroupPermissions = await _userService.GetAccounts();
                        LoadUser(UserAddGroupPermissions);
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

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((txbSearch.Text + "").Trim()))
            {
                List<AccountViewModel> newList = UserAddGroupPermissions.Where(x => x.Username!=null!&& x.Username.ToLower().Contains(txbSearch.Text.ToLower()) || x.Email != null! && x.Email.ToLower().Contains(txbSearch.Text.ToLower())).ToList();
                LoadUser(newList);
            }
            else
            {
                LoadUser(UserAddGroupPermissions);
            }
        }
    }
}
