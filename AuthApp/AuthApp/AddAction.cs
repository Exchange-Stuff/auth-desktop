using AuthApp.Service.Services;

namespace AuthApp
{
    public partial class AddAction : Form
    {
        private readonly IActionService _actionService;

        public AddAction(IActionService actionService)
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
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty((txbActionName.Text + "").Trim()))
                {
                    var actions = await _actionService.GetActions();
                    if (actions.Where(x => x.Name.ToLower() == (txbActionName.Text + "").Trim()).Count() > 0)
                    {
                        MessageBox.Show("Action name already contain", "Notice");
                        return;
                    }
                    var rs = await _actionService.CreateAction((txbActionName.Text + "").Trim());
                    if (rs)
                    {
                        MessageBox.Show("Update success", "Notice");
                        this.Close();
                        return;
                    }
                    MessageBox.Show("Update fail", "Notice");
                    return;
                }
                else
                {
                    MessageBox.Show("Name is required my son", "Notice");
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
    }
}
