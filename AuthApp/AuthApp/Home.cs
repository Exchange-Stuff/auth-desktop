﻿using AuthApp.Service.DTOs;
using AuthApp.Service.Services;

namespace AuthApp
{
    public partial class Home : Form
    {
        private readonly IActionService _actionService;
        private readonly IPermissionGroupService _permissionGroupService;
        private List<PermissionDTO> _permissionDTOs = null!;
        private List<PermissionGroupDTO> _permissionGroupDTOs = null!;
        public Home(IPermissionGroupService permissionGroupService, IActionService actionService)
        {
            InitializeComponent();
            _actionService = actionService;
            _permissionGroupService = permissionGroupService;
            LoadData();
        }

        private void LoadData()
        {
            LoadPermissionGroup();
            LoadPermission();
        }
        private async void LoadPermissionGroup()
        {
            _permissionGroupDTOs = await _permissionGroupService.GetPermissionGroupDTOs();
            if (_permissionGroupDTOs == null)
            {
                _permissionGroupDTOs = new List<PermissionGroupDTO>();
            }
            DisplayPermissionGroup(_permissionGroupDTOs);
        }

        private async void LoadPermission()
        {
            _permissionDTOs = await _permissionGroupService.GetPermissionDTO();
            if (_permissionDTOs == null)
            {
                _permissionDTOs = new List<PermissionDTO>();
            }
            DisplayPermission(_permissionDTOs);
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
                dtgvPermissions.Columns.Add("PermissionValue", "Permission Value");
                dtgvPermissions.RowHeadersVisible = false;
                dtgvPermissions.AllowUserToAddRows = false;
                foreach (var item in permissionDTOs)
                {
                    dtgvPermissions.Rows.Add(item.Role.Name, item.Resource.Name, item.PermissionValue);
                    dtgvPermissions.Tag = item.Id;
                }
                dtgvPermissions.CurrentCell = null!;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Can't show permission list, detail: {ex.Message}", "Notice");
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
            catch (Exception ex)
            {
                MessageBox.Show($"Can't show permission group list, detail: {ex.Message}", "Notice");
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
                            var permissions = _permissionDTOs.Where(x => x.Role.Id == permissionGroupId);
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
            catch (Exception ex)
            {
                MessageBox.Show("Some proble here, detail: " + ex.Message);
                return;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Now Lookeach Role <=> Permission Group
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
                    var permissions = _permissionDTOs.Where(x => permissionGroupId.Contains(x.Role.Id));
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
            catch (Exception ex)
            {
                MessageBox.Show("Some problem happened, detai: " + ex.Message);
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
                            var permissions = _permissionDTOs.Where(x => x.Role.Id == permissionGroupId);
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
            catch (Exception ex)
            {
                MessageBox.Show($"Some problem happened, detail: " + ex.Message);
            }
        }
    }
}