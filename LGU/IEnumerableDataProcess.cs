using System.Threading;
using System.Threading.Tasks;

namespace LGU
{
    public interface IEnumerableDataProcess<T>
    {
        IEnumerableDataProcessResult<T> Execute();
        Task<IEnumerableDataProcessResult<T>> ExecuteAsync();
        Task<IEnumerableDataProcessResult<T>> ExecuteAsync(CancellationToken cancellationToken);
    }
}
