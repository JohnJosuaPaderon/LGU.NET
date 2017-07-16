using System.Threading;
using System.Threading.Tasks;

namespace LGU
{
    public interface IProcess
    {
        IProcessResult Execute { get; }
        Task<IProcessResult> ExecuteAsync();
        Task<IProcessResult> ExecuteAsync(CancellationToken cancellationToken);
    }
}
