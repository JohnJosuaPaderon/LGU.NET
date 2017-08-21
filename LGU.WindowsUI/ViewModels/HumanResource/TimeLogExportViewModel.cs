using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Models;
using LGU.Processes;
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
    public sealed class TimeLogExportViewModel : ViewModelBase
    {
        public TimeLogExportViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            r_DepartmentManager = SystemRuntime.GetService<IDepartmentManager>();
            r_EmployeeManager = SystemRuntime.GetService<IEmployeeManager>();

            GetDepartmentCommand = new DelegateCommand(GetDepartment);
            GetEmployeeCommand = new DelegateCommand(GetEmployee);
            PrintCommand = new DelegateCommand(Print);

            Departments = new ObservableCollection<Department>();
            Employees = new ObservableCollection<Employee>();
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

        public DelegateCommand GetDepartmentCommand { get; }
        public DelegateCommand GetEmployeeCommand { get; }
        public DelegateCommand PrintCommand { get; }

        public ObservableCollection<Department> Departments { get; }
        public ObservableCollection<Employee> Employees { get; }
        public ObservableCollection<TimeLogExportOption> ExportOptions { get; }
        public ObservableCollection<TimeLogFileSegregation> FileSegregations { get; }

        private ValueRangeModel<DateTime> _CutOff = new ValueRangeModel<DateTime>(new ValueRange<DateTime>(DateTime.Now));
        public ValueRangeModel<DateTime> CutOff
        {
            get { return _CutOff; }
            set { SetProperty(ref _CutOff, value); }
        }

        private Department _SelectedDepartment;
        public Department SelectedDepartment
        {
            get { return _SelectedDepartment; }
            set { SetProperty(ref _SelectedDepartment, value); }
        }

        private Employee _SelectedEmployee;
        public Employee SelectedEmployee
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
                        EnqueueListCountMessage(result.DataList.Count(), "employee");
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
            IEnumerable<TimeLog> timeLogs = null;

            switch (SelectedExportOption)
            {
                case TimeLogExportOption.All:
                    break;
                case TimeLogExportOption.SelectedDepartment:
                    break;
                case TimeLogExportOption.SelectedEmployee:
                    break;
            }
        }
    }
}
