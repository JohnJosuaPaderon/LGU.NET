using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using LGU.Views.HumanResource;

namespace LGU.ViewModels.HumanResource
{
    public sealed class LauncherViewModel : ViewModelBase
    {
        public LauncherViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        public DelegateCommand<string> NavigateCommand { get; }

        private void Navigate(string view)
        {
            var parameters = new NavigationParameters
            {
                { "view", view }
            };

            RegionManager.RequestNavigate(MainWindowViewModel.MainContentRegionName, nameof(MainView), parameters);
        }
    }
}
