using System;

namespace LGU.EntityProcesses
{
    public interface IGetSystemDate : IDataProcess<DateTime>, IAsyncDataProcess<DateTime>, ICancellableAsyncDataProcess<DateTime>
    {
    }
}
