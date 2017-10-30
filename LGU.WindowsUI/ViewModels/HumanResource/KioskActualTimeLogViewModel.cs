using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Events.HumanResource;
using LGU.Models;
using LGU.Models.HumanResource;
using LGU.Reports;
using LGU.Reports.HumanResource;
using LGU.Views.HumanResource;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LGU.ViewModels.HumanResource
{
    public sealed class KioskActualTimeLogViewModel : ViewModelBase, IExportEventHandler
    {
        public KioskActualTimeLogViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            if (Employee == null)
            {
                Employee = MainKioskViewModel.SelectedKioskEmployee;
            }

            _TimeLogManager = ApplicationDomain.GetService<ITimeLogManager>();
            _KioskEmployeeChangedEvent = _EventAggregator.GetEvent<KioskEmployeeChangedEvent>();
            _HumanResourceReport = ApplicationDomain.GetService<IHumanResourceReport>();

            TimeLogs = new ObservableCollection<ITimeLog>();
            GetTimeLogsCommand = new DelegateCommand(GetTimeLogs);
            PrintCommand = new DelegateCommand(Print);

            CutOff = new ValueRangeModel<DateTime>(new ValueRange<DateTime>(DateTime.Now));
            _KioskEmployeeChangedEvent.Subscribe(OnKioskEmployeeChanged);
        }

        private readonly ITimeLogManager _TimeLogManager;
        private readonly KioskEmployeeChangedEvent _KioskEmployeeChangedEvent;
        private readonly IHumanResourceReport _HumanResourceReport;

        private IEnumerable<ITimeLog> RawTimeLogs { get; set; }

        public ObservableCollection<ITimeLog> TimeLogs { get; }
        public DelegateCommand GetTimeLogsCommand { get; }
        public DelegateCommand PrintCommand { get; }

        private ValueRangeModel<DateTime> _CutOff;
        public ValueRangeModel<DateTime> CutOff
        {
            get { return _CutOff; }
            set { SetProperty(ref _CutOff, value); }
        }

        private EmployeeModel _Employee;
        public EmployeeModel Employee
        {
            get { return _Employee; }
            set { SetProperty(ref _Employee, value); }
        }

        private async void GetTimeLogs()
        {
            if (Employee != null)
            {
                TimeLogs.Clear();
                var result = await _TimeLogManager.GetActualListByEmployeeCutOffAsync(Employee.GetSource(), CutOff.GetSource());

                RawTimeLogs = result.DataList;

                if (RawTimeLogs != null && RawTimeLogs.Any())
                {
                    foreach (var item in result.DataList)
                    {
                        TimeLogs.Add(item);
                    }
                }
                else
                {
                    EnqueueMessage("No time-logs.");
                }
            }
            else
            {
                EnqueueMessage("Invalid employee.");
            }
        }

        private async void Print()
        {
            if (Employee != null && RawTimeLogs != null && RawTimeLogs.Any())
            {
                await _HumanResourceReport.ExportActualTimeLogAsync(Employee.GetSource(), RawTimeLogs, CutOff.GetSource(), this);
                _RegionManager.RequestNavigate(MainKioskViewModel.KioskContentRegion, nameof(KioskServiceSelectionView));
            }
            else
            {
                EnqueueMessage("Cannot be printed.");
            }
        }

        private void OnKioskEmployeeChanged(EmployeeModel employee)
        {
            Employee = employee;
            GetTimeLogs();
        }

        public void OnException(Exception exception)
        {
            EnqueueMessage(exception.Message);
        }

        public void OnError(string message)
        {
            EnqueueMessage(message);
        }

        public void OnExported(string[] filePaths)
        {
            EnqueueMessage("Exported.");
        }

        public void OnExported(string filePath)
        {
            EnqueueMessage("Exported.");
        }
    }
}
