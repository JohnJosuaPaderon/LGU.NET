using LGU.Entities;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface ISalaryGradeManager : IEntityManager<ISalaryGrade, long>
    {
        IEnumerableProcessResult<ISalaryGrade> GetListByBatch(ISalaryGradeBatch batch);
        Task<IEnumerableProcessResult<ISalaryGrade>> GetListByBatchAsync(ISalaryGradeBatch batch);
        Task<IEnumerableProcessResult<ISalaryGrade>> GetListByBatchAsync(ISalaryGradeBatch batch, CancellationToken cancellationToken);
    }
}
