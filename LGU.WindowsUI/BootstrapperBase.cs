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
            ApplicationDomain.SystemDirectory = ConfigurationManager.AppSettings["SystemDirectory"];
            ApplicationDomain.ReportDirectory = ConfigurationManager.AppSettings.GetString("ReportDirectory");
            ApplicationDomain.ReportTemplateDirectory = ConfigurationManager.AppSettings.GetString("ReportTemplateDirectory");
            ApplicationDomain.DebugMode = ConfigurationManager.AppSettings.GetBoolean("DebugMode");
            InitializeServices();
            
            ApplicationDomain.Instantiate(ServiceCollection);
        }

        protected virtual void InitializeServices()
        {
            ServiceCollection.SetConnectionStringSource();
            ServiceCollection.UseSqlServer();
            ServiceCollection.EnableReporting();
            ServiceCollection.UseBuiltInEntityResolver();
        }
    }
}
