using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmployeeById : IProcess<Employee>
    {
        long EmployeeId { get; set; }
    }
}
