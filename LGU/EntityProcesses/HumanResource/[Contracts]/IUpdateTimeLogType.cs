using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateTimeLogType : IProcess<TimeLogType>
    {
        TimeLogType TimeLogType { get; set; }
    }
}
