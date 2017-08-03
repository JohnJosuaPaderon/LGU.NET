using LGU.Entities.HumanResource;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LGU.Reports.HumanResource
{
    public sealed class ExportTimeLog : ExcelExportBase, IExportTimeLog
    {
        public ExportTimeLog(IExportEventHandler eventHandler, IEnumerable<TimeLog> timeLogs, TimeLogExportPrintOptions printOptions, TimeLogExportConfiguration configuration) : base(eventHandler)
        {
            TimeLogs = timeLogs ?? throw new ArgumentNullException(nameof(timeLogs));
            r_PrintOptions = printOptions ?? throw new ArgumentNullException(nameof(printOptions));
            r_Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public IEnumerable<TimeLog> TimeLogs { get; }
        private Dictionary<Employee, List<TimeLog>> EmployeeTimeLogs;
        private Dictionary<Department, Dictionary<Employee, List<TimeLog>>> DepartmentTimeLogs;
        private readonly TimeLogExportPrintOptions r_PrintOptions;
        private readonly TimeLogExportConfiguration r_Configuration;

        public string Template { get; set; }

        public void Export()
        {
            Initialize();
            OpenTemplate(Template);
            SetActiveWorksheet(1, "Template");

            switch (r_PrintOptions.FileSegregation)
            {
                case TimeLogExportFileSegregation.OneFile:
                    ExportAll();
                    break;
                case TimeLogExportFileSegregation.MultipleFiles:
                    ExportPerEmployee();
                    break;
                case TimeLogExportFileSegregation.MultipleFiles_Department:
                    ExportPerDepartment();
                    break;
            }
        }

        private void PrepareEmployeeTimeLogs()
        {
            EmployeeTimeLogs = new Dictionary<Employee, List<TimeLog>>();

            foreach (var timeLog in TimeLogs)
            {
                if (!EmployeeTimeLogs.ContainsKey(timeLog.Employee))
                {
                    EmployeeTimeLogs.Add(timeLog.Employee, new List<TimeLog>());
                }

                EmployeeTimeLogs[timeLog.Employee].Add(timeLog);
            }
        }

        private void PrepareDepartmentTimeLogs()
        {
            if (EmployeeTimeLogs == null || EmployeeTimeLogs.Count <= 0)
            {
                EventHandler.OnError("No data.");
            }
            else
            {
                DepartmentTimeLogs = new Dictionary<Department, Dictionary<Employee, List<TimeLog>>>();

                foreach (var employeeTimeLog in EmployeeTimeLogs)
                {
                    if (!DepartmentTimeLogs.ContainsKey(employeeTimeLog.Key.Department))
                    {
                        DepartmentTimeLogs.Add(employeeTimeLog.Key.Department, new Dictionary<Employee, List<TimeLog>>());
                    }

                    DepartmentTimeLogs[employeeTimeLog.Key.Department].Add(employeeTimeLog.Key, employeeTimeLog.Value);
                }
            }
        }

        private void ExportAll()
        {
            PrepareEmployeeTimeLogs();

            foreach (var employeeTimeLog in EmployeeTimeLogs)
            {
                var employee = employeeTimeLog.Key;
                var timeLogs = employeeTimeLog.Value;
                DuplicateTemplateWorksheet(Sheets[1], $"{employee.Department?.Id ?? 0}_{employee.Id}");

                SetCellValue(r_Configuration.FullNameCell, employee.FullName);
                foreach (var timeLog in timeLogs)
                {
                    if (timeLog.LoginDate != null)
                    {

                    }
                }
            }
        }

        private void ExportPerDepartment()
        {
            PrepareEmployeeTimeLogs();
            PrepareDepartmentTimeLogs();
        }

        private void ExportPerEmployee()
        {
            PrepareEmployeeTimeLogs();
        }

        public Task ExportAsync()
        {
            return Task.Run(() => Export());
        }
    }
}
