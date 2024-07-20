using AuthApp.Service.DTOs;
using AuthApp.Service.Services;

namespace AuthApp
{
    public partial class ActionOverview : Form
    {
        private readonly IActionService _actionService;

        public List<ActionDTO> ActionDTOs { get; set; } = new List<ActionDTO>();

        public ActionOverview(IActionService actionService)
        {
            InitializeComponent();
            _actionService = actionService;
            Application.ApplicationExit += new EventHandler(Cut);
        }

        private async void Cut(object sender, EventArgs e)
        {
            await _actionService.Logout();
            Application.Exit();
        }
        public void LoadAction(List<ActionDTO> actionDTOs)
        {
            try
            {
                dtgvAction.DataSource = null!;
                dtgvAction.AllowUserToAddRows = false;

                dtgvAction.Rows.Clear();
                dtgvAction.Columns.Clear();

                dtgvAction.Columns.Add("Name", "Name");
                dtgvAction.Columns.Add("Value", "Value");
                dtgvAction.RowHeadersVisible = false;
                dtgvAction.AutoGenerateColumns = false;
                foreach (var item in actionDTOs)
                {
                    DataGridViewRow dtr = new DataGridViewRow();
                    dtr.CreateCells(dtgvAction);
                    dtr.Cells[0].Value = item.Name;
                    dtr.Cells[1].Value = item.Value;
                    dtr.Tag = item.Id;
                    dtgvAction.Rows.Add(dtr);
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
                AddAction addAction = new AddAction(_actionService);
                addAction.ShowDialog();
                ActionDTOs = await _actionService.GetActions();
                LoadAction(ActionDTOs);
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
