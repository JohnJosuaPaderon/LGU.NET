using LGU.Entities.Core;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public interface IGenderManager
    {
        IDataProcessResult<Gender> GetById(short id);
        Task<IDataProcessResult<Gender>> GetByIdAsync(short id);
        Task<IDataProcessResult<Gender>> GetByIdAsync(short id, CancellationToken cancellationToken);
        IEnumerableDataProcessResult<Gender> GetList();
        Task<IEnumerableDataProcessResult<Gender>> GetListAsync();
        Task<IEnumerableDataProcessResult<Gender>> GetListAsync(CancellationToken cancellationToken);
    }
}
