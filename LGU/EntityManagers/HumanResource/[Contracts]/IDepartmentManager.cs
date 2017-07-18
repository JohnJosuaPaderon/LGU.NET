using LGU.Entities;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IDepartmentManager : IEntityManager<Department, int>
    {
        IEnumerableProcessResult<Department> Search(string searchKey);
        Task<IEnumerableProcessResult<Department>> SearchAsync(string searchKey);
        Task<IEnumerableProcessResult<Department>> SearchAsync(string searchKey, CancellationToken cancellationToken);
    }
}
