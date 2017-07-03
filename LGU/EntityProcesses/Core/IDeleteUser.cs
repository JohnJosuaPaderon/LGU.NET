using LGU.Entities.Core;

namespace LGU.EntityProcesses.Core
{
    public interface IDeleteUser : IDataProcess<User>, IAsyncDataProcess<User>, ICancellableAsyncDataProcess<User>
    {
        User User { get; set; }
    }
}
