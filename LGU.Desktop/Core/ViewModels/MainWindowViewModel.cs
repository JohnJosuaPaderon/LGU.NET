using LGU.Core.Views;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;

namespace LGU.Core.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public const string CONTENT_REGION = "ContentRegion";

        public MainWindowViewModel(IRegionManager regionManager)
        {
            RegionManager = regionManager;
        }

        private IRegionManager RegionManager { get; }

        public void Initialize()
        {
            RegionManager.RequestNavigate(CONTENT_REGION, nameof(UserLoginView));
            Title = "Welcome to LGU.NET";
            WindowState = WindowState.Maximized;
        }

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        private WindowState _WindowState;
        public WindowState WindowState
        {
            get { return _WindowState; }
            set { SetProperty(ref _WindowState, value); }
        }
    }
}
