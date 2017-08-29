using LGU.Entities;
using LGU.Entities.Core;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public interface IPersonManager : IEntityManager<IPerson, long>
    {
        IEnumerableProcessResult<IPerson> Search(string searchKey);
        Task<IEnumerableProcessResult<IPerson>> SearchAsync(string searchKey);
        Task<IEnumerableProcessResult<IPerson>> SearchAsync(string searchKey, CancellationToken cancellationToken);
    }
}
