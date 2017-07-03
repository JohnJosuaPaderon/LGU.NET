using LGU.Entities;
using LGU.Entities.Core;

namespace LGU.EntityManagers.Core
{
    public interface IUserManager : IEntityManager<User, ulong>
    {
    }

    public interface IAsyncUserManager : IAsyncEntityManager<User, ulong>
    {

    }

    public interface ICancellableAsyncUserManager : ICancellableAsyncEntityManager<User, ulong>
    {

    }
}
