using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU
{
    public interface IProcess
    {
        IProcessResult Execute { get; }
    }

    public interface IProcessAsync
    {
        Task<IProcessResult> ExecuteAsync();
    }

    public interface ICancellableProcessAsync
    {
        Task<IProcessResult> ExecuteAsync(CancellationToken cancellationToken);
    }
}
