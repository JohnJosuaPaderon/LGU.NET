using LGU.EntityProcesses;
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

        public IDataProcessResult<DateTime> GetSystemDate()
        {
            return GetSystemDateProc.Execute();
        }

        public Task<IDataProcessResult<DateTime>> GetSystemDateAsync(CancellationToken cancellationToken)
        {
            return GetSystemDateProc.ExecuteAsync(cancellationToken);
        }

        public Task<IDataProcessResult<DateTime>> GetSystemDateAsync()
        {
            return GetSystemDateProc.ExecuteAsync();
        }
    }
}
