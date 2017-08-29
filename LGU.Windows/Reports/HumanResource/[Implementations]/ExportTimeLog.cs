using LGU.Entities.HumanResource;
using LGU.Extensions;
using LGU.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace LGU.Reports.HumanResource
{
    public sealed class ExportTimeLog : ExcelExportBase, IExportTimeLog
    {
        public ExportTimeLog(ITimeLogReportInfoProvider infoProvider)
        {
            r_InfoProvider = infoProvider;
        }

        private readonly ITimeLogReportInfoProvider r_InfoProvider;

        public IEnumerable<ITimeLog> TimeLogs { get; set; }
        public ValueRange<DateTime> CutOff { get; set; }
        public TimeLogExportOption ExportOption { get; set; }
        public TimeLogFileSegregation FileSegregration { get; set; }
        public bool PrintAfterSave { get; set; }

        private Dictionary<IDepartment, List<IEmployee>> Segregated;

        public void Export()
        {
            Segregate();
            Initialize();

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

        private void SetTimeLog(ITimeLog timeLog)
        {
            var loginRowIndex = (r_InfoProvider.LogRowStart - 1) + timeLog.LoginDate?.Day ?? 1;
            var logoutRowIndex = (r_InfoProvider.LogRowStart - 1) + timeLog.LogoutDate?.Day ?? 1;
            var loginColumnIndex = timeLog.LoginDate?.Hour <= 12 ? r_InfoProvider.AmLoginColumn : r_InfoProvider.PmLoginColumn;
            var logoutColumnIndex = timeLog.LogoutDate?.Hour <= 12 ? r_InfoProvider.AmLogoutColumn : r_InfoProvider.PmLogoutColumn;

            Excel.Range amLoginRange = ActiveWorksheet.Cells[loginRowIndex, r_InfoProvider.AmLoginColumn];
            Excel.Range amLogoutRange = ActiveWorksheet.Cells[logoutRowIndex, r_InfoProvider.AmLogoutColumn];
            Excel.Range pmLoginRange = ActiveWorksheet.Cells[loginRowIndex, r_InfoProvider.PmLoginColumn];
            Excel.Range pmLogoutRange = ActiveWorksheet.Cells[logoutRowIndex, r_InfoProvider.PmLogoutColumn];

            if (!(IsNullOrWhiteSpace(amLoginRange) && IsNullOrWhiteSpace(pmLoginRange)))
            {
                loginColumnIndex = r_InfoProvider.OtLoginColumn;
                //loginRange = ActiveWorksheet.Cells[loginRowIndex, r_InfoProvider.OtLoginColumn];
            }

            if (!(IsNullOrWhiteSpace(amLogoutRange) && IsNullOrWhiteSpace(pmLogoutRange)))
            {
                logoutColumnIndex = r_InfoProvider.OtLogoutColumn;
                //logoutRange = ActiveWorksheet.Cells[logoutRowIndex, r_InfoProvider.OtLogoutColumn];
            }

            SetCellValue(loginRowIndex, loginColumnIndex, timeLog.LoginDate?.ToString(r_InfoProvider.TimeLogFormat));
            SetCellValue(logoutRowIndex, logoutColumnIndex, timeLog.LogoutDate?.ToString(r_InfoProvider.TimeLogFormat));
        }

        private void WriteCellValues(IEmployee employee, IEnumerable<ITimeLog> timeLogs)
        {
            SetCellValue(r_InfoProvider.EmployeeCell, employee.FullName);
            SetCellValue(r_InfoProvider.CutOffCell, CutOff.ToFormattedString());

            foreach (var timeLog in timeLogs)
            {
                SetTimeLog(timeLog);
            }
        }

        private void ExportOneFile()
        {
            OpenTemplate(r_InfoProvider.Template);

            var departmentCounter = 1;
            var employeeCounter = 0;
            var exportDate = DateTime.Now;

            foreach (var employees in Segregated.Values)
            {
                employeeCounter = 1;

                foreach (var employee in employees)
                {
                    if (Sheets.Count > 25)
                    {
                        break;
                    }

                    var timeLogs = TimeLogs.Where(arg => arg.Employee == employee);

                    if (timeLogs.Any())
                    {
                        var sheetName = $"{departmentCounter}-{employeeCounter}";
                        DuplicateTemplate(sheetName);
                        WriteCellValues(employee, timeLogs);
                    }

                    employeeCounter++;
                }

                departmentCounter++;
            }

            try
            {
                DirectoryResolver.Resolve(r_InfoProvider.SaveDirectory);
                var filePath = Path.Combine(r_InfoProvider.SaveDirectory, $"{exportDate.ToString(r_InfoProvider.PathFormat)}.xls");
                TemplateWorksheet.Delete();
                Workbook.SaveAs(filePath);
                EventHandler?.OnExported(filePath);
            }
            catch (Exception ex)
            {
                EventHandler?.OnException(ex);
            }

            if (r_InfoProvider.PrintAfterSave)
            {
                try
                {
                    Workbook.PrintOutEx();
                }
                catch (Exception ex)
                {
                    EventHandler?.OnException(ex);
                }
            }
        }

        private void ExportPerDepartment()
        {
            var departmentCounter = 1;
            var employeeCounter = 0;
            var filePaths = new List<string>();
            var exportDate = DateTime.Now;

            foreach (var item in Segregated)
            {
                if (Workbooks.Count > 5)
                {
                    break;
                }

                OpenTemplate(r_InfoProvider.Template);
                employeeCounter = 1;

                foreach (var employee in item.Value)
                {
                    var timeLogs = TimeLogs.Where(arg => arg.Employee == employee);

                    if (timeLogs.Any())
                    {
                        var sheetName = $"emp-{employeeCounter}";
                        DuplicateTemplate(sheetName);
                        WriteCellValues(employee, timeLogs);
                    }

                    employeeCounter++;
                }

                try
                {
                    var directory = Path.Combine(r_InfoProvider.SaveDirectory, "Per Department", exportDate.ToString(r_InfoProvider.PathFormat));
                    DirectoryResolver.Resolve(directory);
                    var filePath = Path.Combine(directory, $"dept-{departmentCounter}.xls");
                    TemplateWorksheet.Delete();
                    Workbook.SaveAs(filePath);
                    filePaths.Add(filePath);
                }
                catch (Exception ex)
                {
                    EventHandler?.OnException(ex);
                }

                departmentCounter++;
            }

            EventHandler?.OnExported(filePaths.ToArray());
            if (r_InfoProvider.PrintAfterSave)
            {
                try
                {
                    foreach (Excel.Workbook workbook in Workbooks)
                    {
                        workbook.PrintOutEx();
                    }
                }
                catch (Exception ex)
                {
                    EventHandler?.OnException(ex);
                }
            }
        }

        private void ExportPerEmployee()
        {
            var departmentCounter = 1;
            var employeeCounter = 0;
            var filePaths = new List<string>();
            var exportDate = DateTime.Now;

            foreach (var item in Segregated)
            {
                if (Workbooks.Count > 5)
                {
                    break;
                }

                employeeCounter = 1;

                foreach (var employee in item.Value)
                {
                    OpenTemplate(r_InfoProvider.Template);

                    var timeLogs = TimeLogs.Where(arg => arg.Employee == employee);

                    if (timeLogs.Any())
                    {
                        var sheetName = $"dtr";
                        DuplicateTemplate(sheetName);
                        WriteCellValues(employee, timeLogs);
                    }

                    try
                    {
                        var directory = Path.Combine(r_InfoProvider.SaveDirectory, "Per Employee", exportDate.ToString(r_InfoProvider.PathFormat), $"dept-{departmentCounter}");
                        DirectoryResolver.Resolve(directory);
                        var filePath = Path.Combine(directory, $"emp-{employeeCounter}.xls");
                        TemplateWorksheet.Delete();
                        Workbook.SaveAs(filePath);
                        filePaths.Add(filePath);
                    }
                    catch (Exception ex)
                    {
                        EventHandler?.OnException(ex);
                    }

                    employeeCounter++;
                }

                

                departmentCounter++;
            }

            EventHandler?.OnExported(filePaths.ToArray());
            if (r_InfoProvider.PrintAfterSave)
            {
                try
                {
                    foreach (Excel.Workbook workbook in Workbooks)
                    {
                        workbook.PrintOutEx();
                    }
                }
                catch (Exception ex)
                {
                    EventHandler?.OnException(ex);
                }
            }
        }

        private void Segregate()
        {
            Segregated = new Dictionary<IDepartment, List<IEmployee>>();

            foreach (var timeLog in TimeLogs)
            {
                if (!Segregated.ContainsKey(timeLog.Employee?.Department))
                {
                    Segregated.Add(timeLog.Employee.Department, new List<IEmployee>());
                }

                if (!Segregated[timeLog.Employee.Department].Contains(timeLog.Employee))
                {
                    Segregated[timeLog.Employee.Department].Add(timeLog.Employee);
                }
            }
        }

        public async Task ExportAsync()
        {
            await Task.Run(() => Export());
        }
    }
}
