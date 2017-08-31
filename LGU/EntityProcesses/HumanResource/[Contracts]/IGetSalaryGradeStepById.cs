using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetSalaryGradeStepById : IProcess<ISalaryGradeStep>
    {
        long SalaryGradeStepId { get; set; }
    }
}
