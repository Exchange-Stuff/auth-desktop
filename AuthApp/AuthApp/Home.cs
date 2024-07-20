using AuthApp.Service.DTOs;
using AuthApp.Service.Models;
using AuthApp.Service.Services;
using Microsoft.VisualBasic.ApplicationServices;
using System.ComponentModel.Design;

namespace AuthApp
{
    public partial class Home : Form
    {
        private readonly IUserService _userService;
        private readonly IActionService _actionService;
        private readonly IPermissionGroupService _permissionGroupService;
        private readonly Service.Services.IResourceService _resourceService;
        private List<PermissionDTO> _permissionDTOs = null!;
        private List<PermissionGroupDTO> _permissionGroupDTOs = null!;
        public Home(IPermissionGroupService permissionGroupService, IActionService actionService, Service.Services.IResourceService resourceService, IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
            _actionService = actionService;
            _permissionGroupService = permissionGroupService;
            _resourceService = resourceService;
            LoadData();
            Application.ApplicationExit += new EventHandler(Cut);
        }

        private async void Cut(object sender, EventArgs e)
        {
            await _userService.Logout();
            Application.Exit();
        }

        private void LoadData()
        {
            try
            {
                LoadPermissionGroup();
                LoadPermission();
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

        private async void LoadPermissionGroup()
        {
            try
            {
                _permissionGroupDTOs = await _permissionGroupService.GetPermissionGroupDTOs();
                if (_permissionGroupDTOs == null)
                {
                    _permissionGroupDTOs = new List<PermissionGroupDTO>();
                }
                DisplayPermissionGroup(_permissionGroupDTOs);
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

        private async void LoadPermission()
        {
            try
            {
                _permissionDTOs = await _permissionGroupService.GetPermissionDTO();
                if (_permissionDTOs == null)
                {
                    _permissionDTOs = new List<PermissionDTO>();
                }
                DisplayPermission(_permissionDTOs);
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

        private void DisplayPermission(List<PermissionDTO> permissionDTOs)
        {
            try
            {
                dtgvPermissions.DataSource = null!;
                dtgvPermissions.Columns.Clear();
                dtgvPermissions.Rows.Clear();
                dtgvPermissions.AutoGenerateColumns = false;
                dtgvPermissions.Columns.Add("PermissionGroupName", "Permission Group Name");
                dtgvPermissions.Columns.Add("ResourceName", "Resource Name");
                dtgvPermissions.RowHeadersVisible = false;
                dtgvPermissions.AllowUserToAddRows = false;
                foreach (var item in permissionDTOs)
                {
                    dtgvPermissions.Rows.Add(item.PermissionGroup.Name, item.Resource.Name);
                    dtgvPermissions.Tag = item.Id;
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

        private void DisplayPermissionGroup(List<PermissionGroupDTO> permissionDTOs)
        {
            try
            {
                dtgvPermissionGroup.DataSource = null!;
                dtgvPermissionGroup.Columns.Clear();
                dtgvPermissionGroup.Rows.Clear();
                dtgvPermissionGroup.AutoGenerateColumns = false;
                dtgvPermissionGroup.Columns.Add("PermissionGroupName", "Permission Group Name");
                dtgvPermissionGroup.Columns["PermissionGroupName"].Width = 150;
                dtgvPermissionGroup.RowHeadersVisible = false;
                dtgvPermissionGroup.AllowUserToAddRows = false;
                foreach (var item in permissionDTOs)
                {
                    var row = new DataGridViewRow();
                    row.CreateCells(dtgvPermissionGroup, item.Name);
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

        private void dtgvPermissionGroup_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvPermissionGroup.SelectedCells.Count > 0)
                {
                    int index = dtgvPermissionGroup.SelectedCells[0].RowIndex;
                    if (dtgvPermissionGroup.Rows[index].Tag != null)
                    {
                        var permissionGroupId = (Guid)dtgvPermissionGroup.Rows[index].Tag!;
                        if (_permissionDTOs != null && _permissionDTOs.Count > 0)
                        {
                            var permissions = _permissionDTOs.Where(x => x.PermissionGroup.Id == permissionGroupId);
                            if (permissions != null)
                            {
                                DisplayPermission(permissions.ToList());
                            }
                        }
                    }
                }
                //else
                //{
                //    _permissionDTOs = null!;
                //    LoadPermission();
                //}
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
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

        /// <summary>
        /// Now Lookeach PermissionGroup <=> Permission Group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty((txbSearch.Text + "").Trim()))
                {
                    var permissionGroup = _permissionGroupDTOs.Where(x => x.Name.ToLower().Contains(txbSearch.Text.Trim()));
                    var permissionGroupId = permissionGroup.Select(x => x.Id);
                    var permissions = _permissionDTOs.Where(x => permissionGroupId.Contains(x.PermissionGroup.Id));
                    DisplayPermissionGroup(permissionGroup.ToList());
                    if (permissions != null)
                    {
                        DisplayPermission(permissions.ToList());
                    }
                    else
                    {
                        DisplayPermission(new List<PermissionDTO>());
                    }
                }
                else
                {
                    if (_permissionGroupDTOs != null!)
                    {
                        DisplayPermissionGroup(_permissionGroupDTOs);
                        if (_permissionDTOs != null)
                        {
                            DisplayPermission(_permissionDTOs);
                        }
                        else
                        {
                            DisplayPermission(new List<PermissionDTO>());
                        }
                    }
                    else
                    {
                        LoadPermissionGroup();
                        LoadPermission();
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

        private async void btnAdvance_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvPermissionGroup.SelectedRows.Count > 0)
                {
                    int index = dtgvPermissionGroup.SelectedCells[0].RowIndex;
                    if (dtgvPermissionGroup.Rows[index].Tag != null)
                    {
                        var permissionGroupId = (Guid)dtgvPermissionGroup.Rows[index].Tag!;
                        if (_permissionDTOs != null && _permissionDTOs.Count > 0)
                        {
                            var permissions = _permissionDTOs.Where(x => x.PermissionGroup.Id == permissionGroupId);
                            var action = await _actionService.GetActions();
                            PermissionGroupAdvance permissionGroupAdvance = new PermissionGroupAdvance(_permissionGroupService);
                            permissionGroupAdvance.ListPermission = permissions.ToList();
                            permissionGroupAdvance.ListActions = action;
                            permissionGroupAdvance.LoadPermission(permissions.ToList());
                            permissionGroupAdvance.ShowDialog();
                            LoadData();
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

        private void toolStripAddGroup_Click(object sender, EventArgs e)
        {
            try
            {
                PermissionGroupName permissionGroupName = new PermissionGroupName(_permissionGroupService, _userService, _actionService, _resourceService);
                permissionGroupName.ShowDialog();
                LoadData();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Notice");
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some problem happened, detail: " + ex.Message);
                return;
            }
        }

        private async void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvPermissionGroup.SelectedCells.Count > 0)
                {
                    Guid permissionGroupId = (Guid)dtgvPermissionGroup.Rows[dtgvPermissionGroup.SelectedCells[0].RowIndex].Tag!;
                    if (permissionGroupId != Guid.Empty)
                    {
                        var permissionGroup = _permissionGroupDTOs.FirstOrDefault(x => x.Id == permissionGroupId)!;
                        if (permissionGroup != null)
                        {
                            var resources = await _resourceService.GetResources();
                            var permissionOfGroup = await _permissionGroupService.GetPermissionDTO();
                            if (permissionOfGroup.Any())
                            {
                                List<UpdateResourcePermissionGroupModel> updateResourcePermissionGroupModels = new List<UpdateResourcePermissionGroupModel>();
                                foreach (var item in resources)
                                {
                                    var pNow = permissionOfGroup.FirstOrDefault(x => x.Resource.Id == item.Id && x.PermissionGroup.Id == permissionGroupId)!;
                                    UpdateResourcePermissionGroupModel updateResourcePermissionGroupModel = new UpdateResourcePermissionGroupModel
                                    {
                                        ResourceId = item.Id,
                                        ResourceName = item.Name,
                                        FullControl = false,
                                        PermissionValue = 0,
                                        Selected = false
                                    };
                                    if (pNow != null!)
                                    {
                                        updateResourcePermissionGroupModel.PermissionValue = pNow.PermissionValue;
                                        updateResourcePermissionGroupModel.Selected = true;
                                    }
                                    updateResourcePermissionGroupModels.Add(updateResourcePermissionGroupModel);
                                }
                                UpdatePermissionGroup updatePermissionGroup = new UpdatePermissionGroup(_permissionGroupService,_actionService);
                                updatePermissionGroup.PermissionGroupId = permissionGroupId;
                                updatePermissionGroup.lbPermissionGroupName.Text = permissionGroup.Name;
                                updatePermissionGroup.UpdateResourcePermissionGroupModels = updateResourcePermissionGroupModels;
                                updatePermissionGroup.ActionDTOs = await _actionService.GetActions();
                                updatePermissionGroup.LoadPermission(updateResourcePermissionGroupModels);
                                updatePermissionGroup.ShowDialog();
                                LoadData();
                            }
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

        private async void userPermissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<AccountViewModel> userAddGroupPermissions = await _userService.GetAccounts();
                UserOverview userOverview = new UserOverview(_permissionGroupService, _userService);
                userOverview.UserAddGroupPermissions = userAddGroupPermissions;
                userOverview.LoadUser(userAddGroupPermissions);
                userOverview.ShowDialog();
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

        private async void mngToolStripActionMng_Click(object sender, EventArgs e)
        {
            try
            {
                ActionOverview actionOverview = new ActionOverview(_actionService);
                var actions = await _actionService.GetActions();
                actionOverview.ActionDTOs = actions;
                actionOverview.LoadAction(actions);
                actionOverview.ShowDialog();
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

        private void toolScriptAddResource_Click(object sender, EventArgs e)
        {
            AddResource addResource = new AddResource(_resourceService);
            addResource.ShowDialog();
        }

        private async void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewUser addNewUser = new AddNewUser(_userService);
            var permissionGroupDtos = await _permissionGroupService.GetPermissionGroupDTOs();
            var permissionGroups = await _permissionGroupService.GetPermissionGroupDTOs();
            List<PermissionGroupUserUpdate> permissionGroupUserUpdates = new List<PermissionGroupUserUpdate>();
            foreach (var item in permissionGroups)
            {
                PermissionGroupUserUpdate permissionGroupUserUpdate = new PermissionGroupUserUpdate
                {
                    Id = item.Id,
                    Name = item.Name,
                    Select = false
                };
                permissionGroupUserUpdates.Add(permissionGroupUserUpdate);
            }
            addNewUser.PermissionGroupUserUpdates = permissionGroupUserUpdates;
            addNewUser.LoadPermissionGroup(permissionGroupUserUpdates);
            addNewUser.ShowDialog();
        }
    }
}
