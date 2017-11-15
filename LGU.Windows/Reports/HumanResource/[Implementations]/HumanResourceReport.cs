using LGU.Entities.HumanResource;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LGU.Reports.HumanResource
{
    public sealed class HumanResourceReport : IHumanResourceReport
    {
        public void ExportActualTimeLog(IEmployee employee, IEnumerable<ITimeLog> timeLogs, ValueRange<DateTime> cutOff, IExportEventHandler eventHandler)
        {
            using (var export = ApplicationDomain.GetService<IExportActualTimeLog>())
            {
                export.EventHandler = eventHandler;
                export.TimeLogs = timeLogs;
                export.CutOff = cutOff;
                export.Employee = employee;
                export.Export();
            }
        }

        public async Task ExportActualTimeLogAsync(IEmployee employee, IEnumerable<ITimeLog> timeLogs, ValueRange<DateTime> cutOff, IExportEventHandler eventHandler)
        {
            using (var export = ApplicationDomain.GetService<IExportActualTimeLog>())
            {
                export.EventHandler = eventHandler;
                export.TimeLogs = timeLogs;
                export.CutOff = cutOff;
                export.Employee = employee;
                await export.ExportAsync();
            }
        }

        public void ExportLocator(ILocator locator, IExportEventHandler eventHandler)
        {
            using (var export = ApplicationDomain.GetService<IExportLocator>())
            {
                export.EventHandler = eventHandler;
                export.Locator = locator;
                export.Export();
            }
        }

        public async Task ExportLocatorAsync(ILocator locator, IExportEventHandler eventHandler)
        {
            using (var export = ApplicationDomain.GetService<IExportLocator>())
            {
                export.EventHandler = eventHandler;
                export.Locator = locator;
                await export.ExportAsync();
            }
        }

        public void ExportPayrollContractual(IPayrollContractual payrollContractual, IExportEventHandler eventHandler)
        {
            using (var export = ApplicationDomain.GetService<IExportPayrollContractual>())
            {
                export.EventHandler = eventHandler;
                export.PayrollContractual = payrollContractual;
                export.Export();
            }
        }

        public async Task ExportPayrollContractualAsync(IPayrollContractual payrollContractual, IExportEventHandler eventHandler)
        {
            using (var export = ApplicationDomain.GetService<IExportPayrollContractual>())
            {
                export.EventHandler = eventHandler;
                export.PayrollContractual = payrollContractual;
                await export.ExportAsync();
            }
        }

        public void ExportTimeLog(IEnumerable<ITimeLog> timeLogs, ValueRange<DateTime> cutOff, TimeLogExportOption exportOption, TimeLogFileSegregation fileSegregation, IExportEventHandler eventHandler)
        {
            using (var export = ApplicationDomain.GetService<IExportTimeLog>())
            {
                export.EventHandler = eventHandler;
                export.TimeLogs = timeLogs;
                export.CutOff = cutOff;
                export.ExportOption = exportOption;
                export.FileSegregration = fileSegregation;
                export.Export();
            }
        }

        public async Task ExportTimeLogAsync(IEnumerable<ITimeLog> timeLogs, ValueRange<DateTime> cutOff, TimeLogExportOption exportOption, TimeLogFileSegregation fileSegregation, IExportEventHandler eventHandler)
        {
            using (var export = ApplicationDomain.GetService<IExportTimeLog>())
            {
                export.EventHandler = eventHandler;
                export.TimeLogs = timeLogs;
                export.CutOff = cutOff;
                export.ExportOption = exportOption;
                export.FileSegregration = fileSegregation;
                await export.ExportAsync();
            }
        }
    }
}
