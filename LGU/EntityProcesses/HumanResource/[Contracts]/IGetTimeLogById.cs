using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetTimeLogById : IProcess<TimeLog>
    {
        long TimeLogId { get; set; }
    }
}
