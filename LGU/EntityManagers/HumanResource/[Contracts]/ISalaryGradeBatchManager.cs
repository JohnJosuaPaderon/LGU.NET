using LGU.Entities;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface ISalaryGradeBatchManager : IEntityManager<ISalaryGradeBatch, int>
    {
        IProcessResult<ISalaryGradeBatch> GetCurrent();
        Task<IProcessResult<ISalaryGradeBatch>> GetCurrentAsync();
        Task<IProcessResult<ISalaryGradeBatch>> GetCurrentAsync(CancellationToken cancellationToken);
    }
}
