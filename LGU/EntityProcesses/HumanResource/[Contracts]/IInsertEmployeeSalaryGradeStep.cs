using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertEmployeeSalaryGradeStep : IProcess<IEmployeeSalaryGradeStep>
    {
        IEmployeeSalaryGradeStep EmployeeSalaryGradeStep { get; set; }
    }
}
