using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Timers;
using System.Windows;

namespace LGU.HumanResource.ViewModels
{
    public class TimeLogViewModel : BindableBase
    {
        public TimeLogViewModel()
        {
            Timer = new Timer(1000);
            Timer.Elapsed += Timer_Elapsed;
            Timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Application.Current?.Dispatcher.Invoke(() => { CurrentTimeStamp = DateTime.Now; });
        }

        private Timer Timer { get; }

        public ObservableCollection<char> Hour1Source { get; } = new ObservableCollection<char>() { 'h', '0', '1' };
        public ObservableCollection<char> Hour2Source { get; } = new ObservableCollection<char>() { 'h', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public ObservableCollection<char> Minute1Source { get; } = new ObservableCollection<char>() { 'm', '0', '1', '2', '3', '4', '5' };
        public ObservableCollection<char> Minute2Source { get; } = new ObservableCollection<char>() { 'm', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public ObservableCollection<char> Second1Source { get; } = new ObservableCollection<char>() { 's' , '0', '1', '2', '3', '4', '5' };
        public ObservableCollection<char> Second2Source { get; } = new ObservableCollection<char>() { 's', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public ObservableCollection<string> AmPmSource { get; } = new ObservableCollection<string>() { "tt",  "AM", "PM" };

        private DateTime? _CurrentTimeStamp;
        public DateTime? CurrentTimeStamp
        {
            get { return _CurrentTimeStamp; }
            set { SetProperty(ref _CurrentTimeStamp, value, () =>
            {
                var currentTimeStamp = value ?? DateTime.Now;
                var hours = currentTimeStamp.ToString("hh");
                var minutes = currentTimeStamp.ToString("mm");
                var seconds = currentTimeStamp.ToString("ss");

                SelectedAmPm = currentTimeStamp.ToString("tt");
                SelectedHour1 = hours[0];
                SelectedHour2 = hours[1];
                SelectedMinute1 = minutes[0];
                SelectedMinute2 = minutes[1];
                SelectedSecond1 = seconds[0];
                SelectedSecond2 = seconds[1];

                SelectedResult =
                    currentTimeStamp.Second % 3 == 0 ? 0 : 
                    currentTimeStamp.Second % 2 == 0 ? 1 : 2;
            }); }
        }

        private char _SelectedHour1 = 'h';
        public char SelectedHour1
        {
            get { return _SelectedHour1; }
            set { SetProperty(ref _SelectedHour1, value); }
        }

        private char _SelectedHour2 = 'h';
        public char SelectedHour2
        {
            get { return _SelectedHour2; }
            set { SetProperty(ref _SelectedHour2, value); }
        }

        private char _SelectedMinute1 = 'm';
        public char SelectedMinute1
        {
            get { return _SelectedMinute1; }
            set { SetProperty(ref _SelectedMinute1, value); }
        }

        private char _SelectedMinute2 = 'm';
        public char SelectedMinute2
        {
            get { return _SelectedMinute2; }
            set { SetProperty(ref _SelectedMinute2, value); }
        }

        private char _SelectedSecond1 = 's';
        public char SelectedSecond1
        {
            get { return _SelectedSecond1; }
            set { SetProperty(ref _SelectedSecond1, value); }
        }

        private char _SelectedSecond2 = 's';
        public char SelectedSecond2
        {
            get { return _SelectedSecond2; }
            set { SetProperty(ref _SelectedSecond2, value); }
        }

        private string _SelectedAmPm = "tt";
        public string SelectedAmPm
        {
            get { return _SelectedAmPm; }
            set { SetProperty(ref _SelectedAmPm, value); }
        }

        private int _SelectedResult;
        public int SelectedResult
        {
            get { return _SelectedResult; }
            set { SetProperty(ref _SelectedResult, value); }
        }
    }
}
