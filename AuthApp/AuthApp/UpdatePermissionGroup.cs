using AuthApp.Service.DTOs;
using AuthApp.Service.Models;
using AuthApp.Service.Services;
using System.Data;
using System.Text;

namespace AuthApp
{
    public partial class UpdatePermissionGroup : Form
    {
        private readonly IPermissionGroupService _permissionGroupService;

        public List<ActionDTO> ActionDTOs { get; set; } = new List<ActionDTO>();
        public List<UpdateResourcePermissionGroupModel> UpdateResourcePermissionGroupModelsAdded { get; set; } = new List<UpdateResourcePermissionGroupModel>();
        /// <summary>
        /// Pass form parent control
        /// </summary>
        public List<UpdateResourcePermissionGroupModel> UpdateResourcePermissionGroupModels { get; set; } = new List<UpdateResourcePermissionGroupModel>();
        private bool _isUpdated { get; set; } = false;
        /// <summary>
        /// Pass from parent control
        /// </summary>
        public Guid PermissionGroupId { get; set; }

        public UpdatePermissionGroup(IPermissionGroupService permissionGroupService)
        {
            InitializeComponent();
            _permissionGroupService = permissionGroupService;
        }
        public void LoadPermission(List<UpdateResourcePermissionGroupModel> updateResourcePermissionGroups)
        {
            dtgvPermission.DataSource = null;
            dtgvPermission.AllowUserToAddRows = false;
            dtgvPermission.Columns.Clear();
            dtgvPermission.Rows.Clear();

            dtgvPermission.Columns.Add("Resource", "Resource");

            DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Select",
                Name = "Select"
            };
            dtgvPermission.Columns.Add(dataGridViewCheckBoxColumn);
            DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Full",
                Name = "Full"
            };
            dtgvPermission.Columns.Add(dataGridViewCheckBoxColumn1);

            ActionDTOs = ActionDTOs.OrderBy(x => x.Index).ToList();
            foreach (var item in ActionDTOs)
            {
                DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2 = new DataGridViewCheckBoxColumn
                {
                    HeaderText = item.Name,
                    Name = item.Name
                };
                dtgvPermission.Columns.Add(dataGridViewCheckBoxColumn2);
            }

            foreach (var item in updateResourcePermissionGroups)
            {
                DataGridViewRow dtr = new DataGridViewRow();
                dtr.CreateCells(dtgvPermission);
                dtr.Cells[0].Value = item.ResourceName;
                dtr.Cells[1].Value = item.Selected;
                dtr.Cells[2].Value = item.FullControl;

                char[] permissionValue = ReverseString(DecimalToBinary(item.PermissionValue));
                int count = 3;
                foreach (var item1 in permissionValue)
                {
                    dtr.Cells[count].Value = item1 == '1' ? true : false;
                    count++;
                }
                dtr.Tag = item.ResourceId;
                dtgvPermission.Rows.Add(dtr);
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

        private void dtgvPermission_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgvPermission.IsCurrentCellDirty)
            {
                dtgvPermission.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtgvPermission_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvPermission.SelectedCells.Count > 0)
            {
                _isUpdated = false;
                var currentRow = dtgvPermission.Rows[e.RowIndex];
                Guid resourceId = (Guid)dtgvPermission.Rows[e.RowIndex].Tag!;
                bool valueCome = (bool)dtgvPermission.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                //Full control
                if (e.ColumnIndex == 2)
                {
                    bool[] permission = new bool[ActionDTOs.Count];
                    int count = 0;
                    foreach (var item in permission)
                    {
                        permission[count] = valueCome;
                        count++;
                    }
                    UpdateResourcePermissionGroupModels.FirstOrDefault(x => x.ResourceId == resourceId)!.FullControl = valueCome;
                    UpdateResourcePermissionGroupModels.FirstOrDefault(x => x.ResourceId == resourceId)!.PermissionValue = ToPermissionValue(permission);
                }
                else if (e.ColumnIndex == 1)
                {
                    if (valueCome)
                    {
                        var resource = UpdateResourcePermissionGroupModels.FirstOrDefault(x => x.ResourceId == resourceId)!;
                        UpdateResourcePermissionGroupModelsAdded.Add(resource);
                    }
                    else
                    {
                        var resource = UpdateResourcePermissionGroupModelsAdded.FirstOrDefault(x => x.ResourceId == resourceId)!;
                        UpdateResourcePermissionGroupModelsAdded.Remove(resource);
                    }
                    UpdateResourcePermissionGroupModels.FirstOrDefault(x => x.ResourceId == resourceId)!.Selected = valueCome;
                }
                else
                {
                    var permissionCurrent = UpdateResourcePermissionGroupModels.FirstOrDefault(x => x.ResourceId == resourceId)!;
                    if (permissionCurrent != null)
                    {
                        UpdateResourcePermissionGroupModels.FirstOrDefault(x => x.ResourceId == resourceId)!.PermissionValue = GetNewValue(ReverseString(DecimalToBinary(permissionCurrent.PermissionValue)), e.ColumnIndex, valueCome);
                        UpdateResourcePermissionGroupModels.FirstOrDefault(x => x.ResourceId == resourceId)!.FullControl = valueCome;
                    }
                }
                LoadPermission(UpdateResourcePermissionGroupModels);
            }
        }

        private int GetNewValue(char[] currentPermission, int columnIndex, bool value)
        {
            int temp = 0;
            columnIndex--;
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in dtgvPermission.Rows)
                {
                    if ((bool)item.Cells[1].Value)
                    {
                        var resourceId = (Guid)item.Tag!;
                        if (resourceId != Guid.Empty)
                        {
                            var itemResource = UpdateResourcePermissionGroupModelsAdded.FirstOrDefault(x => x.ResourceId == resourceId);
                            if (itemResource == null)
                            {
                                itemResource = UpdateResourcePermissionGroupModels.FirstOrDefault(x => x.ResourceId == resourceId);
                                if (itemResource != null)
                                {
                                    UpdateResourcePermissionGroupModelsAdded.Add(itemResource);
                                }
                            }
                        }
                    }
                    else
                    {
                        var resourceId = (Guid)item.Tag!;
                        if (resourceId != Guid.Empty)
                        {
                            var itemResource = UpdateResourcePermissionGroupModelsAdded.FirstOrDefault(x => x.ResourceId == resourceId);
                            if (itemResource != null)
                            {
                                UpdateResourcePermissionGroupModelsAdded.Remove(itemResource);
                            }
                        }
                    }
                }
                if (UpdateResourcePermissionGroupModelsAdded.Count > 0)
                {
                    UpdatePermissionGroupModel updatePermissionGroupModels = new UpdatePermissionGroupModel();
                    List<ResourceRecord> resourceRecords = new List<ResourceRecord>();
                    foreach (var item in UpdateResourcePermissionGroupModelsAdded)
                    {
                        resourceRecords.Add(new ResourceRecord(item.ResourceId, item.PermissionValue));
                    }
                    updatePermissionGroupModels.RoleId = PermissionGroupId;
                    updatePermissionGroupModels.ResourceValueRecords = resourceRecords;
                    var rs = await _permissionGroupService.UpdateResourceGroupPermission(updatePermissionGroupModels);
                    if (rs)
                    {
                        MessageBox.Show("Update success", "Notice");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Update fail", "Notice");
                        return;
                    }
                }
                _isUpdated = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some problem happened, details: " + ex.Message, "Notice");
                return;
            }
        }
    }
}

