using Prism.Events;
using Prism.Regions;

namespace LGU.ViewModels
{
    public abstract class DialogViewModelBase : ViewModelBase
    {
        public DialogViewModelBase(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            MinDialogHeight = 100;
            MinDialogWidth = 500;
        }

        private string _HeaderTitle;
        public string HeaderTitle
        {
            get { return _HeaderTitle; }
            set { SetProperty(ref _HeaderTitle, value); }
        }

        private string _MessageLog;
        public string MessageLog
        {
            get { return _MessageLog; }
            set { SetProperty(ref _MessageLog, value); }
        }

        private double _MinDialogHeight;
        public double MinDialogHeight
        {
            get { return _MinDialogHeight; }
            set { SetProperty(ref _MinDialogHeight, value); }
        }

        private double _MinDialogWidth;
        public double MinDialogWidth
        {
            get { return _MinDialogWidth; }
            set { SetProperty(ref _MinDialogWidth, value); }
        }

        private DialogMode _Mode;
        public DialogMode Mode
        {
            get { return _Mode; }
            set { SetProperty(ref _Mode, value); }
        }

        protected override void ShowErrorMessage(string message)
        {
            ShowErrorMessage(message, HeaderTitle);
        }

        protected override void ShowInfoMessage(string message)
        {
            ShowInfoMessage(message, HeaderTitle);
        }

        protected override void ShowWarningMessage(string message)
        {
            ShowWarningMessage(message, HeaderTitle);
        }
    }
}
