using LGU.Extensions;
using LGU.Views.SystemAdministration;
using Prism.Unity;

namespace LGU.SystemAdministration
{
    public class Bootstrapper : BootstrapperBase
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterTypeForNavigation<LauncherView>();
            Container.RegisterTypeForNavigation<MainView>();
        }

        protected override void InitializeServices()
        {
            base.InitializeServices();

            ServiceCollection.SetSystemAdministratorManager();
        }
    }
}
