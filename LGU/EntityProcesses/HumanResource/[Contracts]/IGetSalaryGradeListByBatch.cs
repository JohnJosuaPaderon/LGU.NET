using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetSalaryGradeListByBatch : IEnumerableProcess<ISalaryGrade>
    {
        ISalaryGradeBatch Batch { get; set; }
    }
}
