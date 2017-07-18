using LGU.Entities;
using LGU.Entities.Core;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public interface IPersonManager : IEntityManager<Person, long>
    {
        IEnumerableProcessResult<Person> Search(string searchKey);
        Task<IEnumerableProcessResult<Person>> SearchAsync(string searchKey);
        Task<IEnumerableProcessResult<Person>> SearchAsync(string searchKey, CancellationToken cancellationToken);
    }
}
