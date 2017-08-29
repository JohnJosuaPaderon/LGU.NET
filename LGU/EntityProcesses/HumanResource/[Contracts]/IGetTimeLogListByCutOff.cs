using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetTimeLogListByCutOff : IEnumerableProcess<ITimeLog>
    {
        ValueRange<DateTime> CutOff { get; set; }
    }
}
