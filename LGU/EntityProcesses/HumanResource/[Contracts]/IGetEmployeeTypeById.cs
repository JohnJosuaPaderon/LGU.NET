using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmployeeTypeById : IProcess<EmployeeType>
    {
        short EmployeeTypeId { get; set; }
    }
}
