﻿using LGU.Entities;
using LGU.Entities.Core;

namespace LGU.EntityManagers.Core
{
    public interface IUserManager : IEntityManager<User, ulong>, IAsyncEntityManager<User, ulong>, ICancellableAsyncEntityManager<User, ulong>
    {
    }
}
