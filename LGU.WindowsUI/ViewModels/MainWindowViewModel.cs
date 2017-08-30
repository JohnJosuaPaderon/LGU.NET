using LGU.EntityManagers;
using LGU.Events;
using MaterialDesignThemes.Wpf;
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
            r_SystemManager = ApplicationDomain.GetService<ISystemManager>();
            r_TitleEvent.Subscribe(t => Title = t);
            r_ShowCloseButtonEvent.Subscribe(arg => ShowCloseButton = arg);
            r_ShowMinButtonEvent.Subscribe(arg => ShowMinButton = arg);
            r_ShowMaxRestorButtonEvent.Subscribe(arg => ShowMaxRestoreButton = arg);
            r_ShowTitleBarEvent.Subscribe(arg => ShowTitleBar = arg);
            r_AccountDisplayEvent.Subscribe(arg => AccountDisplay = arg);
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

        private bool _ShowCloseButton = true;
        public bool ShowCloseButton
        {
            get { return _ShowCloseButton; }
            set { SetProperty(ref _ShowCloseButton, value); }
        }

        private bool _ShowMinButton = true;
        public bool ShowMinButton
        {
            get { return _ShowMinButton; }
            set { SetProperty(ref _ShowMinButton, value); }
        }

        private bool _ShowMaxRestoreButton = true;
        public bool ShowMaxRestoreButton
        {
            get { return _ShowMaxRestoreButton; }
            set { SetProperty(ref _ShowMaxRestoreButton, value); }
        }

        private bool _ShowTitleBar = true;
        public bool ShowTitleBar
        {
            get { return _ShowTitleBar; }
            set { SetProperty(ref _ShowTitleBar, value); }
        }

        private bool _AccountDisplay = true;
        public bool AccountDisplay
        {
            get { return _AccountDisplay; }
            set { SetProperty(ref _AccountDisplay, value); }
        }

        public override void Initialize()
        {
            r_EventAggregator.GetEvent<WindowStateEvent>().Subscribe(ws => WindowState = ws);
            r_EventAggregator.GetEvent<NewMessageEvent>().Subscribe(nm => MessageQueue.Enqueue(nm));

            if (!string.IsNullOrWhiteSpace(InitialMainContentRegionSource))
            {
                r_RegionManager.RequestNavigate(MainContentRegionName, InitialMainContentRegionSource);
            }
        }
    }
}
