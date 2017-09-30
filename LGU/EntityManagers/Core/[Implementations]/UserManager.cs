using LGU.Entities.Core;
using LGU.EntityProcesses.Core;
using LGU.Processes;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public sealed class UserManager : EntityManagerBase<IUser, long>, IUserManager
    {
        private readonly IDeleteUser r_DeleteUser;
        private readonly IGetUserById r_GetUserById;
        private readonly IGetUserList r_GetUserList;
        private readonly IInsertUser r_InsertUser;
        private readonly IUpdateUser r_UpdateUser;
        private readonly ILoginUser r_LoginUser;
        private readonly IIsUsernameExists r_IsUsernameExists;

        public UserManager(
            IDeleteUser deleteUser, 
            IGetUserById getUserById,
            IGetUserList getUserList,
            IInsertUser insertUser,
            IUpdateUser updateUser,
            ILoginUser loginUser,
            IIsUsernameExists sUsernameExists)
        {
            r_DeleteUser = deleteUser;
            r_GetUserById = getUserById;
            r_GetUserList = getUserList;
            r_InsertUser = insertUser;
            r_UpdateUser = updateUser;
            r_LoginUser = loginUser;
            r_IsUsernameExists = sUsernameExists;
        }

        public IProcessResult<IUser> Delete(IUser user)
        {
            r_DeleteUser.User = user;
            var result = r_DeleteUser.Execute();
            RemoveIfSuccess(result);

            return result;
        }

        public async Task<IProcessResult<IUser>> DeleteAsync(IUser user, CancellationToken cancellationToken)
        {
            r_DeleteUser.User = user;
            var result = await r_DeleteUser.ExecuteAsync(cancellationToken);
            RemoveIfSuccess(result);

            return result;
        }

        public async Task<IProcessResult<IUser>> DeleteAsync(IUser user)
        {
            r_DeleteUser.User = user;
            var result = await r_DeleteUser.ExecuteAsync();
            RemoveIfSuccess(result);

            return result;
        }

        public IProcessResult<IUser> GetById(long userId)
        {
            r_GetUserById.UserId = userId;
            var result = r_GetUserById.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IProcessResult<IUser>> GetByIdAsync(long userId, CancellationToken cancellationToken)
        {
            r_GetUserById.UserId = userId;
            var result = await r_GetUserById.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IProcessResult<IUser>> GetByIdAsync(long userId)
        {
            r_GetUserById.UserId = userId;
            var result = await r_GetUserById.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public IEnumerableProcessResult<IUser> GetList()
        {
            var result = r_GetUserList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<IUser>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetUserList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<IUser>> GetListAsync()
        {
            var result = await r_GetUserList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public IProcessResult<IUser> Insert(IUser user)
        {
            r_InsertUser.User = user;
            var result = r_InsertUser.Execute();
            AddIfSuccess(result);

            return result;
        }

        public async Task<IProcessResult<IUser>> InsertAsync(IUser user, CancellationToken cancellationToken)
        {
            r_InsertUser.User = user;
            var result = await r_InsertUser.ExecuteAsync(cancellationToken);
            AddIfSuccess(result);

            return result;
        }

        public async Task<IProcessResult<IUser>> InsertAsync(IUser user)
        {
            r_InsertUser.User = user;
            var result = await r_InsertUser.ExecuteAsync();
            AddIfSuccess(result);

            return result;
        }

        public IProcessResult<IUser> Update(IUser user)
        {
            r_UpdateUser.User = user;
            var result = r_UpdateUser.Execute();
            UpdateIfSuccess(result);

            return result;
        }

        public async Task<IProcessResult<IUser>> UpdateAsync(IUser user, CancellationToken cancellationToken)
        {
            r_UpdateUser.User = user;
            var result = await r_UpdateUser.ExecuteAsync(cancellationToken);
            UpdateIfSuccess(result);

            return result;
        }

        public async Task<IProcessResult<IUser>> UpdateAsync(IUser user)
        {
            r_UpdateUser.User = user;
            var result = await r_UpdateUser.ExecuteAsync();
            UpdateIfSuccess(result);

            return result;
        }

        public IProcessResult<IUser> Login(IUserCredentials userCredentials)
        {
            r_LoginUser.UserCredentials = userCredentials;
            return r_LoginUser.Execute();
        }

        public Task<IProcessResult<IUser>> LoginAsync(IUserCredentials userCredentials)
        {
            r_LoginUser.UserCredentials = userCredentials;
            return r_LoginUser.ExecuteAsync();
        }

        public Task<IProcessResult<IUser>> LoginAsync(IUserCredentials userCredentials, CancellationToken cancellationToken)
        {
            r_LoginUser.UserCredentials = userCredentials;
            return r_LoginUser.ExecuteAsync(cancellationToken);
        }

        public IProcessResult<bool> IsUsernameExists(SecureString secureUsername)
        {
            if (secureUsername == null || secureUsername.Length <= 0)
            {
                return new ProcessResult<bool>(ProcessResultStatus.Failed, "Username is invalid.");
            }
            else
            {
                r_IsUsernameExists.SecureUsername = secureUsername;
                return r_IsUsernameExists.Execute();
            }
        }

        public async Task<IProcessResult<bool>> IsUsernameExistsAsync(SecureString secureUsername)
        {
            if (secureUsername == null || secureUsername.Length <= 0)
            {
                return new ProcessResult<bool>(ProcessResultStatus.Failed, "Username is invalid.");
            }
            else
            {
                r_IsUsernameExists.SecureUsername = secureUsername;
                return await r_IsUsernameExists.ExecuteAsync();
            }
        }

        public async Task<IProcessResult<bool>> IsUsernameExistsAsync(SecureString secureUsername, CancellationToken cancellationToken)
        {
            if (secureUsername == null || secureUsername.Length <= 0)
            {
                return new ProcessResult<bool>(ProcessResultStatus.Failed, "Username is invalid.");
            }
            else
            {
                r_IsUsernameExists.SecureUsername = secureUsername;
                return await r_IsUsernameExists.ExecuteAsync(cancellationToken);
            }
        }
    }
}
