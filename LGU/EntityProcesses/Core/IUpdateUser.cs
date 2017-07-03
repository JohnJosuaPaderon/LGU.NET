using LGU.Entities.Core;

namespace LGU.EntityProcesses.Core
{
    public interface IUpdateUser : IDataProcess<User>, IAsyncDataProcess<User>, ICancellableAsyncDataProcess<User>
    {
        User User { get; set; }
    }
}
