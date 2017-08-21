﻿using LGU.Entities.HumanResource;
using System.Collections.Generic;

namespace LGU.Reports.HumanResource
{
    public interface IExportActualTimeLog : IExport
    {
        IEnumerable<TimeLog> TimeLogs { get; set; }
    }
}
