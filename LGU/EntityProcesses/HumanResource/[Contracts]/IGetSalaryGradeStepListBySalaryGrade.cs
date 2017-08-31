using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetSalaryGradeStepListBySalaryGrade : IEnumerableProcess<ISalaryGradeStep>
    {
        ISalaryGrade SalaryGrade { get; set; }
    }
}
