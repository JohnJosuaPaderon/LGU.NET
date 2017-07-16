using LGU.Entities;
using LGU.Entities.Core;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public interface IPersonManager : IEntityManager<Person, long>
    {
        IEnumerableDataProcessResult<Person> Search(string searchKey);
        Task<IEnumerableDataProcessResult<Person>> SearchAsync(string searchKey);
        Task<IEnumerableDataProcessResult<Person>> SearchAsync(string searchKey, CancellationToken cancellationToken);
    }
}
