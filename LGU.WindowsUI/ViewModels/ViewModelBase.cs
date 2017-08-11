using LGU.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace LGU.ViewModels
{
    public abstract class ViewModelBase : BindableBase
    {
        public ViewModelBase(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            r_RegionManager = regionManager;
            r_EventAggregator = eventAggregator;
            r_TitleEvent = r_EventAggregator.GetEvent<TitleEvent>();
            r_ChangeHeaderEvent = r_EventAggregator.GetEvent<ChangeHeaderEvent>();
            r_NewMessageEvent = r_EventAggregator.GetEvent<NewMessageEvent>();
            r_ShowCloseButtonEvent = r_EventAggregator.GetEvent<ShowCloseButtonEvent>();
            r_ShowMinButtonEvent = r_EventAggregator.GetEvent<ShowMinButtonEvent>();
            r_ShowMaxRestorButtonEvent = r_EventAggregator.GetEvent<ShowMaxRestoreButtonEvent>();
            r_ShowTitleBarEvent = r_EventAggregator.GetEvent<ShowTitleBarEvent>();

            ResetMouseCaptureCommand = new DelegateCommand(ResetMouseCapture);
        }

        protected readonly IRegionManager r_RegionManager;
        protected readonly IEventAggregator r_EventAggregator;
        protected readonly NewMessageEvent r_NewMessageEvent;
        protected readonly TitleEvent r_TitleEvent;
        protected readonly ChangeHeaderEvent r_ChangeHeaderEvent;
        protected readonly ShowCloseButtonEvent r_ShowCloseButtonEvent;
        protected readonly ShowMinButtonEvent r_ShowMinButtonEvent;
        protected readonly ShowMaxRestoreButtonEvent r_ShowMaxRestorButtonEvent;
        protected readonly ShowTitleBarEvent r_ShowTitleBarEvent;

        public DelegateCommand ResetMouseCaptureCommand { get; }

        private void ResetMouseCapture()
        {
            Mouse.Capture(null);
        }

        public virtual void Initialize()
        {
            Debug.WriteLine("ViewModel has been Loaded.");
        }

        protected void ShowInfoMessage(string message, string header)
        {
            MessageBox.Show(message, header, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        protected virtual void ShowInfoMessage(string message)
        {
            ShowInfoMessage(message, "LGU.NET");
        }

        protected void ShowWarningMessage(string message, string header)
        {
            MessageBox.Show(message, header, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        protected virtual void ShowWarningMessage(string message)
        {
            ShowWarningMessage(message, "LGU.NET");
        }

        protected void ShowErrorMessage(string message, string header)
        {
            MessageBox.Show(message, header, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        protected virtual void ShowErrorMessage(string message)
        {
            ShowErrorMessage(message, "LGU.NET");
        }

        protected virtual void EnqueueMessage(string message)
        {
            r_NewMessageEvent.Publish(message);
        }

        protected virtual void EnqueueListCountMessage(int items, string singularMark, string pluralMark)
        {
            r_NewMessageEvent.Publish($"Found {items.ToString("#,##0")} {(items > 1 ? pluralMark : singularMark)}");
        }

        protected virtual void EnqueueListCountMessage(int items, string mark)
        {
            EnqueueListCountMessage(items, mark, $"{mark}s");
        }
    }
}
