using System.Threading;
using System.Threading.Tasks;

namespace LGU.Entities
{
    public interface IEntityManager<T, TIdentifier> : IDataManager<T>
        where T : IEntity<TIdentifier>
    {
        IDataProcessResult<T> GetById(TIdentifier id);
        Task<IDataProcessResult<T>> GetByIdAsync(TIdentifier id);
        Task<IDataProcessResult<T>> GetByIdAsync(TIdentifier id, CancellationToken cancellationToken);
    }
}
