using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetTimeLogById : IProcess<ITimeLog>
    {
        long TimeLogId { get; set; }
    }
}
