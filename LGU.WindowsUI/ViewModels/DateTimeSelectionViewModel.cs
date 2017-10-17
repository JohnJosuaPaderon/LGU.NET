using Prism.Commands;
using Prism.Events;
using System;

namespace LGU.ViewModels
{
    public sealed class DateTimeSelectionViewModel : PopupViewModelBase
    {
        public DateTimeSelectionViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            DoneCommand = new DelegateCommand(Done);
        }

        public DelegateCommand DoneCommand { get; }

        private DateTime _SelectedDate;
        public DateTime SelectedDate
        {
            get { return _SelectedDate; }
            set { SetProperty(ref _SelectedDate, value); }
        }

        private void Done()
        {
            if (Content is DateTimeSelectionContent content)
            {
                content.SelectedDate = SelectedDate;
                Close();
            }
        }
    }
}
