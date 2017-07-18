using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers
{
    public interface ISystemManager
    {
        IProcessResult<DateTime> GetSystemDate();
        Task<IProcessResult<DateTime>> GetSystemDateAsync();
        Task<IProcessResult<DateTime>> GetSystemDateAsync(CancellationToken cancellationToken);
    }
}
