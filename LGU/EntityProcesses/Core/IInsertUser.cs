using LGU.Entities.Core;

namespace LGU.EntityProcesses.Core
{
    public interface IInsertUser : IDataProcess<User>, IAsyncDataProcess<User>, ICancellableAsyncDataProcess<User>
    {
        User User { get; set; }
    }
}
