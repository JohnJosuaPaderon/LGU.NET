using LGU.EntityManagers.HumanResource;
using LGU.Models;
using LGU.Models.HumanResource;
using LGU.Processes;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace LGU.ViewModels.HumanResource
{
    public sealed class ActualTimeLogExportViewModel : ViewModelBase
    {
        public ActualTimeLogExportViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            r_EmployeeManager = ApplicationDomain.GetService<IEmployeeManager>();
            r_TimeLogManager = ApplicationDomain.GetService<ITimeLogManager>();

            Employees = new ObservableCollection<EmployeeModel>();
            TimeLogs = new ObservableCollection<TimeLogModel>();
            GetEmployeesCommand = new DelegateCommand(GetEmployees);
            GetTimeLogsCommand = new DelegateCommand(GetTimeLogs);
            CutOff = new ValueRangeModel<DateTime>(new ValueRange<DateTime>(DateTime.Now));

            _ChangeHeaderEvent.Publish("Actual Time Logs");
        }

        private readonly IEmployeeManager r_EmployeeManager;
        private readonly ITimeLogManager r_TimeLogManager;

        public DelegateCommand GetEmployeesCommand { get; }
        public DelegateCommand SearchEmployeesCommand { get; }
        public DelegateCommand GetTimeLogsCommand { get; }
        public ObservableCollection<EmployeeModel> Employees { get; }
        public ObservableCollection<TimeLogModel> TimeLogs { get; }

        private ValueRangeModel<DateTime> _CutOff;
        public ValueRangeModel<DateTime> CutOff
        {
            get { return _CutOff; }
            set { SetProperty(ref _CutOff, value); }
        }

        private EmployeeModel _SelectedEmployee;
        public EmployeeModel SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set { SetProperty(ref _SelectedEmployee, value); }
        }

        private string _EmployeeSearchKey;
        public string EmployeeSearchKey
        {
            get { return _EmployeeSearchKey; }
            set { SetProperty(ref _EmployeeSearchKey, value); }
        }

        private async void GetEmployees()
        {
            Employees.Clear();
            var cutOff = CutOff.GetSource();
            var result = await (string.IsNullOrWhiteSpace(EmployeeSearchKey) ? r_EmployeeManager.GetListWithTimeLogAsync(cutOff) : r_EmployeeManager.SearchWithTimeLogAsync(EmployeeSearchKey, cutOff));

            if (result.Status == ProcessResultStatus.Success)
            {
                if (result.DataList != null && result.DataList.Count() > 0)
                {
                    foreach (var item in result.DataList)
                    {
                        Employees.Add(new EmployeeModel(item));
                    }

                    EnqueueListCountMessage(Employees.Count(), "employee");
                }
                else
                {
                    EnqueueMessage("No employees.");
                }
            }
            else
            {
                EnqueueMessage(result.Message);
            }
        }

        private async void GetTimeLogs()
        {
            TimeLogs.Clear();
            var result = await r_TimeLogManager.GetActualListByEmployeeCutOffAsync(SelectedEmployee?.GetSource(), CutOff.GetSource());

            if (result.Status == ProcessResultStatus.Success)
            {
                if (result.DataList != null && result.DataList.Count() > 0)
                {
                    foreach (var item in result.DataList)
                    {
                        TimeLogs.Add(new TimeLogModel(item));
                    }
                }
            }
            else
            {
                EnqueueMessage(result.Message);
            }
        }
    }
}
