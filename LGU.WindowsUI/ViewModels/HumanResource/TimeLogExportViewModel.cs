using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Models;
using LGU.Processes;
using LGU.Reports;
using LGU.Reports.HumanResource;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace LGU.ViewModels.HumanResource
{
    public sealed class TimeLogExportViewModel : ViewModelBase, IExportEventHandler
    {
        public TimeLogExportViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            r_DepartmentManager = ApplicationDomain.GetService<IDepartmentManager>();
            r_EmployeeManager = ApplicationDomain.GetService<IEmployeeManager>();
            r_TimeLogManager = ApplicationDomain.GetService<ITimeLogManager>();
            r_HumanResourceReport = ApplicationDomain.GetService<IHumanResourceReport>();

            GetDepartmentCommand = new DelegateCommand(GetDepartment);
            GetEmployeeCommand = new DelegateCommand(GetEmployee);
            PrintCommand = new DelegateCommand(Print);

            Departments = new ObservableCollection<IDepartment>();
            Employees = new ObservableCollection<IEmployee>();
            ExportOptions = new ObservableCollection<TimeLogExportOption>();
            FileSegregations = new ObservableCollection<TimeLogFileSegregation>();

            ExportOptions.Add(TimeLogExportOption.All);
            ExportOptions.Add(TimeLogExportOption.SelectedDepartment);
            ExportOptions.Add(TimeLogExportOption.SelectedEmployee);
            FileSegregations.Add(TimeLogFileSegregation.OneFile);
            FileSegregations.Add(TimeLogFileSegregation.PerDepartment);
            FileSegregations.Add(TimeLogFileSegregation.PerEmployee);
        }

        private readonly IDepartmentManager r_DepartmentManager;
        private readonly IEmployeeManager r_EmployeeManager;
        private readonly ITimeLogManager r_TimeLogManager;
        private readonly IHumanResourceReport r_HumanResourceReport;

        public DelegateCommand GetDepartmentCommand { get; }
        public DelegateCommand GetEmployeeCommand { get; }
        public DelegateCommand PrintCommand { get; }

        public ObservableCollection<IDepartment> Departments { get; }
        public ObservableCollection<IEmployee> Employees { get; }
        public ObservableCollection<TimeLogExportOption> ExportOptions { get; }
        public ObservableCollection<TimeLogFileSegregation> FileSegregations { get; }

        private ValueRangeModel<DateTime> _CutOff = new ValueRangeModel<DateTime>(new ValueRange<DateTime>(DateTime.Now));
        public ValueRangeModel<DateTime> CutOff
        {
            get { return _CutOff; }
            set { SetProperty(ref _CutOff, value); }
        }

        private IDepartment _SelectedDepartment;
        public IDepartment SelectedDepartment
        {
            get { return _SelectedDepartment; }
            set { SetProperty(ref _SelectedDepartment, value); }
        }

        private IEmployee _SelectedEmployee;
        public IEmployee SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set { SetProperty(ref _SelectedEmployee, value); }
        }

        private TimeLogExportOption _SelectedExportOption;
        public TimeLogExportOption SelectedExportOption
        {
            get { return _SelectedExportOption; }
            set { SetProperty(ref _SelectedExportOption, value); }
        }

        private TimeLogFileSegregation _SelectedFileSegregation;
        public TimeLogFileSegregation SelectedFileSegregation
        {
            get { return _SelectedFileSegregation; }
            set { SetProperty(ref _SelectedFileSegregation, value); }
        }

        protected override void Initialize()
        {
            _HeaderEvent.Publish("DTR Printing");
        }

        private async void GetDepartment()
        {
            Departments.Clear();
            var result = await r_DepartmentManager.GetListWithTimeLogAsync(CutOff.GetSource());

            if (result.Status == ProcessResultStatus.Success)
            {
                if (result.DataList != null && result.DataList.Any())
                {
                    Departments.AddRange(result.DataList);
                    EnqueueListCountMessage(result.DataList.Count(), "department");
                }
                else
                {
                    EnqueueMessage("No departments found.");
                }
            }
            else
            {
                EnqueueMessage(result.Message);
            }
        }

        private async void GetEmployee()
        {
            Employees.Clear();

            if (SelectedDepartment != null)
            {
                var result = await r_EmployeeManager.GetListWithTimeLogByDepartmentAsync(CutOff.GetSource(), SelectedDepartment);

                if (result.Status == ProcessResultStatus.Success)
                {
                    if (result.DataList != null && result.DataList.Any())
                    {
                        Employees.AddRange(result.DataList);
                        //EnqueueListCountMessage(result.DataList.Count(), "employee");
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
        }

        private async void Print()
        {
            IEnumerableProcessResult<ITimeLog> result = null;

            _BusyAppEvent.Busy();

            switch (SelectedExportOption)
            {
                case TimeLogExportOption.All:
                    result = await r_TimeLogManager.GetListByCutOffAsync(CutOff.GetSource());
                    break;
                case TimeLogExportOption.SelectedDepartment:
                    if (SelectedDepartment != null)
                    {
                        result = await r_TimeLogManager.GetListByDepartmentCutOffAsync(SelectedDepartment, CutOff.GetSource());
                    }
                    else
                    {
                        EnqueueMessage("Invalid department.");
                        return;
                    }
                    break;
                case TimeLogExportOption.SelectedEmployee:
                    if (SelectedEmployee != null)
                    {
                        result = await r_TimeLogManager.GetListByEmployeeCutOffAsync(SelectedEmployee, CutOff.GetSource());
                    }
                    else
                    {
                        EnqueueMessage("Invalid employee.");
                        return;
                    }
                    break;
            }

            if (result.DataList != null && result.DataList.Any())
            {
                await r_HumanResourceReport.ExportTimeLogAsync(result.DataList, CutOff.GetSource(), SelectedExportOption, SelectedFileSegregation, this);
            }
            else
            {
                EnqueueMessage("Nothing to be exported.");
            }

            _BusyAppEvent.Unbusy();
        }

        #region Export EventHandlers
        public void OnException(Exception exception)
        {
            Invoke(() => DialogHelper.CloseDialog());
            EnqueueMessage(exception.Message);
        }

        public void OnError(string message)
        {
            Invoke(() => DialogHelper.CloseDialog());
            EnqueueMessage(message);
        }

        public void OnExported(string[] filePaths)
        {
            Invoke(() => DialogHelper.CloseDialog());
            EnqueueMessage("Successfully exported.");
        }

        public void OnExported(string filePath)
        {
            Invoke(() => DialogHelper.CloseDialog());
            EnqueueMessage("Successfully exported.");
        } 
        #endregion
    }
}
