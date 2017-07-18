using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteTimeLogType : IProcess<TimeLogType>
    {
        TimeLogType TimeLogType { get; set; }
    }
}
