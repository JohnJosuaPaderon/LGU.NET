using LGU.ViewModels;
using LGU.Views.SystemAdministration;
using System.Windows;

namespace LGU.SystemAdministration
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindowViewModel.InitialMainContentRegionSource = nameof(LauncherView);
            new Bootstrapper().Run();
        }
    }
}
