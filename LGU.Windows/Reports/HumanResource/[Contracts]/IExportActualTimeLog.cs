using LGU.Entities.HumanResource;
using System.Collections.Generic;

namespace LGU.Reports.HumanResource
{
    public interface IExportActualTimeLog : IExport
    {
        bool PrintAfterSave { get; set; }
        IEnumerable<TimeLog> TimeLogs { get; set; }
    }
}
