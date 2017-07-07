using LGU.Entities;
using LGU.Entities.HumanResource;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IDepartmentManager : IEntityManager<Department, uint>, IAsyncEntityManager<Department, uint>, ICancellableAsyncEntityManager<Department, uint>
    {
        IEnumerableDataProcessResult<Department> Search(string searchKey);
        Task<IEnumerableDataProcessResult<Department>> SearchAsync(string searchKey);
        Task<IEnumerableDataProcessResult<Department>> SearchAsync(string searchKey, CancellationToken cancellationToken);
    }
}
