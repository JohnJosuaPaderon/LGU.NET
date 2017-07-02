using System.Threading;
using System.Threading.Tasks;

namespace LGU.Entities
{
    public interface IEntityManager<T, Tidentifier> : IDataManager<T>
        where T : IEntity<Tidentifier>
    {
        IDataProcessResult<T> GetById(Tidentifier id);
    }

    public interface IAsyncEntityManager<T, TIdentifier> : IAsyncDataManager<T>
        where T : IEntity<TIdentifier>
    {
        Task<IDataProcessResult<T>> GetByIdAsync(TIdentifier id);
    }

    public interface ICancellableAsyncEntityManager<T, TIdentifier> : ICancellableAsyncDataManager<T>
        where T : IEntity<TIdentifier>
    {
        Task<IDataProcessResult<T>> GetByIdAsync(TIdentifier id, CancellationToken cancellationToken);
    }
}
