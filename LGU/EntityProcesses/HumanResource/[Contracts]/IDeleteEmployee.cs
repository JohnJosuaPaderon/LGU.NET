using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteEmployee : IProcess<Employee>
    {
        Employee Employee { get; set; }
    }
}
