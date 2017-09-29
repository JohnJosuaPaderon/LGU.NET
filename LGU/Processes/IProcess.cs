using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.Processes
{
    public interface IProcess
    {
        IProcessResult Execute();
        Task<IProcessResult> ExecuteAsync();
        Task<IProcessResult> ExecuteAsync(CancellationToken cancellationToken);
    }

    public interface IProcess<T>
    {
        IProcessResult<T> Execute();
        Task<IProcessResult<T>> ExecuteAsync();
        Task<IProcessResult<T>> ExecuteAsync(CancellationToken cancellationToken);
    }

    public interface IProcess<TConnection, TTransaction>
        where TConnection : DbConnection
        where TTransaction : DbTransaction
    {
        IProcessResult Execute(TConnection connection, TTransaction transaction);
        Task<IProcessResult> ExecuteAsync(TConnection connection, TTransaction transaction);
        Task<IProcessResult> ExecuteAsync(TConnection connection, TTransaction transaction, CancellationToken cancellationToken);
    }

    public interface IProcess<T, TConnection, TTransaction>
        where TConnection : DbConnection
        where TTransaction : DbTransaction
    {
        IProcessResult<T> Execute(TConnection connection, TTransaction transaction);
        Task<IProcessResult<T>> ExecuteAsync(TConnection connection, TTransaction transaction);
        Task<IProcessResult<T>> ExecuteAsync(TConnection connection, TTransaction transaction, CancellationToken cancellationToken);
    }
}
