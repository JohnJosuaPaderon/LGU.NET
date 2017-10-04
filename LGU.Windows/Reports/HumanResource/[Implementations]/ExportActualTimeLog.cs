using LGU.Entities.HumanResource;
using LGU.Extensions;
using LGU.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LGU.Reports.HumanResource
{
    public sealed class ExportActualTimeLog : ExcelExportBase, IExportActualTimeLog
    {
        private const string FORMAT_DATE_TIME = "yyyy-MM-dd_hh-mm-ss";

        public ExportActualTimeLog(IActualTimeLogReportInfoProvider reportInfoProvider)
        {
            _ReportInfoProvider = reportInfoProvider;
        }

        private readonly IActualTimeLogReportInfoProvider _ReportInfoProvider;

        public IEnumerable<ITimeLog> TimeLogs { get; set; }
        public ValueRange<DateTime> CutOff { get; set; }
        public IEmployee Employee { get; set; }

        private DateTime ExportDate;

        public void Export()
        {
            ExportDate = DateTime.Now;
            Initialize();
            OpenTemplate(_ReportInfoProvider.Template);
            SetActiveWorksheet(1);

            if (!Faulted)
            {
                WriteHeader();
                WriteTimeLogs();
                TrySave();
                TryPrint();
            }
        }

        private void TrySave()
        {
            try
            {
                DirectoryResolver.Resolve(_ReportInfoProvider.SaveDirectory);
                var path = Path.Combine(_ReportInfoProvider.SaveDirectory, $"{(Employee?.Id ?? 0).ToString("0000")}.{ExportDate.ToString(FORMAT_DATE_TIME)}.xlsx");
                Workbook.SaveAs(path);
                EventHandler?.OnExported(path);
            }
            catch (Exception ex)
            {
                EventHandler?.OnException(ex);
            }
        }

        private void TryPrint()
        {
            if (_ReportInfoProvider.PrintAfterSave)
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

        private void WriteTimeLogs()
        {
            var rowIndex = _ReportInfoProvider.LogRowStart;

            foreach (var timeLog in TimeLogs)
            {
                SetTimeLog(timeLog, rowIndex);
                rowIndex++;
            }
        }

        private void SetTimeLog(ITimeLog timeLog, int rowIndex)
        {
            SetCellValue(rowIndex, _ReportInfoProvider.LoginColumn, timeLog.LoginDate);
            SetCellValue(rowIndex, _ReportInfoProvider.LogoutColumn, timeLog.LogoutDate);
        }

        private void WriteHeader()
        {
            SetCellValue(_ReportInfoProvider.EmployeeCell, Employee?.FullName);
            SetCellValue(_ReportInfoProvider.DepartmentCell, Employee?.Department?.Description);
            SetCellValue(_ReportInfoProvider.CutOffCell, CutOff.ToFormattedString());
        }

        public async Task ExportAsync()
        {
            await Task.Run(() => Export());
        }
    }
}
