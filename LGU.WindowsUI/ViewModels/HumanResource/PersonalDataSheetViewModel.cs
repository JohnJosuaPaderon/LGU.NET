using LGU.Models.HumanResource;
using Prism.Events;
using Prism.Regions;

namespace LGU.ViewModels.HumanResource
{
    public class PersonalDataSheetViewModel : ViewModelBase, INavigationAware
    {
        public PersonalDataSheetViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
        }

        public EmployeeModel CurrentEmployee { get; set; }

        protected override void Initialize()
        {
            _ChangeHeaderEvent.Publish("Personal Data Sheet");
        }

        #region INavigationAware
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            CurrentEmployee = navigationContext.Parameters["employee"] as EmployeeModel;
        } 
        #endregion
    }
}
