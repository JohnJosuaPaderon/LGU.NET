using LGU.Views.Core;
using LGU.Views.HumanResource;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;

namespace LGU.ViewModels.HumanResource
{
    public sealed class MainViewModel : NavigationalViewModelBase, INavigationAware
    {
        public static string MainViewContentRegion => "MainViewContentRegion";

        public MainViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator, MainViewContentRegion)
        {
            MenuItems.Add(new MenuItem { HeaderText = "Departments", Icon = PackIconKind.ChartBar, ViewName = nameof(DepartmentManagementView) });
            MenuItems.Add(new MenuItem { HeaderText = "Employee Finger Prints", Icon = PackIconKind.Fingerprint, ViewName = nameof(EmployeeFingerPrintEnrollmentView) });
            MenuItems.Add(new MenuItem { HeaderText = "User Sign-up", Icon = PackIconKind.AccountPlus, ViewName = nameof(UserSignUpView) });
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            RegionManager.RequestNavigate(MainViewContentRegion, (string)navigationContext.Parameters["view"]);
        }
    }
}
