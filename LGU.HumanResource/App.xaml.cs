using LGU.HumanResource.Views;
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
            //MainWindowRedirectionOptions.Redirect(nameof(TimeLogView));

            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }
    }
}
