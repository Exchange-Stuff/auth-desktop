using AuthApp.Service.Models;
using AuthApp.Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthApp
{
    public partial class PermissionGroupName : Form
    {
        private readonly IResourceService _resourceService;
        private readonly IActionService _actionService;
        private readonly IUserService _userService;
        private IPermissionGroupService _permissionGroupService;

        public PermissionGroupName(IPermissionGroupService permissionGroupService, IUserService userService, IActionService actionService, IResourceService resourceService)
        {
            InitializeComponent();
            _resourceService= resourceService;
            _actionService = actionService;
            _userService = userService;
            _permissionGroupService = permissionGroupService;
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((txbName.Name + "").Trim()))
            {
                MessageBox.Show("Name is required", "Notice");
                return;
            }
            var permissionGroup = await _permissionGroupService.GetPermissionGroupDTOs();
            if (permissionGroup != null && permissionGroup.Count > 0)
            {
                var check = permissionGroup.Where(x => x.Name.ToLower().Equals(txbName.Text.ToLower())).ToList();
                if (check.Count > 0)
                {
                    MessageBox.Show("Group name already contain", "Notice");
                    return;
                }
                var resources = await _resourceService.GetResources();
                List<PermissionResourceAddModel> permissionResourceAddModels = new List<PermissionResourceAddModel>();
                foreach (var item in resources)
                {
                    permissionResourceAddModels.Add(new PermissionResourceAddModel
                    {
                        PermissionValue = 0,
                        ResourceId = item.Id,
                        ResourceName = item.Name
                    });
                }
                AddPermissionGroup addPermissionGroup = new AddPermissionGroup(_userService, _actionService, _permissionGroupService);
                addPermissionGroup.PermissionResourceAddModels = permissionResourceAddModels;
                addPermissionGroup.GroupName = txbName.Text;
                addPermissionGroup.ActionDTOs = await _actionService.GetActions();
                addPermissionGroup.LoadPermissions(permissionResourceAddModels);
                addPermissionGroup.ShowDialog();
                this.Close();
            }
        }
    }
}
