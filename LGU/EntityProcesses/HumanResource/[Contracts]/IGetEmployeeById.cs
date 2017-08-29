using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmployeeById : IProcess<IEmployee>
    {
        long EmployeeId { get; set; }
    }
}
