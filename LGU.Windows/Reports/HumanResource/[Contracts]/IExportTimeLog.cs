using LGU.Entities.HumanResource;
using System.Collections.Generic;

namespace LGU.Reports.HumanResource
{
    public interface IExportTimeLog : IExport
    {
        IEnumerable<TimeLog> TimeLogs { get; }
    }
}
