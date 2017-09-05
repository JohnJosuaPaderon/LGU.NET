using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteEmployeeSalaryGradeStep : IProcess<IEmployeeSalaryGradeStep>
    {
        IEmployeeSalaryGradeStep EmployeeSalaryGradeStep { get; set; }
    }
}
