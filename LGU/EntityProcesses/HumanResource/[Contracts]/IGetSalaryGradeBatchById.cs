using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetSalaryGradeBatchById : IProcess<ISalaryGradeBatch>
    {
        int SalaryGradeBatchId { get; set; }
    }
}
