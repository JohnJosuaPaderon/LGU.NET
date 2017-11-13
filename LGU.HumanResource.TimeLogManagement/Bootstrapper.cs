using LGU.Views.HumanResource;
using Prism.Unity;

namespace LGU.HumanResource
{
    class Bootstrapper : BootstrapperBase
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterTypeForNavigation<TimeLogManagementView>();
        }

        protected override void InitializeServices()
        {
            base.InitializeServices();
        }
    }
}
