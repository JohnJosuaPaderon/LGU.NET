using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetTimeLogTypeById : IProcess<TimeLogType>
    {
        short TimeLogTypeId { get; set; }
    }
}
