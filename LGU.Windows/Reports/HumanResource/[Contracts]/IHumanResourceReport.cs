using LGU.Entities.HumanResource;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LGU.Reports.HumanResource
{
    public interface IHumanResourceReport
    {
        void ExportTimeLog(IEnumerable<ITimeLog> timeLog, ValueRange<DateTime> cutOffs, TimeLogExportOption exportOption, TimeLogFileSegregation fileSegregation, IExportEventHandler eventHandler);
        Task ExportTimeLogAsync(IEnumerable<ITimeLog> timeLogs, ValueRange<DateTime> cutOff, TimeLogExportOption exportOption, TimeLogFileSegregation fileSegregation, IExportEventHandler eventHandler);
        void ExportLocator(ILocator locator, IExportEventHandler eventHandler);
        Task ExportLocatorAsync(ILocator locator, IExportEventHandler eventHandler);
    }
}
