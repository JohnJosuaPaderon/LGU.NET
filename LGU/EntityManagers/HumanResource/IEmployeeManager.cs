using LGU.Entities;
using LGU.Entities.HumanResource;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IEmployeeManager : IEntityManager<Employee, long>
    {
        IEnumerableDataProcessResult<Employee> Search(string searchKey);
        Task<IEnumerableDataProcessResult<Employee>> SearchAsync(string searchKey);
        Task<IEnumerableDataProcessResult<Employee>> SearchAsync(string searchKey, CancellationToken cancellationToken);
    }
}
