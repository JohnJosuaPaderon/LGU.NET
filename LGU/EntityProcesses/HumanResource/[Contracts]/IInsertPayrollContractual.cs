using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertPayrollContractual : IProcess<IPayrollContractual>
    {
        IPayrollContractual PayrollContractual { get; }
    }
}
