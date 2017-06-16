using LGU.Core.Events;
using LGU.Core.Views;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;

namespace LGU.Core.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public const string CONTENT_REGION = "ContentRegion";
        public static string ContentRegionMainTarget { get; set; } = nameof(UserAuthenticationView);

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            RegionManager = regionManager;
            eventAggregator.GetEvent<WindowTitleEvent>().Subscribe((t) => Title = t);
        }

        private IRegionManager RegionManager { get; }

        public void Initialize()
        {
            Title = "Welcome to LGU.NET";
            WindowState = WindowState.Maximized;

            if (MainWindowRedirectionOptions.Instance.RedirectToTarget)
            {
                RegionManager.RequestNavigate(CONTENT_REGION, MainWindowRedirectionOptions.Instance.Target);
            }
            else
            {
                RegionManager.RequestNavigate(CONTENT_REGION, nameof(UserAuthenticationView));
            }
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
