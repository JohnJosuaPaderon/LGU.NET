using LGU.Extensions;
using LGU.Views.HumanResource;
using Prism.Unity;

namespace LGU.HumanResource
{
    public class Bootstrapper : BootstrapperBase
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterTypeForNavigation<PreviewEmployeeView>();
            Container.RegisterTypeForNavigation<EmployeeFingerPrintEnrollmentView>();
        }

        protected override void InitializeServices()
        {
            ServiceCollection.SetConnectionStringSource();
            ServiceCollection.UseSqlServer();
        }
    }
}
