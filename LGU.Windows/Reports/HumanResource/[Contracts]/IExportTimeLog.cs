using LGU.Entities.HumanResource;
using System.Collections.Generic;

namespace LGU.Reports.HumanResource
{
    public interface IExportTimeLog : IExport
    {
        IEnumerable<TimeLog> TimeLogs { get; set; }
        TimeLogExportOption ExportOption { get; set; }
        TimeLogFileSegregation FileSegregration { get; set; }
    }
}
