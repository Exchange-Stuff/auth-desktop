using AuthApp.Service.DTOs;
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
    public partial class Login : Form
    {
        private readonly IActionService _actionService;
        private readonly IAuthService _authService;
        private readonly IPermissionGroupService _permissionGroupService;

        public Login(IAuthService authService, IPermissionGroupService permissionGroupService, IActionService actionService)
        {
            InitializeComponent();
            _actionService=actionService;
            _authService = authService;
            _permissionGroupService = permissionGroupService;
        }
        private void VisibleControl(bool value)
        {
            label1.Visible=value;
            label2.Visible=value;
            txbUsername.Visible=value;
            txbPassword.Visible=value;
            btnLogin.Visible=value;
            progressBar1.Visible = !value;
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                VisibleControl(false);
                if (string.IsNullOrEmpty((txbUsername.Text + "").Trim()) ||
                    string.IsNullOrEmpty((txbPassword.Text + "").Trim())
                    )
                {
                    MessageBox.Show("Username or password is required");
                    VisibleControl(true);
                    return;
                }
                ClaimDTO claim = null!;
                Task loginTask =
                    Task.Run(async () => claim =
                    await _authService.Login(txbUsername.Text.Trim(), txbPassword.Text.Trim()));
                loginTask.Wait();
                if (loginTask.IsCompleted)
                {
                    if (claim == null!)
                    {
                        MessageBox.Show("Login fail, wrong username or password", "Notice");
                        VisibleControl(true);
                        return;
                    }
                    else
                    {
                        Home home = new Home(_permissionGroupService, _actionService);
                        VisibleControl(true);
                        home.ShowDialog();
                        this.Close();
                        home.Close();
                    }
                }
                VisibleControl(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some problem happed, detail: " + ex.Message);
                VisibleControl(true);
                return;
            }
        }
    }
}
