using LGU.Extensions;
using LGU.Views.HumanResource;
using Prism.Unity;

namespace LGU.HumanResource.TimeKeeping
{
    class Bootstrapper : BootstrapperBase
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterTypeForNavigation<TimeKeepingView>();
        }

        protected override void InitializeServices()
        {
            base.InitializeServices();

            ServiceCollection.UseDigitalPersona();
        }
    }
}
