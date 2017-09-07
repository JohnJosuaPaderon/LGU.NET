using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetCurrentSalaryGradeStepByEmployee : IProcess<ISalaryGradeStep>
    {
        IEmployee Employee { get; set; }
    }
}
