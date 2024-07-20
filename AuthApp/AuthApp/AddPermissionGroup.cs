using AuthApp.Service.DTOs;
using AuthApp.Service.Models;
using AuthApp.Service.Services;
using System.Text;

namespace AuthApp
{
    public partial class AddPermissionGroup : Form
    {
        private readonly IPermissionGroupService _permissionGroupService;
        private readonly IActionService _actionService;
        private readonly IUserService _userService;
        public string GroupName { get; set; }
        public List<UserAddGroupPermission> UserAddGroupPermissionsAdded { get; set; } = new List<UserAddGroupPermission>();
        public List<UserAddGroupPermission> UserAddGroupPermissions { get; set; } = new List<UserAddGroupPermission>();
        public List<ActionDTO> ActionDTOs { get; set; } = new List<ActionDTO>();

        /// <summary>
        /// Receive from parent control, with permission value is 0;
        /// </summary>
        public List<PermissionResourceAddModel> PermissionResourceAddModels { get; set; } = new List<PermissionResourceAddModel>();

        public AddPermissionGroup(IUserService userService, IActionService actionService, IPermissionGroupService permissionGroupService)
        {
            InitializeComponent();
            _permissionGroupService = permissionGroupService;
            _actionService = actionService;
            _userService = userService;
            Application.ApplicationExit += new EventHandler(Cut);
        }

        private async void Cut(object sender, EventArgs e)
        {
            await _actionService.Logout();
            Application.Exit();
        }
        public void LoadUser(List<UserAddGroupPermission> dtsrc)
        {
            dtgvUser.DataSource = null!;
            dtgvUser.DataSource = dtsrc;
            dtgvUser.RowHeadersVisible = false;
            dtgvUser.AllowUserToAddRows = false;
            dtgvUser.CurrentCell = null!;
        }

        public async void LoadPermissions(List<PermissionResourceAddModel> resourceAddModels)
        {
            try
            {
                dtgvPermissions.DataSource = null!;
                dtgvPermissions.Columns.Clear();
                dtgvPermissions.Rows.Clear();
                dtgvPermissions.AutoGenerateColumns = false;
                dtgvPermissions.Columns.Add("ResourceName", "Resource");
                DataGridViewCheckBoxColumn dtgvchk = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "Full",
                    Name = "Full"
                };
                dtgvPermissions.Columns.Add(dtgvchk);
                var actions = await _actionService.GetActions();
                actions = actions.OrderBy(x => x.Index).ToList();
                foreach (var item in actions)
                {
                    DataGridViewCheckBoxColumn dtgvchk1 = new DataGridViewCheckBoxColumn
                    {
                        HeaderText = item.Name,
                        Name = item.Name
                    };
                    dtgvPermissions.Columns.Add(dtgvchk1);
                }
                dtgvPermissions.RowHeadersVisible = false;
                dtgvPermissions.AllowUserToAddRows = false;

                if (resourceAddModels != null)
                {
                    foreach (var item in resourceAddModels)
                    {
                        char[] authorizeString = ReverseString(DecimalToBinary(item.PermissionValue)).ToArray();
                        var dtRow = new DataGridViewRow();
                        dtRow.CreateCells(dtgvPermissions);
                        dtRow.Cells[0].Value = item.ResourceName;
                        dtRow.Cells[1].Value = item.FullControl;
                        for (int i = 0; i < authorizeString.Length; i++)
                        {
                            dtRow.Cells[i + 2].Value = authorizeString[i] == '1';
                        }
                        dtRow.Tag = item.ResourceId;
                        dtgvPermissions.Rows.Add(dtRow);
                    }
                }
                dtgvPermissions.CurrentCell = null!;
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

        private string DecimalToBinary(int decimalNumber)
        {
            if (decimalNumber == 0)
                return "0";

            StringBuilder binary = new StringBuilder();

            while (decimalNumber > 0)
            {
                binary.Insert(0, decimalNumber % 2);
                decimalNumber /= 2;
            }

            return binary.ToString();
        }

        /// <summary>
        /// SEALED
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private char[] ReverseString(string str)
        {
            char[] chars = str.ToCharArray();
            int length = str.Length;
            for (int i = 0; i < length / 2; i++)
            {
                char temp = chars[i];
                chars[i] = chars[length - 1 - i];
                chars[length - 1 - i] = temp;
            }
            // ***** NOTICE: Add on every action exclusive for sum permission
            char[] newCharsAddon = new char[ActionDTOs.Count];
            int index = 0;
            foreach (var item in newCharsAddon)
            {
                if (index < chars.Count())
                {
                    newCharsAddon[index] = chars[index];
                }
                else
                {
                    newCharsAddon[index] = '0';
                }
                index++;
            }
            return newCharsAddon;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                Task getUser = Task.Run(async () => UserAddGroupPermissions = await _userService.GetUsers());
                getUser.Wait();
                if (getUser.IsCompleted)
                {
                    if (UserAddGroupPermissionsAdded.Count > 0)
                    {
                        foreach (var item in UserAddGroupPermissionsAdded)
                        {
                            var itemGet = UserAddGroupPermissions.FirstOrDefault(x => x.Id == item.Id);
                            UserAddGroupPermissions.Remove(itemGet!);
                        }
                    }
                    AddUserToGroup addUserToGroup = new AddUserToGroup(_userService);
                    addUserToGroup.FormClosed += AddUserToGroup_FormClosed;
                    addUserToGroup.UserAddGroupPermissions = UserAddGroupPermissions;
                    addUserToGroup.LoadUser(UserAddGroupPermissions);
                    addUserToGroup.ShowDialog();
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

        private void AddUserToGroup_FormClosed(object? sender, FormClosedEventArgs e)
        {
            try
            {
                var addUserToGroup = sender as AddUserToGroup;
                if (addUserToGroup != null && addUserToGroup.AddConfirm)
                {
                    foreach (var item in addUserToGroup.UserAddeds)
                    {
                        UserAddGroupPermissionsAdded.Add(item);
                    }
                    LoadUser(UserAddGroupPermissionsAdded);
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

        private void AddPermissionGroup_FormClosed(object sender, FormClosedEventArgs e)
        {
            UserAddGroupPermissionsAdded = new List<UserAddGroupPermission>();
        }

        private void dtgvPermissions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int columnIndex = e.ColumnIndex;
                int rowIndex = e.RowIndex;
                if (rowIndex >= 0 && columnIndex > 0)
                {
                    var resourceId = (Guid)dtgvPermissions.Rows[rowIndex].Tag!;
                    if (resourceId != Guid.Empty)
                    {
                        if (columnIndex == 1)
                        {
                            var permissionAdded = PermissionResourceAddModels.FirstOrDefault(x => x.ResourceId == resourceId);
                            if (permissionAdded != null)
                            {
                                bool valueClick = (bool)dtgvPermissions.Rows[rowIndex].Cells[columnIndex].Value;
                                bool[] actionValue = new bool[ActionDTOs.Count];
                                int i = 0;
                                foreach (var item in actionValue)
                                {
                                    actionValue[i] = valueClick;
                                    i++;
                                }
                                PermissionResourceAddModels.FirstOrDefault(x => x.ResourceId == resourceId)!.PermissionValue = ToPermissionValue(actionValue);
                                PermissionResourceAddModels.FirstOrDefault(x => x.ResourceId == resourceId)!.FullControl = (bool)dtgvPermissions.Rows[rowIndex].Cells[columnIndex].Value;
                            }
                        }
                        else
                        {
                            var permissionCurrent = PermissionResourceAddModels.FirstOrDefault(x => x.ResourceId == resourceId);
                            if (permissionCurrent != null)
                            {
                                int newPermission = GetNewValue(ReverseString(DecimalToBinary(permissionCurrent.PermissionValue)), columnIndex, (bool)dtgvPermissions.Rows[rowIndex].Cells[columnIndex].Value);
                                PermissionResourceAddModels.FirstOrDefault(x => x.ResourceId == resourceId)!.PermissionValue = newPermission;
                                PermissionResourceAddModels.FirstOrDefault(x => x.ResourceId == resourceId)!.FullControl = (bool)dtgvPermissions.Rows[rowIndex].Cells[columnIndex].Value;
                            }
                        }
                    }
                    LoadPermissions(PermissionResourceAddModels);
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
        private int GetNewValue(char[] currentPermission, int columnIndex, bool value)
        {
            int temp = 0;
            columnIndex--;
            columnIndex--;
            foreach (var item in currentPermission)
            {
                if (temp == columnIndex)
                {
                    currentPermission[temp] = value ? '1' : '0';
                }
                temp++;
            }
            int sumPermission = 0;
            temp = 0;
            foreach (var item in currentPermission)
            {
                if (temp <= ActionDTOs.Count && item == '1')
                {
                    sumPermission += (int)Math.Pow(2, temp);
                }
                temp++;
            }
            return sumPermission;
        }
        /// <summary>
        /// Sorted with index of action please
        /// </summary>
        /// <param name="permissionValue"></param>
        /// <returns></returns>
        private int ToPermissionValue(bool[] permissionValue)
        {
            int rs = 0;
            int count = 0;
            foreach (var item in permissionValue)
            {
                if (item)
                {
                    rs += (int)Math.Pow(2, count);
                }
                count++;
            }
            return rs;
        }

        private void dtgvPermissions_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgvPermissions.IsCurrentCellDirty)
            {
                dtgvPermissions.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty((txbSearch.Text + "").Trim()))
                {
                    var permissionList = PermissionResourceAddModels.Where(x => x.ResourceName.ToLower().Contains(txbSearch.Text.ToLower())).ToList();
                    LoadPermissions(permissionList);
                }
                else
                {
                    if (PermissionResourceAddModels != null)
                    {
                        LoadPermissions(PermissionResourceAddModels);
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

        private async void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                CreatePermissionGroupModel createPermissionGroupModel = new CreatePermissionGroupModel();
                List<ResourceRecordPermissionValueModel> pvalue = new List<ResourceRecordPermissionValueModel>();

                foreach (var item in PermissionResourceAddModels)
                {
                    if (item.PermissionValue > 0)
                    {
                        pvalue.Add(new ResourceRecordPermissionValueModel(item.ResourceId, item.PermissionValue));
                    }
                }
                createPermissionGroupModel.Name = GroupName;
                createPermissionGroupModel.ResourceRecords = pvalue;
                List<Guid> userIds = new List<Guid>();
                if (UserAddGroupPermissionsAdded.Count > 0)
                {
                    foreach (var item in UserAddGroupPermissionsAdded)
                    {
                        userIds.Add(item.Id);
                    }
                    createPermissionGroupModel.AccountIds = userIds;
                }
                var rs = await _permissionGroupService.CreatePermissionGroup(createPermissionGroupModel);
                if (rs)
                {
                    MessageBox.Show("Create success", "Notice");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Create fail", "Notice");
                    return;
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

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvUser.SelectedCells.Count > 0)
                {
                    var rowIndex = dtgvUser.SelectedCells[0].RowIndex;
                    var userId = (Guid)dtgvUser.Rows[rowIndex].Cells["Id"].Value;
                    if (userId != Guid.Empty)
                    {
                        var user = UserAddGroupPermissionsAdded.FirstOrDefault(x => x.Id == userId);
                        if (user != null)
                        {
                            UserAddGroupPermissionsAdded.Remove(user);
                            LoadUser(UserAddGroupPermissionsAdded);
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
    }
}
