using LGU.Entities;
using LGU.Entities.Core;
using LGU.Processes;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public interface IUserManager : IEntityManager<User, long>
    {
        IProcessResult<User> Login(UserCredentials userCredentials);
        Task<IProcessResult<User>> LoginAsync(UserCredentials userCredentials);
        Task<IProcessResult<User>> LoginAsync(UserCredentials userCredentials, CancellationToken cancellationToken);
        IProcessResult<bool> IsUsernameExists(SecureString secureUsername);
        Task<IProcessResult<bool>> IsUsernameExistsAsync(SecureString secureUsername);
        Task<IProcessResult<bool>> IsUsernameExistsAsync(SecureString secureUsername, CancellationToken cancellationToken);
    }
}
