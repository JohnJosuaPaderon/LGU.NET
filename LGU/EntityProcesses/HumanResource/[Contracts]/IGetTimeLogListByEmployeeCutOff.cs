using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetTimeLogListByEmployeeCutOff : IEnumerableProcess<ITimeLog>
    {
        IEmployee Employee { get; set; }
        ValueRange<DateTime> CutOff { get; set; }
    }
}
