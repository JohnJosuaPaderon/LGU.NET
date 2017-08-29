using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateEmployee : IProcess<IEmployee>
    {
        IEmployee Employee { get; set; }
    }
}
