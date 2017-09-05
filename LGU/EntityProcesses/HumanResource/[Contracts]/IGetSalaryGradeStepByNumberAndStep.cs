using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetSalaryGradeStepByNumberAndStep : IProcess<ISalaryGradeStep>
    {
        int SalaryGradeNumber { get; set; }
        int Step { get; set; }
    }
}
