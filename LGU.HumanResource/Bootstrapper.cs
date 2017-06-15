using LGU.Core.ViewModels;
using LGU.Core.Views;
using LGU.HumanResource.Views;
using Prism.Unity;
using System.Windows;

namespace LGU.HumanResource
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterTypeForNavigation<UserAuthenticationView>(nameof(UserAuthenticationView));
            Container.RegisterTypeForNavigation<HumanResourceLauncherView>(nameof(HumanResourceLauncherView));
            MainWindowViewModel.ContentRegionMainTarget = nameof(HumanResourceLauncherView);
        }
    }
}
