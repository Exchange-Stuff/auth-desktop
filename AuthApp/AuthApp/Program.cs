using AuthApp.Service.Services;
using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.Logging;

namespace AuthApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
            var builder = new ContainerBuilder();
            builder.RegisterType<PermissionGroupService>().As<IPermissionGroupService>().InstancePerLifetimeScope();
            builder.RegisterType<AuthService>().As<IAuthService>().InstancePerLifetimeScope();
            builder.RegisterType<ActionService>().As<IActionService>().InstancePerLifetimeScope();
            builder.RegisterInstance(config).As<IConfiguration>().SingleInstance();
            builder.RegisterType<Login>().InstancePerLifetimeScope();
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var form = scope.Resolve<Login>();
                Application.Run(form);
            }
        }
    }
}