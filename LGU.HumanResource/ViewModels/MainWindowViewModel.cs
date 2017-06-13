using LGU.Core.Views;
using Prism.Mvvm;
using Prism.Regions;

namespace LGU.HumanResource.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel(IRegionManager regionManager)
        {
            Title = "Welcome to LGU.NET";
            RegionManager = regionManager;
        }

        private IRegionManager RegionManager { get; }

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        public void Initialize()
        {
            RegionManager.RequestNavigate(App.CONTENT_REGION, nameof(UserLoginView));
        }
    }
}
