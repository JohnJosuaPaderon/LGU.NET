using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    interface IGetEmployeeTypeById : IProcess<EmployeeType>
    {
        short EmployeeTypeId { get; set; }
    }
}
