using LGU.Entities.HumanResource;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGU.Reports.HumanResource
{
    public sealed class ExportTimeLog : ExcelExportBase, IExportTimeLog
    {
        public ExportTimeLog(IHumanResourceReportInfoProvider infoProvider)
        {
            r_InfoProvider = infoProvider;
        }

        private readonly IHumanResourceReportInfoProvider r_InfoProvider;

        public IEnumerable<TimeLog> TimeLogs { get; set; }
        public TimeLogExportOption ExportOption { get; set; }
        public TimeLogFileSegregation FileSegregration { get; set; }
        public bool PrintAfterSave { get; set; }

        private Dictionary<Department, List<Employee>> Segregated;

        public void Export()
        {
            switch (FileSegregration)
            {
                case TimeLogFileSegregation.OneFile:
                    ExportOneFile();
                    break;
                case TimeLogFileSegregation.PerDepartment:
                    ExportPerDepartment();
                    break;
                case TimeLogFileSegregation.PerEmployee:
                    ExportPerEmployee();
                    break;
            }
        }

        private void ExportOneFile()
        {
            foreach (var employees in Segregated.Values)
            {
                foreach (var employee in employees)
                {
                    var timeLogs = TimeLogs.Where(arg => arg.Employee == employee);

                    if (timeLogs.Any())
                    {
                        var sheetName = $"{employee.Department?.Id ?? 0}-{employee.Id}";
                    }
                }
            }
        }

        private void ExportPerDepartment()
        {
            
        }

        private void ExportPerEmployee()
        {

        }

        private void Segregate()
        {
            Segregated = new Dictionary<Department, List<Employee>>();

            foreach (var timeLog in TimeLogs)
            {
                if (!Segregated.ContainsKey(timeLog.Employee?.Department))
                {
                    Segregated.Add(timeLog.Employee.Department, new List<Employee>());
                }

                Segregated[timeLog.Employee.Department].Add(timeLog.Employee);
            }
        }

        public Task ExportAsync()
        {
            return Task.Run(() => Export());
        }
    }
}
