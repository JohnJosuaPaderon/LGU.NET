using LGU.EntityManagers;
using LGU.Events;
using MaterialDesignThemes.Wpf;
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

        private readonly ISystemManager r_SystemManager;

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            r_SystemManager = SystemRuntime.Services.GetService<ISystemManager>();
        }

        private string _Title = "Welcome to LGU.NET";
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        private SnackbarMessageQueue _MessageQueue = new SnackbarMessageQueue();
        public SnackbarMessageQueue MessageQueue
        {
            get { return _MessageQueue; }
            set { SetProperty(ref _MessageQueue, value); }
        }

        private WindowState _WindowState = WindowState.Maximized;
        public WindowState WindowState
        {
            get { return _WindowState; }
            set { SetProperty(ref _WindowState, value); }
        }

        public override void Initialize()
        {
            r_EventAggregator.GetEvent<TitleEvent>().Subscribe(t => Title = t);
            r_EventAggregator.GetEvent<WindowStateEvent>().Subscribe(ws => WindowState = ws);
            r_EventAggregator.GetEvent<NewMessageEvent>().Subscribe(nm => MessageQueue.Enqueue(nm));

            if (!string.IsNullOrWhiteSpace(InitialMainContentRegionSource))
            {
                r_RegionManager.RequestNavigate(MainContentRegionName, InitialMainContentRegionSource);
            }
            r_EventAggregator.GetEvent<NewMessageEvent>().Publish("Hello");
        }
    }
}
