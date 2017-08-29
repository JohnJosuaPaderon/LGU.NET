using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateTimeLog : IProcess<ITimeLog>
    {
        ITimeLog TimeLog { get; set; }
    }
}
