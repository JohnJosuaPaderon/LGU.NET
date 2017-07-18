using LGU.Extensions;
using LGU.Views.Core;
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
            Container.RegisterTypeForNavigation<UserSignUpView>();
            Container.RegisterTypeForNavigation<EmployeeFingerPrintEnrollmentView>();
        }

        protected override void InitializeServices()
        {
            base.InitializeServices();
            
            ServiceCollection.UseDigitalPersona();
        }
    }
}
