using LGU.Entities.HumanResource;
using System;
using System.Collections.Generic;

namespace LGU.Reports.HumanResource
{
    public interface IExportActualTimeLog : IExport
    {
        IEnumerable<ITimeLog> TimeLogs { get; set; }
        IEmployee Employee { get; set; }
        ValueRange<DateTime> CutOff { get; set; }
    }
}
