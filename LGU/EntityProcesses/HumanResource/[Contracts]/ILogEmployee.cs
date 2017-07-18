using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface ILogEmployee : IProcess<TimeLog>
    {
        Employee Employee { get; set; }
    }
}
