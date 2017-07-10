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

            Container.RegisterTypeForNavigation<LauncherView>();
            Container.RegisterTypeForNavigation<PreviewEmployeeView>();
            Container.RegisterTypeForNavigation<DepartmentManagementView>();
            Container.RegisterTypeForNavigation<MainView>();
            Container.RegisterTypeForNavigation<EmployeeFingerPrintEnrollmentView>();
            Container.RegisterTypeForNavigation<TimeKeepingView>();
        }

        protected override void InitializeServices()
        {
            ServiceCollection.SetConnectionStringSource();
            ServiceCollection.UseSqlServer();
            ServiceCollection.UseDigitalPersona();
        }
    }
}
