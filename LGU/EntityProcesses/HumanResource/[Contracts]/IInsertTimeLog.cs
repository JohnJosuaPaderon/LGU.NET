using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertTimeLog : IProcess<TimeLog>
    {
        TimeLog TimeLog { get; set; }
    }
}
