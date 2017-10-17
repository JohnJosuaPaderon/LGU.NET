using Prism.Mvvm;
using System;

namespace LGU.ViewModels
{
    public sealed class DateTimeSelectionContent : BindableBase
    {
        public DateTimeSelectionContent()
        {
            Header = "Select a Date...";
        }

        private string _Header;
        public string Header
        {
            get { return _Header; }
            set { SetProperty(ref _Header, value); }
        }

        private DateTime _SelectedDate;
        public DateTime SelectedDate
        {
            get { return _SelectedDate; }
            set { SetProperty(ref _SelectedDate, value); }
        }
    }
}
