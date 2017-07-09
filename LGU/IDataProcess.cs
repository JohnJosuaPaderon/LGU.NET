using System.Threading;
using System.Threading.Tasks;

namespace LGU
{
    public interface IDataProcess<T>
    {
        IDataProcessResult<T> Execute();
        Task<IDataProcessResult<T>> ExecuteAsync();
        Task<IDataProcessResult<T>> ExecuteAsync(CancellationToken cancellationToken);
    }
}
