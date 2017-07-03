using LGU.Entities.Core;

namespace LGU.EntityProcesses.Core
{
    public interface IGetUserList : IEnumerableDataProcess<User>, IAsyncEnumerableDataProcess<User>, ICancellableEnumerableDataProcess<User>
    {
    }
}
