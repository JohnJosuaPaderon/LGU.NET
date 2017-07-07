using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers
{
    public interface ISystemManager
    {
        IDataProcessResult<DateTime> GetSystemDate();
        Task<IDataProcessResult<DateTime>> GetSystemDateAsync();
        Task<IDataProcessResult<DateTime>> GetSystemDateAsync(CancellationToken cancellationToken);
    }
}
