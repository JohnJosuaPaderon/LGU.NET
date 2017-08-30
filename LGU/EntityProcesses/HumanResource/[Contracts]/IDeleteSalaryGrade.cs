using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteSalaryGrade : IProcess<ISalaryGrade>
    {
        ISalaryGrade SalaryGrade { get; set; }
    }
}
