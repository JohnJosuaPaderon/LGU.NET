using LGU.Entities.HumanResource;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LGU.Reports.HumanResource
{
    public interface IHumanResourceReport
    {
        void ExportTimeLog(IEnumerable<TimeLog> timeLogs, IExportEventHandler eventHandler);
        Task ExportTimeLogAsync(IEnumerable<TimeLog> timeLogs, IExportEventHandler eventHandler);
        void ExportLocator(Locator locator, IExportEventHandler eventHandler);
        Task ExportLocatorAsync(Locator locator, IExportEventHandler eventHandler);
    }
}
