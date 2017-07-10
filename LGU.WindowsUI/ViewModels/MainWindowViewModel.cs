using LGU.EntityManagers;
using LGU.Events;
using Microsoft.Extensions.DependencyInjection;
using Prism.Events;
using Prism.Regions;
using System.Windows;

namespace LGU.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static string MainContentRegionName { get; } = "MainContentRegion";
        public static string MainDialogName { get; } = "MainDialog";
        public static string InitialMainContentRegionSource { get; set; }

        private readonly ISystemManager SystemManager;

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            SystemManager = SystemRuntime.Services.GetService<ISystemManager>();
        }

        private string _Title = "Welcome to LGU.NET";
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        private WindowState _WindowState = WindowState.Maximized;
        public WindowState WindowState
        {
            get { return _WindowState; }
            set { SetProperty(ref _WindowState, value); }
        }

        public async override void Initialize()
        {
            EventAggregator.GetEvent<TitleEvent>().Subscribe(t => Title = t);
            EventAggregator.GetEvent<WindowStateEvent>().Subscribe(ws => WindowState = ws);

            if (!string.IsNullOrWhiteSpace(InitialMainContentRegionSource))
            {
                RegionManager.RequestNavigate(MainContentRegionName, InitialMainContentRegionSource);
            }

            var result = await SystemManager.GetSystemDateAsync();

            if (result.Status == ProcessResultStatus.Success)
            {
                EventAggregator.GetEvent<TitleEvent>().Publish("LGU.NET (Administrator)");
            }
            else
            {
                MessageBox.Show("Failed to get system date.");
            }
        }
    }
}
