using LGU.Extensions;
using LGU.Views.HumanResource;
using Prism.Unity;

namespace LGU.HumanResource.Kiosk
{
    class Bootstrapper : BootstrapperBase
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterTypeForNavigation<MainKioskView>();
            Container.RegisterTypeForNavigation<KioskServiceSelectionView>();
            Container.RegisterTypeForNavigation<KioskLocatorView>();
        }

        protected override void InitializeServices()
        {
            base.InitializeServices();
            ServiceCollection.UseDigitalPersona();
        }
    }
}
