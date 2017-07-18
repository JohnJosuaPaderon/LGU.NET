using System.Threading;
using System.Threading.Tasks;

namespace LGU.Processes
{
    public interface IEnumerableProcess<T>
    {
        IEnumerableProcessResult<T> Execute();
        Task<IEnumerableProcessResult<T>> ExecuteAsync();
        Task<IEnumerableProcessResult<T>> ExecuteAsync(CancellationToken cancellationToken);
    }
}
