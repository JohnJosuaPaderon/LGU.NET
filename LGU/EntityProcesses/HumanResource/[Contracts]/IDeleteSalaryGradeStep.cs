using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteSalaryGradeStep : IProcess<ISalaryGradeStep>
    {
        ISalaryGradeStep SalaryGradeStep { get; set; }
    }
}
