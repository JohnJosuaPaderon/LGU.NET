using LGU.Entities;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IEmployeeManager : IEntityManager<Employee, long>
    {
        IEnumerableProcessResult<Employee> Search(string searchKey);
        Task<IEnumerableProcessResult<Employee>> SearchAsync(string searchKey);
        Task<IEnumerableProcessResult<Employee>> SearchAsync(string searchKey, CancellationToken cancellationToken);
    }
}
