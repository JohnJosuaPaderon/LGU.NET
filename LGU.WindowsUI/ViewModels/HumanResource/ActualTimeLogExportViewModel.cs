using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Models;
using LGU.Models.HumanResource;
using LGU.Processes;
using LGU.Reports;
using LGU.Reports.HumanResource;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LGU.ViewModels.HumanResource
{
    public sealed class ActualTimeLogExportViewModel : ViewModelBase, IExportEventHandler
    {
        public ActualTimeLogExportViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            _EmployeeManager = ApplicationDomain.GetService<IEmployeeManager>();
            _TimeLogManager = ApplicationDomain.GetService<ITimeLogManager>();
            _HumanResourceReport = ApplicationDomain.GetService<IHumanResourceReport>();

            Employees = new ObservableCollection<EmployeeModel>();
            TimeLogs = new ObservableCollection<TimeLogModel>();
            GetEmployeesCommand = new DelegateCommand(GetEmployees);
            GetTimeLogsCommand = new DelegateCommand(GetTimeLogs);
            ExportCommand = new DelegateCommand(Export);
            CutOff = new ValueRangeModel<DateTime>(new ValueRange<DateTime>(DateTime.Now));

            _HeaderEvent.Publish("Actual Time Logs");
        }

        private readonly IEmployeeManager _EmployeeManager;
        private readonly ITimeLogManager _TimeLogManager;
        private readonly IHumanResourceReport _HumanResourceReport;

        public DelegateCommand GetEmployeesCommand { get; }
        public DelegateCommand SearchEmployeesCommand { get; }
        public DelegateCommand GetTimeLogsCommand { get; }
        public DelegateCommand ExportCommand { get; }
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

        private async void Export()
        {
            if (SelectedEmployee != null && CutOff != null && TimeLogs.Any())
            {
                _BusyAppEvent.Busy();
                var timeLogs = new List<ITimeLog>();

                foreach (var timeLog in TimeLogs)
                {
                    timeLogs.Add(timeLog.GetSource());
                }

                try
                {
                    await _HumanResourceReport.ExportActualTimeLogAsync(SelectedEmployee.GetSource(), timeLogs, CutOff.GetSource(), this);
                }
                catch (Exception ex)
                {
                    _NewMessageEvent.EnqueueException(ex);
                }

                _BusyAppEvent.Unbusy();
            }
        }
        
        private async void GetEmployees()
        {
            Employees.Clear();
            var cutOff = CutOff.GetSource();
            var result = await (string.IsNullOrWhiteSpace(EmployeeSearchKey) ? _EmployeeManager.GetListWithTimeLogAsync(cutOff) : _EmployeeManager.SearchWithTimeLogAsync(EmployeeSearchKey, cutOff));

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
            var result = await _TimeLogManager.GetActualListByEmployeeCutOffAsync(SelectedEmployee?.GetSource(), CutOff.GetSource());

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

        public void OnException(Exception exception)
        {
            _NewMessageEvent.EnqueueException(exception);
        }

        public void OnError(string message)
        {
            _NewMessageEvent.EnqueueErrorMessage(message);
        }

        public void OnExported(string[] filePaths)
        {
            _NewMessageEvent.EnqueueMessage("Successfully exported.");
        }

        public void OnExported(string filePath)
        {
            _NewMessageEvent.EnqueueMessage("Successfully exported.");
        }
    }
}
