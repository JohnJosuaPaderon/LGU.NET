using LGU.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace LGU.ViewModels
{
    public abstract class PopupViewModelBase : BindableBase, IInteractionRequestAware
    {
        public PopupViewModelBase(IEventAggregator eventAggregator)
        {
            _EventAggregator = eventAggregator;
            _NewMessageEvent = _EventAggregator.GetEvent<NewMessageEvent>();

            CloseCommand = new DelegateCommand(Close);
            ResetMouseCaptureCommand = new DelegateCommand(ResetMouseCapture);
        }

        protected readonly IEventAggregator _EventAggregator;
        protected readonly NewMessageEvent _NewMessageEvent;

        public DelegateCommand CloseCommand { get; }
        public DelegateCommand ResetMouseCaptureCommand { get; }
        public Action FinishInteraction { get; set; }

        private INotification _Notification;
        public INotification Notification
        {
            get { return _Notification; }
            set { SetProperty(ref _Notification, value, () => Content = value.Content); }
        }

        public object Content
        {
            get { return Notification?.Content; }
            set
            {
                Notification.Content = value;
                RaisePropertyChanged();
            }
        }

        private void Close()
        {
            FinishInteraction?.Invoke();
        }
        private void ResetMouseCapture()
        {
            Mouse.Capture(null);
        }
    }
}
