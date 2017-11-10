using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetPayrollContractualInclusion : IProcess<IPayrollContractualInclusion>
    {
        IPayrollContractual Payroll { get; set; }
    }
}
