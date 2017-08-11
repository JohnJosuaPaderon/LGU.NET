using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetActualTimeLogListByEmployeeCutOff : IEnumerableProcess<TimeLog>
    {
        Employee Employee { get; set; }
        ValueRange<DateTime> CutOff { get; set; }
    }
}
