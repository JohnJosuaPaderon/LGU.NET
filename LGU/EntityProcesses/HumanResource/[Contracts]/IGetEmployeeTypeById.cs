using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmployeeTypeById : IProcess<IEmployeeType>
    {
        short EmployeeTypeId { get; set; }
    }
}
