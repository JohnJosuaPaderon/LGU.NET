using LGU.Views.HumanResource;
using Prism.Unity;

namespace LGU.HumanResource
{
    public class Bootstrapper : BootstrapperBase
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterTypeForNavigation<TimeKeepingView>();
            Container.RegisterTypeForNavigation<SampleView>();
        }
    }
}
