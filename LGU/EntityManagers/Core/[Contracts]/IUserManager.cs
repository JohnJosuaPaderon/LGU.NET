using LGU.Entities;
using LGU.Entities.Core;
using LGU.Processes;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public interface IUserManager : IEntityManager<IUser, long>
    {
        IProcessResult<IUser> Login(IUserCredentials userCredentials);
        Task<IProcessResult<IUser>> LoginAsync(IUserCredentials userCredentials);
        Task<IProcessResult<IUser>> LoginAsync(IUserCredentials userCredentials, CancellationToken cancellationToken);
        IProcessResult<bool> IsUsernameExists(SecureString secureUsername);
        Task<IProcessResult<bool>> IsUsernameExistsAsync(SecureString secureUsername);
        Task<IProcessResult<bool>> IsUsernameExistsAsync(SecureString secureUsername, CancellationToken cancellationToken);
    }
}
