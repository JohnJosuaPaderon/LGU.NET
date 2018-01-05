using LGU.EntityManagers.HumanResource;
using Prism.Commands;
using System.Collections.ObjectModel;

namespace LGU.ViewModels.HumanResource.Dialogs
{
    partial class AddEditTimeLogDialogViewModel
    {
        private const string CONFIG_MIN_YEAR_COVERAGE = "HumanResource.TimeLog.MinYearCoverage";
        private const int MONTHS_COUNT = 12;
        private const int MAX_HOUR = 24;
        private const int MAX_MINUTE = 60;
        private const int MAX_SECOND = 60;

        private readonly ITimeLogManager _TimeLogManager;
        private readonly int _MinYearCoverage;

        public DelegateCommand SaveCommand { get; }
        public DelegateCommand<string> ChangePageCommand { get; }
        public DelegateCommand LoginToggleCommand { get; }
        public DelegateCommand LogoutToggleCommand { get; }
        public ObservableCollection<int?> LoginYears { get; }
        public ObservableCollection<int?> LoginMonths { get; }
        public ObservableCollection<int?> LoginDays { get; }
        public ObservableCollection<int?> LoginHours { get; }
        public ObservableCollection<int?> LoginMinutes { get; }
        public ObservableCollection<int?> LoginSeconds { get; }
        public ObservableCollection<int?> LogoutYears { get; }
        public ObservableCollection<int?> LogoutMonths { get; }
        public ObservableCollection<int?> LogoutDays { get; }
        public ObservableCollection<int?> LogoutHours { get; }
        public ObservableCollection<int?> LogoutMinutes { get; }
        public ObservableCollection<int?> LogoutSeconds { get; }

        private int _SelectedPage;
        public int SelectedPage
        {
            get { return _SelectedPage; }
            set { SetProperty(ref _SelectedPage, value); }
        }

        private int? _SelectedLoginYear;
        public int? SelectedLoginYear
        {
            get { return _SelectedLoginYear; }
            set { SetProperty(ref _SelectedLoginYear, value, LoadLoginDays); }
        }

        private int? _SelectedLoginMonth;
        public int? SelectedLoginMonth
        {
            get { return _SelectedLoginMonth; }
            set { SetProperty(ref _SelectedLoginMonth, value, LoadLoginDays); }
        }

        private int? _SelectedLoginDay;
        public int? SelectedLoginDay
        {
            get { return _SelectedLoginDay; }
            set { SetProperty(ref _SelectedLoginDay, value); }
        }

        private int? _SelectedLoginHour;
        public int? SelectedLoginHour
        {
            get { return _SelectedLoginHour; }
            set { SetProperty(ref _SelectedLoginHour, value); }
        }

        private int? _SelectedLoginMinute;
        public int? SelectedLoginMinute
        {
            get { return _SelectedLoginMinute; }
            set { SetProperty(ref _SelectedLoginMinute, value); }
        }

        private int? _SelectedLoginSecond;
        public int? SelectedLoginSecond
        {
            get { return _SelectedLoginSecond; }
            set { SetProperty(ref _SelectedLoginSecond, value); }
        }

        private int? _SelectedLogoutYear;
        public int? SelectedLogoutYear
        {
            get { return _SelectedLogoutYear; }
            set { SetProperty(ref _SelectedLogoutYear, value, LoadLogoutDays); }
        }

        private int? _SelectedLogoutMonth;
        public int? SelectedLogoutMonth
        {
            get { return _SelectedLogoutMonth; }
            set { SetProperty(ref _SelectedLogoutMonth, value, LoadLogoutDays); }
        }

        private int? _SelectedLogoutDay;
        public int? SelectedLogoutDay
        {
            get { return _SelectedLogoutDay; }
            set { SetProperty(ref _SelectedLogoutDay, value); }
        }

        private int? _SelectedLogoutHour;
        public int? SelectedLogoutHour
        {
            get { return _SelectedLogoutHour; }
            set { SetProperty(ref _SelectedLogoutHour, value); }
        }

        private int? _SelectedLogoutMinute;
        public int? SelectedLogoutMinute
        {
            get { return _SelectedLogoutMinute; }
            set { SetProperty(ref _SelectedLogoutMinute, value); }
        }

        private int? _SelectedLogoutSecond;
        public int? SelectedLogoutSecond
        {
            get { return _SelectedLogoutSecond; }
            set { SetProperty(ref _SelectedLogoutSecond, value); }
        }

        private bool _SetLogin;
        public bool SetLogin
        {
            get { return _SetLogin; }
            set { SetProperty(ref _SetLogin, value); }
        }

        private bool _SetLogout;
        public bool SetLogout
        {
            get { return _SetLogout; }
            set { SetProperty(ref _SetLogout, value); }
        }
    }
}
