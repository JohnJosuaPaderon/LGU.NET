using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;

namespace LGU.ViewModels.HumanResource
{
    public class SalaryGradeManagementViewModel : ViewModelBase, INavigationAware
    {
        public SalaryGradeManagementViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            ChangePageCommand = new DelegateCommand<object>(ChangePage);
            NavigateCommand = new DelegateCommand<string>(Navigate);

            r_ChangeHeaderEvent.Publish("Salary Grades");
        }

        public DelegateCommand<object> ChangePageCommand { get; }
        public DelegateCommand<string> NavigateCommand { get; }

        private int _SelectedCreatePage;
        public int SelectedCreatePage
        {
            get { return _SelectedCreatePage; }
            set { SetProperty(ref _SelectedCreatePage, value); }
        }

        private void ChangePage(object pageIndex)
        {
            SelectedCreatePage = Convert.ToInt32(pageIndex);
        }

        protected override void Initialize()
        {
            ChangePage(0);
        }

        private void Navigate(string view)
        {
            r_RegionManager.RequestNavigate(MainViewModel.MainViewContentRegion, view);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            r_ChangeHeaderEvent.Publish("Salary Grades");
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
