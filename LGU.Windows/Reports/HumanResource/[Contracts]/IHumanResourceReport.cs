﻿using LGU.Entities.HumanResource;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LGU.Reports.HumanResource
{
    public interface IHumanResourceReport
    {
        void ExportActualTimeLog(IEmployee employee, IEnumerable<ITimeLog> timeLogs, ValueRange<DateTime> cutOff, IExportEventHandler eventHandler);
        Task ExportActualTimeLogAsync(IEmployee employee, IEnumerable<ITimeLog> timeLogs, ValueRange<DateTime> cutOff, IExportEventHandler eventHandler);
        void ExportTimeLog(IEnumerable<ITimeLog> timeLog, ValueRange<DateTime> cutOffs, TimeLogExportOption exportOption, TimeLogFileSegregation fileSegregation, IExportEventHandler eventHandler);
        Task ExportTimeLogAsync(IEnumerable<ITimeLog> timeLogs, ValueRange<DateTime> cutOff, TimeLogExportOption exportOption, TimeLogFileSegregation fileSegregation, IExportEventHandler eventHandler);
        void ExportLocator(ILocator locator, IExportEventHandler eventHandler);
        Task ExportLocatorAsync(ILocator locator, IExportEventHandler eventHandler);
        void ExportPayrollContractual(IPayrollContractual payrollContractual, IExportEventHandler eventHandler);
        Task ExportPayrollContractualAsync(IPayrollContractual payrollContractual, IExportEventHandler eventHandler);
    }
}
