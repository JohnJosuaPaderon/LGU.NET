using LGU.Entities.HumanResource;
using System;
using System.Collections.Generic;

namespace LGU.Reports.HumanResource
{
    public interface IExportTimeLog : IExport
    {
        IEnumerable<ITimeLog> TimeLogs { get; set; }
        ValueRange<DateTime> CutOff { get; set; }
        TimeLogExportOption ExportOption { get; set; }
        TimeLogFileSegregation FileSegregration { get; set; }
    }
}
