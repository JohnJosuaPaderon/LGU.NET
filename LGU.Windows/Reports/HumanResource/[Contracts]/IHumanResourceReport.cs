using LGU.Entities.HumanResource;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LGU.Reports.HumanResource
{
    public interface IHumanResourceReport
    {
        void ExportTimeLog(IEnumerable<TimeLog> timeLog, ValueRange<DateTime> cutOffs, TimeLogExportOption exportOption, TimeLogFileSegregation fileSegregation, IExportEventHandler eventHandler);
        Task ExportTimeLogAsync(IEnumerable<TimeLog> timeLogs, ValueRange<DateTime> cutOff, TimeLogExportOption exportOption, TimeLogFileSegregation fileSegregation, IExportEventHandler eventHandler);
        void ExportLocator(Locator locator, IExportEventHandler eventHandler);
        Task ExportLocatorAsync(Locator locator, IExportEventHandler eventHandler);
    }
}
