using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetTimeLogListByCutOff : IEnumerableProcess<TimeLog>
    {
        ValueRange<DateTime> CutOff { get; set; }
    }
}
