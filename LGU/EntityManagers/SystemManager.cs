using LGU.EntityProcesses;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers
{
    public sealed class SystemManager : ISystemManager
    {
        private readonly IGetSystemDate r_GetSystemDate;

        public SystemManager(IGetSystemDate getSystemDate)
        {
            r_GetSystemDate = getSystemDate;
        }

        public IProcessResult<DateTime> GetSystemDate()
        {
            return r_GetSystemDate.Execute();
        }

        public Task<IProcessResult<DateTime>> GetSystemDateAsync(CancellationToken cancellationToken)
        {
            return r_GetSystemDate.ExecuteAsync(cancellationToken);
        }

        public Task<IProcessResult<DateTime>> GetSystemDateAsync()
        {
            return r_GetSystemDate.ExecuteAsync();
        }
    }
}
