using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetPayrollById : IProcess<IPayroll>
    {
        long PayrollId { get; set; }
    }
}
