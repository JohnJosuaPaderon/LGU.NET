using LGU.ViewModels;
using LGU.Views.HumanResource;
using System.Windows;

namespace LGU.HumanResource
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindowViewModel.InitialMainContentRegionSource = nameof(TimeKeepingView);
            new Bootstrapper().Run();
        }
    }
}
