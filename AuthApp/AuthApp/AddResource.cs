using AuthApp.Service.Services;

namespace AuthApp
{
    public partial class AddResource : Form
    {
        private readonly IResourceService _resourceService;

        public AddResource(IResourceService resourceService)
        {
            InitializeComponent();
            _resourceService = resourceService;
            Application.ApplicationExit += new EventHandler(Cut);
        }

        private async void Cut(object sender, EventArgs e)
        {
            await _resourceService.Logout();
            Application.Exit();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty((txbResourceName.Text + "").Trim()))
                {
                    var resources = await _resourceService.GetResources();
                    resources = resources.Where(x => x.Name.ToLower() == txbResourceName.Text.ToLower()).ToList();
                    if (resources.Any())
                    {
                        MessageBox.Show("Resource already exist my son", "Notice");
                        return;
                    }
                    var rs = await _resourceService.CreateResource(txbResourceName.Text);
                    if (rs)
                    {
                        MessageBox.Show("Create success", "Notice");
                        this.Close();
                        return;
                    }
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
    }
}
