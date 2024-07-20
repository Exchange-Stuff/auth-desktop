using AuthApp.Service.DTOs;
using AuthApp.Service.Models;
using AuthApp.Service.Services;
using System.Text;

namespace AuthApp
{
    public partial class PermissionGroupAdvance : Form
    {
        public List<PermissionDTO> ListPermission = new List<PermissionDTO>();
        public List<ActionDTO> ListActions = new List<ActionDTO>();
        private List<PermissionRecordEdit> _permissionRecordEdits = new List<PermissionRecordEdit>();
        private readonly IPermissionGroupService _permissionGroupService;
        private bool _isUpdated = true;
        public PermissionGroupAdvance(IPermissionGroupService permissionGroupService)
        {
            InitializeComponent();
            _permissionGroupService = permissionGroupService;
            Application.ApplicationExit += new EventHandler(Cut);
        }

        private async void Cut(object sender, EventArgs e)
        {
            await _permissionGroupService.Logout();
            Application.Exit();
        }

        public void LoadPermission(List<PermissionDTO> permissionDTOs)
        {
            try
            {
                dtgvPermissions.DataSource = null!;
                dtgvPermissions.Columns.Clear();
                dtgvPermissions.Rows.Clear();
                dtgvPermissions.AutoGenerateColumns = false;

                ListActions = ListActions.OrderBy(x => x.Index).ToList();
                dtgvPermissions.Columns.Add("ResourceName", "Resource");
                foreach (var item in ListActions)
                {
                    DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                    {
                        HeaderText = item.Name,
                        Name = item.Name
                    };
                    dtgvPermissions.Columns.Add(checkBoxColumn);
                }
                dtgvPermissions.RowHeadersVisible = false;
                dtgvPermissions.AllowUserToAddRows = false;
                if (permissionDTOs != null)
                {
                    foreach (var item in permissionDTOs)
                    {
                        char[] authorizeString = ReverseString(DecimalToBinary(item.PermissionValue)).ToArray();

                        var row = new DataGridViewRow();
                        row.CreateCells(dtgvPermissions);
                        row.Cells[0].Value = item.Resource.Name;
                        row.Tag = item.Resource.Id;
                        for (int i = 0; i < authorizeString.Length; i++)
                        {
                            row.Cells[i + 1].Value = authorizeString[i] == '1';
                        }
                        dtgvPermissions.Rows.Add(row);
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

        private void eventCheckChangePermisison(object sender, EventArgs e, string resourceId)
        {

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
            char[] newCharsAddon = new char[ListActions.Count];
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

        private void txbSearchResource_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty((txbSearchResource.Text + "").Trim()))
                {
                    var permissions = ListPermission
                        .Where(x => x.Resource.Name.ToLower().Contains(txbSearchResource.Text.ToLower()));
                    LoadPermission(permissions.ToList());
                }
                else
                {
                    if (ListPermission != null)
                    {
                        LoadPermission(ListPermission);
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

        private async void UpdatePermission()
        {
            try
            {
                Guid roleId = Guid.Empty;
                List<ResourceRecord> resourceRecords = new List<ResourceRecord>();
                foreach (var item in ListPermission)
                {
                    if (roleId == Guid.Empty)
                    {
                        roleId = item.PermissionGroup.Id;
                    }
                    resourceRecords.Add(new ResourceRecord(item.Resource.Id, item.PermissionValue));
                }
                UpdatePermissionGroupModel updatePermissionGroupModel = new UpdatePermissionGroupModel
                {
                    PermissionGroupId = roleId,
                    ResourceValueRecords = resourceRecords
                };
                var rs = await _permissionGroupService.UpdateGroupPermission(updatePermissionGroupModel);
                if (rs)
                {
                    MessageBox.Show("Update success", "Notice");
                    _isUpdated = true;
                    return;
                }
                MessageBox.Show("Some problem, can't update permissions");
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UpdatePermission();
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

        private void dtgvPermissions_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgvPermissions.IsCurrentCellDirty)
            {
                dtgvPermissions.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtgvPermissions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex > 0)
                {
                    _isUpdated = false;
                    var row = dtgvPermissions.Rows[e.RowIndex];
                    var resourceId = (Guid)row.Tag!;
                    if (resourceId != Guid.Empty)
                    {
                        var permission = ListPermission.Where(x => x.Resource.Id == resourceId).FirstOrDefault()!;
                        if (permission != null)
                        {
                            var currentPermisisonValue = permission.PermissionValue;
                            var binPV = ReverseString(DecimalToBinary(currentPermisisonValue));
                            ListPermission.Where(x => x.Resource.Id == resourceId).FirstOrDefault()!.PermissionValue = GetNewValue(binPV, e.ColumnIndex, (bool)row.Cells[e.ColumnIndex].Value);
                        }
                    }
                    _isUpdated = false;
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
                if (temp <= ListActions.Count && item == '1')
                {
                    sumPermission += (int)Math.Pow(2, temp);
                }
                temp++;
            }
            return sumPermission;
        }

        private void PermissionGroupAdvance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isUpdated)
            {
                DialogResult result = MessageBox.Show("Do you wanna save information ?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    UpdatePermission();
                }
            }
        }
    }

    public sealed record PermissionRecordEdit(Guid ResourceId, int PermissionValue);
}
