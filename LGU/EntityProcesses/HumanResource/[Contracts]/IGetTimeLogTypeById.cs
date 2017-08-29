using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetTimeLogTypeById : IProcess<ITimeLogType>
    {
        short TimeLogTypeId { get; set; }
    }
}
