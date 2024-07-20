using AuthApp.Service.Models;
using AuthApp.Service.Services;

namespace AuthApp
{
    public partial class AddUserToGroup : Form
    {
        public List<UserAddGroupPermission> UserAddGroupPermissions { get; set; } = new List<UserAddGroupPermission>();
        private readonly IUserService _userService;
        public List<UserAddGroupPermission> UserAddeds { get; set; } = new List<UserAddGroupPermission>();
        public bool AddConfirm { get; set; } = false;
        public AddUserToGroup(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
            AddConfirm = false;
            Application.ApplicationExit += new EventHandler(Cut);
        }

        private async void Cut(object sender, EventArgs e)
        {
            await _userService.Logout();
            Application.Exit();
        }

        public void LoadUser(List<UserAddGroupPermission> dtsrc)
        {
            try
            {
                dtgvUser.DataSource = null!;
                dtgvUser.Columns.Clear();
                dtgvUser.Rows.Clear();
                DataGridViewCheckBoxColumn dtchk = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "Select",
                    Name = "Select"
                };
                dtgvUser.Columns.Add(dtchk);
                dtgvUser.Columns.Add("Username", "Username");
                dtgvUser.Columns.Add("Email", "Email");
                foreach (var item in dtsrc)
                {
                    DataGridViewRow dtrow = new DataGridViewRow();
                    dtrow.CreateCells(dtgvUser);
                    dtrow.Cells[0].Value = false;
                    dtrow.Cells[1].Value = item.Username;
                    dtrow.Cells[2].Value = item.Email;
                    dtrow.Tag = item.Id;
                    dtgvUser.Rows.Add(dtrow);
                }
                dtgvUser.RowHeadersVisible = false;
                dtgvUser.AllowUserToAddRows = false;
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

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddConfirm = true;
            this.Close();
        }

        private void txtSearchUser_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty((txtSearchUser.Text + "").Trim()))
                {
                    var newUsers = UserAddGroupPermissions
                        .Where(x => x.Username.ToLower().Contains(txtSearchUser.Text.Trim().ToLower())
                        || x.Email.ToLower().Contains(txtSearchUser.Text.Trim().ToLower()));
                    LoadUser(newUsers.ToList());
                }
                else
                {
                    if (UserAddGroupPermissions != null)
                    {
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

        private void dtgvUser_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgvUser.SelectedCells.Count > 0)
                {
                    int columnIndex = e.ColumnIndex;
                    int rowIndex = e.RowIndex;
                    bool valueChange = (bool)dtgvUser.Rows[rowIndex].Cells[columnIndex].Value;
                    Guid userId = (Guid)dtgvUser.Rows[rowIndex].Tag!;
                    if (userId != Guid.Empty && valueChange)
                    {
                        UserAddeds.Add(new UserAddGroupPermission
                        {
                            Email = dtgvUser.Rows[rowIndex].Cells["Email"].Value + "",
                            Username = dtgvUser.Rows[rowIndex].Cells["Username"].Value + "",
                            Id = userId
                        });
                    }
                    else if (userId != Guid.Empty && !valueChange)
                    {
                        var user = UserAddeds.FirstOrDefault(x => x.Id == userId);
                        if (user != null)
                        {
                            UserAddeds.Remove(user!);
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

        private void dtgvUser_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgvUser.IsCurrentCellDirty)
            {
                dtgvUser.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
