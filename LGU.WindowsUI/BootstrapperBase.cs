using LGU.Extensions;
using LGU.Views;
using Microsoft.Extensions.DependencyInjection;
using Prism.Unity;
using System.Configuration;
using System.Windows;

namespace LGU
{
    public abstract class BootstrapperBase : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<MainWindow>();
        }

        protected IServiceCollection ServiceCollection { get; } = new ServiceCollection();

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            SystemRuntime.SystemDirectory = ConfigurationManager.AppSettings["SystemDirectory"];
            InitializeServices();
            
            SystemRuntime.Instantiate(ServiceCollection);
        }

        protected virtual void InitializeServices()
        {
            ServiceCollection.SetConnectionStringSource();
            ServiceCollection.UseSqlServer();
        }
    }
}
