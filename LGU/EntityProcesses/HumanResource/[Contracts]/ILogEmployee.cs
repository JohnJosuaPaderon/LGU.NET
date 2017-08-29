using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface ILogEmployee : IProcess<ITimeLog>
    {
        IEmployee Employee { get; set; }
    }
}
