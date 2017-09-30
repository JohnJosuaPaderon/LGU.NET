using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetPayrollTypeById : IProcess<IPayrollType>
    {
        short PayrollTypeId { get; set; }
    }
}
