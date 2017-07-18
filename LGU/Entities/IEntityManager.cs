using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.Entities
{
    public interface IEntityManager<T, TIdentifier> : IDataManager<T>
        where T : IEntity<TIdentifier>
    {
        IProcessResult<T> GetById(TIdentifier id);
        Task<IProcessResult<T>> GetByIdAsync(TIdentifier id);
        Task<IProcessResult<T>> GetByIdAsync(TIdentifier id, CancellationToken cancellationToken);
    }
}
