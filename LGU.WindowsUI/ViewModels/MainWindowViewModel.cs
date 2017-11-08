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

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            _SystemManager = ApplicationDomain.GetService<ISystemManager>();

            _TitleEvent.Subscribe(t => Title = t);
            _ShowCloseButtonEvent.Subscribe(arg => ShowCloseButton = arg);
            _ShowMinButtonEvent.Subscribe(arg => ShowMinButton = arg);
            _ShowMaxRestorButtonEvent.Subscribe(arg => ShowMaxRestoreButton = arg);
            _ShowTitleBarEvent.Subscribe(arg => ShowTitleBar = arg);
            _AccountDisplayEvent.Subscribe(arg => AccountDisplay = arg);

            _MessageQueue = new SnackbarMessageQueue(new System.TimeSpan(0, 0, 1));
        }

        private readonly ISystemManager _SystemManager;

        private string _Title = "Welcome to LGU.NET";
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        private SnackbarMessageQueue _MessageQueue;
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

        protected override void Initialize()
        {
            _EventAggregator.GetEvent<WindowStateEvent>().Subscribe(ws => WindowState = ws);
            _EventAggregator.GetEvent<NewMessageEvent>().Subscribe(nm => MessageQueue.Enqueue(nm));

            if (!string.IsNullOrWhiteSpace(InitialMainContentRegionSource))
            {
                _RegionManager.RequestNavigate(MainContentRegionName, InitialMainContentRegionSource);
            }
        }
    }
}
