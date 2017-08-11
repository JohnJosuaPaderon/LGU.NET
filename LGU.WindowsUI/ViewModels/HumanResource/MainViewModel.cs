using LGU.Views.Core;
using LGU.Views.HumanResource;
using MaterialDesignThemes.Wpf;
using Prism.Events;
using Prism.Regions;

namespace LGU.ViewModels.HumanResource
{
    public sealed class MainViewModel : NavigationalViewModelBase, INavigationAware
    {
        public static string MainViewContentRegion => "MainViewContentRegion";

        public MainViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator, MainViewContentRegion)
        {
            MenuItems.Add(new MenuItem { HeaderText = "Departments", Icon = PackIconKind.ChartBar, ViewName = nameof(DepartmentManagementView) });
            MenuItems.Add(new MenuItem { HeaderText = "Employee Finger Prints", Icon = PackIconKind.Fingerprint, ViewName = nameof(EmployeeFingerPrintEnrollmentView) });
            MenuItems.Add(new MenuItem { HeaderText = "DTR Export", Icon = PackIconKind.ClockEnd, ViewName = nameof(TimeLogExportView) });
            MenuItems.Add(new MenuItem { HeaderText = "Actual Time-Logs", Icon = PackIconKind.ClockEnd, ViewName = nameof(ActualTimeLogExportView) });
            MenuItems.Add(new MenuItem { HeaderText = "Locator", Icon = PackIconKind.AccountLocation, ViewName = nameof(LocatorView) });
            MenuItems.Add(new MenuItem { HeaderText = "User Sign-up", Icon = PackIconKind.AccountPlus, ViewName = nameof(UserSignUpView) });

            r_ChangeHeaderEvent.Subscribe(header => Header = header);
            r_TitleEvent.Publish("Human Resource & Development Office");
        }

        private string _Header;
        public string Header
        {
            get { return _Header; }
            set { SetProperty(ref _Header, value); }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            r_RegionManager.RequestNavigate(MainViewContentRegion, (string)navigationContext.Parameters["view"]);
        }
    }
}
