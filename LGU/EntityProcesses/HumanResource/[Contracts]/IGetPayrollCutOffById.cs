using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetPayrollCutOffById : IProcess<IPayrollCutOff>
    {
        short PayrollCutOffId { get; set; }
    }
}
