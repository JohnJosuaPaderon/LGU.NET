using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertSalaryGradeStep : IProcess<ISalaryGradeStep>
    {
        ISalaryGradeStep SalaryGradeStep { get; set; }
    }
}
