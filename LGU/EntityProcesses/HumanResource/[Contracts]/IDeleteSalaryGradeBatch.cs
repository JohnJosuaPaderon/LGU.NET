using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteSalaryGradeBatch : IProcess<ISalaryGradeBatch>
    {
        ISalaryGradeBatch SalaryGradeBatch { get; set; }
    }
}
