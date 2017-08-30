using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Events.HumanResource;
using LGU.Models;
using LGU.Models.HumanResource;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace LGU.ViewModels.HumanResource
{
    public sealed class KioskActualTimeLogViewModel : ViewModelBase
    {
        public KioskActualTimeLogViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            if (Employee == null)
            {
                Employee = MainKioskViewModel.SelectedKioskEmployee;
            }

            r_TimeLogManager = ApplicationDomain.GetService<ITimeLogManager>();
            r_KioskEmployeeChangedEvent = r_EventAggregator.GetEvent<KioskEmployeeChangedEvent>();

            TimeLogs = new ObservableCollection<ITimeLog>();
            GetTimeLogsCommand = new DelegateCommand(GetTimeLogs);

            CutOff = new ValueRangeModel<DateTime>(new ValueRange<DateTime>(DateTime.Now));
            r_KioskEmployeeChangedEvent.Subscribe(OnKioskEmployeeChanged);
        }

        private readonly ITimeLogManager r_TimeLogManager;
        private readonly KioskEmployeeChangedEvent r_KioskEmployeeChangedEvent;

        public ObservableCollection<ITimeLog> TimeLogs { get; }
        public DelegateCommand GetTimeLogsCommand { get; }

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
                var result = await r_TimeLogManager.GetActualListByEmployeeCutOffAsync(Employee.GetSource(), CutOff.GetSource());

                if (result.DataList != null && result.DataList.Any())
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

        private void OnKioskEmployeeChanged(EmployeeModel employee)
        {
            Employee = employee;
            GetTimeLogs();
        }
    }
}
