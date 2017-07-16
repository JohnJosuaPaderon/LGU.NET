using LGU.Entities;
using LGU.Entities.Core;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public interface IUserManager : IEntityManager<User, long>
    {
        IDataProcessResult<User> Login(UserCredentials userCredentials);
        Task<IDataProcessResult<User>> LoginAsync(UserCredentials userCredentials);
        Task<IDataProcessResult<User>> LoginAsync(UserCredentials userCredentials, CancellationToken cancellationToken);
    }
}
