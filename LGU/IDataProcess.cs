using System.Threading;
using System.Threading.Tasks;

namespace LGU
{
    public interface IDataProcess<T>
    {
        IDataProcessResult<T> Execute();
    }

    public interface IAsyncDataProcess<T>
    {
        Task<IDataProcessResult<T>> ExecuteAsync();
    }

    public interface ICancellableAsyncDataProcess<T>
    {
        Task<IDataProcessResult<T>> ExecuteAsync(CancellationToken cancellationToken);
    }

    public interface IEnumerableDataProcess<T>
    {
        IEnumerableDataProcessResult<T> Execute();
    }

    public interface IAsyncEnumerableDataProcess<T>
    {
        Task<IEnumerableDataProcessResult<T>> ExecuteAsync();
    }

    public interface ICancellableEnumerableDataProcess<T>
    {
        Task<IEnumerableDataProcessResult<T>> ExecuteAsync(CancellationToken cancellationToken);
    }
}
