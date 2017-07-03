using LGU.Entities.Core;

namespace LGU.EntityProcesses.Core
{
    public interface IGetUserById : IDataProcess<User>, IAsyncDataProcess<User>, ICancellableAsyncDataProcess<User>
    {
        ulong UserId { get; set; }
    }
}
