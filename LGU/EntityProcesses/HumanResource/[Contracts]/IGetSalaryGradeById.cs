using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetSalaryGradeById : IProcess<ISalaryGrade>
    {
        long SalaryGradeId { get; set; }
    }
}
