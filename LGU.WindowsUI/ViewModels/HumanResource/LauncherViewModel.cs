using LGU.Views.HumanResource;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;

namespace LGU.ViewModels.HumanResource
{
    public sealed class LauncherViewModel : ViewModelBase
    {
        public LauncherViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            NavigateCommand = new DelegateCommand<string>(Navigate);

            r_TitleEvent.Publish("Human Resource & Development Office");
        }

        public DelegateCommand<string> NavigateCommand { get; }

        private void Navigate(string view)
        {
            var parameters = new NavigationParameters
            {
                { "view", view }
            };

            r_RegionManager.RequestNavigate(MainWindowViewModel.MainContentRegionName, nameof(MainView), parameters);
        }
    }
}
