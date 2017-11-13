using LGU.EntityManagers.HumanResource;
using LGU.Interactivity;
using LGU.Interactivity.HumanResource;
using LGU.Models;
using LGU.Models.HumanResource;
using LGU.Processes;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LGU.ViewModels.HumanResource
{
    public sealed class TimeLogManagementViewModel : ViewModelBase, INavigationAware
    {
        private const string HEADER = "Time-Log Management";

        public TimeLogManagementViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            _EmployeeManager = ApplicationDomain.GetService<IEmployeeManager>();
            _TimeLogManager = ApplicationDomain.GetService<ITimeLogManager>();

            SelectCutOffCommand = new DelegateCommand(SelectCutOff);
            SearchEmployeeCommand = new DelegateCommand(SearchEmployee);
            GetTimeLogsCommand = new DelegateCommand(GetTimeLogs);
            AddTimeLogCommand = new DelegateCommand(AddTimeLog);
            EditTimeLogCommand = new DelegateCommand(EditTimeLog);
            DeleteTimeLogCommand = new DelegateCommand(DeleteTimeLog);
            DateTimeRangeSelectionRequest = new InteractionRequest<IDateTimeRangeSelectionNotification>();
            AddEditTimeLogRequest = new InteractionRequest<IAddEditTimeLogNotification>();
            Employees = new ObservableCollection<EmployeeModel>();
            TimeLogs = new ObservableCollection<TimeLogModel>();
        }

        private readonly IEmployeeManager _EmployeeManager;
        private readonly ITimeLogManager _TimeLogManager;

        public DelegateCommand SelectCutOffCommand { get; }
        public DelegateCommand SearchEmployeeCommand { get; }
        public DelegateCommand GetTimeLogsCommand { get; }
        public DelegateCommand AddTimeLogCommand { get; }
        public DelegateCommand EditTimeLogCommand { get; }
        public DelegateCommand DeleteTimeLogCommand { get; }
        public ObservableCollection<EmployeeModel> Employees { get; }
        public ObservableCollection<TimeLogModel> TimeLogs { get; }
        public InteractionRequest<IDateTimeRangeSelectionNotification> DateTimeRangeSelectionRequest { get; }
        public InteractionRequest<IAddEditTimeLogNotification> AddEditTimeLogRequest { get; }

        private ValueRangeModel<DateTime> _CutOff;
        public ValueRangeModel<DateTime> CutOff
        {
            get { return _CutOff; }
            set { SetProperty(ref _CutOff, value); }
        }

        private string _SearchEmployeeKey;
        public string SearchEmployeeKey
        {
            get { return _SearchEmployeeKey; }
            set { SetProperty(ref _SearchEmployeeKey, value); }
        }

        private EmployeeModel _SelectedEmployee;
        public EmployeeModel SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set { SetProperty(ref _SelectedEmployee, value, GetTimeLogs); }
        }

        private TimeLogModel _SelectedTimeLog;
        public TimeLogModel SelectedTimeLog
        {
            get { return _SelectedTimeLog; }
            set { SetProperty(ref _SelectedTimeLog, value); }
        }

        protected override void Initialize()
        {
            CutOff = ValueRangeModel<DateTime>.TryCreate(DateTime.Now);
        }

        private void SelectCutOff()
        {
            DateTimeRangeSelectionRequest.Raise(new DateTimeRangeSelectionNotification("", CutOff), SelectCutOffCallback);
        }

        private async void SearchEmployee()
        {
            _BusyAppEvent.Busy();

            Employees.Clear();

            var result = await _EmployeeManager.SearchAsync(SearchEmployeeKey);

            if (result.Status == ProcessResultStatus.Success)
            {
                if (result.DataList != null && result.DataList.Any())
                {
                    foreach (var item in result.DataList)
                    {
                        Employees.Add(EmployeeModel.TryCreate(item));
                    }
                }
                else
                {
                    _NewMessageEvent.EnqueueMessage("No result.");
                }
            }
            else
            {
                _NewMessageEvent.EnqueueErrorMessage(result.Message);
            }

            _BusyAppEvent.Unbusy();
        }

        private async void GetTimeLogs()
        {
            await GetTimeLogsAsync();
        }

        private async void AddEditTimeLogCallback(IAddEditTimeLogNotification notification)
        {
            await GetTimeLogsAsync();
        }

        private void AddTimeLog()
        {
            if (SelectedEmployee != null)
            {
                AddEditTimeLogRequest.Raise(AddEditTimeLogNotification.Add(SelectedEmployee.GetSource()), AddEditTimeLogCallback);
            }
            else
            {
                _NewMessageEvent.EnqueueMessage("No selected employee.");
            }
        }

        private void EditTimeLog()
        {
            if (SelectedTimeLog != null)
            {
                AddEditTimeLogRequest.Raise(AddEditTimeLogNotification.Edit(SelectedTimeLog), AddEditTimeLogCallback);
            }
            else
            {
                _NewMessageEvent.EnqueueMessage("No selected time-log.");
            }
        }

        private void DeleteTimeLog()
        {

        }

        private async Task GetTimeLogsAsync()
        {
            TimeLogs.Clear();

            if (SelectedEmployee != null)
            {
                _BusyAppEvent.Busy();

                var result = await _TimeLogManager.GetListByEmployeeCutOffAsync(SelectedEmployee.GetSource(), CutOff.GetSource());

                if (result.Status == ProcessResultStatus.Success)
                {
                    if (result.DataList != null && result.DataList.Any())
                    {
                        foreach (var item in result.DataList)
                        {
                            TimeLogs.Add(TimeLogModel.TryCreate(item));
                        }
                    }
                    else
                    {
                        _NewMessageEvent.EnqueueMessage("Employee has no time-logs within the cut-off specified.");
                    }
                }
                else
                {
                    _NewMessageEvent.EnqueueErrorMessage(result.Message);
                }

                _BusyAppEvent.Unbusy();
            }
        }

        private async void SelectCutOffCallback(IDateTimeRangeSelectionNotification notification)
        {
            await GetTimeLogsAsync();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // TODO:
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _HeaderEvent.Change(HEADER);
        }
    }
}
