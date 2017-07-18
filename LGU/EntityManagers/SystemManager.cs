using LGU.EntityProcesses;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers
{
    public sealed class SystemManager : ISystemManager
    {
        private readonly IGetSystemDate GetSystemDateProc;

        public SystemManager(IGetSystemDate getSystemDate)
        {
            GetSystemDateProc = getSystemDate;
        }

        public IProcessResult<DateTime> GetSystemDate()
        {
            return GetSystemDateProc.Execute();
        }

        public Task<IProcessResult<DateTime>> GetSystemDateAsync(CancellationToken cancellationToken)
        {
            return GetSystemDateProc.ExecuteAsync(cancellationToken);
        }

        public Task<IProcessResult<DateTime>> GetSystemDateAsync()
        {
            return GetSystemDateProc.ExecuteAsync();
        }
    }
}
