using LGU.Views.HumanResource;
using Prism.Unity;

namespace LGU.HumanResource.Applications
{
    class Bootstrapper : BootstrapperBase
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterTypeForNavigation<MainView>();
            Container.RegisterTypeForNavigation<TimeLogExportView>();
        }
    }
}
