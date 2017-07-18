using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateEmployee : IProcess<Employee>
    {
        Employee Employee { get; set; }
    }
}
