using LGU.Entities;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface ISalaryGradeStepManager : IEntityManager<ISalaryGradeStep, long>
    {
        IEnumerableProcessResult<ISalaryGradeStep> GetListBySalaryGrade(ISalaryGrade salaryGrade);
        Task<IEnumerableProcessResult<ISalaryGradeStep>> GetListBySalaryGradeAsync(ISalaryGrade salaryGrade);
        Task<IEnumerableProcessResult<ISalaryGradeStep>> GetListBySalaryGradeAsync(ISalaryGrade salaryGrade, CancellationToken cancellationToken);
        IProcessResult<ISalaryGradeStep> GetByNumberAndStep(int salaryGradeNumber, int step);
        Task<IProcessResult<ISalaryGradeStep>> GetByNumberAndStepAsync(int salaryGradeNumber, int step);
        Task<IProcessResult<ISalaryGradeStep>> GetByNumberAndStepAsync(int salaryGradeNumber, int step, CancellationToken cancellationToken);
        IProcessResult<ISalaryGradeStep> GetCurrentByEmployee(IEmployee employee);
        Task<IProcessResult<ISalaryGradeStep>> GetCurrentByEmployeeAsync(IEmployee employee);
        Task<IProcessResult<ISalaryGradeStep>> GetCurrentByEmployeeAsync(IEmployee employee, CancellationToken cancellationToken);
    }
}
