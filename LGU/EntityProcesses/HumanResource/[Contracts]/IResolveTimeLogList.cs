using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Collections.Generic;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IResolveTimeLogList : IEnumerableProcess<TimeLog>
    {
        IEnumerable<TimeLog> TimeLogs { get; set; }
    }
}
