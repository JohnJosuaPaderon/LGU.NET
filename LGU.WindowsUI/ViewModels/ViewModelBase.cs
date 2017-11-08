using LGU.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows;
using System.Windows.Input;

namespace LGU.ViewModels
{
    public abstract class ViewModelBase : BindableBase
    {
        public ViewModelBase(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _RegionManager = regionManager;
            _EventAggregator = eventAggregator;
            _TitleEvent = _EventAggregator.GetEvent<TitleEvent>();
            _HeaderEvent = _EventAggregator.GetEvent<HeaderEvent>();
            _NewMessageEvent = _EventAggregator.GetEvent<NewMessageEvent>();
            _ShowCloseButtonEvent = _EventAggregator.GetEvent<ShowCloseButtonEvent>();
            _ShowMinButtonEvent = _EventAggregator.GetEvent<ShowMinButtonEvent>();
            _ShowMaxRestorButtonEvent = _EventAggregator.GetEvent<ShowMaxRestoreButtonEvent>();
            _ShowTitleBarEvent = _EventAggregator.GetEvent<ShowTitleBarEvent>();
            _AccountDisplayEvent = _EventAggregator.GetEvent<AccountDisplayEvent>();

            ResetMouseCaptureCommand = new DelegateCommand(ResetMouseCapture);
            InitializeCommand = new DelegateCommand(Initialize);
        }

        protected readonly IRegionManager _RegionManager;
        protected readonly IEventAggregator _EventAggregator;
        protected readonly NewMessageEvent _NewMessageEvent;
        protected readonly TitleEvent _TitleEvent;
        protected readonly HeaderEvent _HeaderEvent;
        protected readonly ShowCloseButtonEvent _ShowCloseButtonEvent;
        protected readonly ShowMinButtonEvent _ShowMinButtonEvent;
        protected readonly ShowMaxRestoreButtonEvent _ShowMaxRestorButtonEvent;
        protected readonly ShowTitleBarEvent _ShowTitleBarEvent;
        protected readonly AccountDisplayEvent _AccountDisplayEvent;

        public DelegateCommand ResetMouseCaptureCommand { get; }
        public DelegateCommand InitializeCommand { get; }

        private void ResetMouseCapture()
        {
            Mouse.Capture(null);
        }

        protected virtual void Initialize()
        {
        }

        protected void Invoke(Action expression)
        {
            Application.Current?.Dispatcher.Invoke(expression);
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
            _NewMessageEvent.Publish(message);
        }

        protected virtual void EnqueueListCountMessage(int items, string singularMark, string pluralMark)
        {
            _NewMessageEvent.Publish($"Found {items.ToString("#,##0")} {(items > 1 ? pluralMark : singularMark)}");
        }

        protected virtual void EnqueueListCountMessage(int items, string mark)
        {
            EnqueueListCountMessage(items, mark, $"{mark}s");
        }
    }
}
