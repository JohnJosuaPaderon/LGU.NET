using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertTimeLogType : IProcess<TimeLogType>
    {
        TimeLogType TimeLogType { get; set; }
    }
}
