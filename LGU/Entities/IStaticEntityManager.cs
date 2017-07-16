using System.Threading;
using System.Threading.Tasks;

namespace LGU.Entities
{
    public interface IStaticEntityManager<T, TIdentifier>
        where T : IEntity<TIdentifier>
    {
        IDataProcessResult<T> GetById(TIdentifier id);
        Task<IDataProcessResult<T>> GetByIdAsync(TIdentifier id);
        Task<IDataProcessResult<T>> GetByIdAsync(TIdentifier id, CancellationToken cancellationToken);
        IEnumerableDataProcessResult<T> GetList();
        Task<IEnumerableDataProcessResult<T>> GetListAsync();
        Task<IEnumerableDataProcessResult<T>> GetListAsync(CancellationToken cancellationToken);
    }
}
