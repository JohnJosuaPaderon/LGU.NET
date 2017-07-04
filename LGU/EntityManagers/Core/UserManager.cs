using LGU.Entities;
using LGU.Entities.Core;
using LGU.EntityProcesses.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public sealed class UserManager : IUserManager, IAsyncUserManager, ICancellableAsyncUserManager
    {
        private static EntityCollection<User, ulong> StaticSource { get; } = new EntityCollection<User, ulong>();

        private readonly IDeleteUser DeleteUser;
        private readonly IGetUserById GetUserById;
        private readonly IGetUserList GetUserList;
        private readonly IInsertUser InsertUser;
        private readonly IUpdateUser UpdateUser;

        public UserManager(IDeleteUser deleteUser, IGetUserById getUserById, IGetUserList getUserList, IInsertUser insertUser, IUpdateUser updateUser)
        {
            DeleteUser = deleteUser;
            GetUserById = getUserById;
            GetUserList = getUserList;
            InsertUser = insertUser;
            UpdateUser = updateUser;
        }

        
        private static void InvokeIfSuccess(IDataProcessResult<User> result, Action action)
        {
            if (result != null && result.Status == ProcessResultStatus.Success)
            {
                action();
            }
        }

        public IDataProcessResult<User> Delete(User user)
        {
            DeleteUser.User = user;
            var result = DeleteUser.Execute();
            InvokeIfSuccess(result, () => StaticSource.Remove(result.Data));

            return result;
        }

        public async Task<IDataProcessResult<User>> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            DeleteUser.User = user;
            var result = await DeleteUser.ExecuteAsync(cancellationToken);
            InvokeIfSuccess(result, () => StaticSource.Remove(result.Data));

            return result;
        }

        public async Task<IDataProcessResult<User>> DeleteAsync(User user)
        {
            DeleteUser.User = user;
            var result = await DeleteUser.ExecuteAsync();
            InvokeIfSuccess(result, () => StaticSource.Remove(result.Data));

            return result;
        }

        public IDataProcessResult<User> GetById(ulong userId)
        {
            GetUserById.UserId = userId;
            var result = GetUserById.Execute();
            InvokeIfSuccess(result, () => StaticSource.AddUpdate(result.Data));

            return result;
        }

        public async Task<IDataProcessResult<User>> GetByIdAsync(ulong userId, CancellationToken cancellationToken)
        {
            GetUserById.UserId = userId;
            var result = await GetUserById.ExecuteAsync(cancellationToken);
            InvokeIfSuccess(result, () => StaticSource.AddUpdate(result.Data));

            return result;
        }

        public async Task<IDataProcessResult<User>> GetByIdAsync(ulong userId)
        {
            GetUserById.UserId = userId;
            var result = await GetUserById.ExecuteAsync();
            InvokeIfSuccess(result, () => StaticSource.AddUpdate(result.Data));

            return result;
        }

        public IEnumerableDataProcessResult<User> GetList()
        {
            return GetUserList.Execute();
        }

        public Task<IEnumerableDataProcessResult<User>> GetListAsync(CancellationToken cancellationToken)
        {
            return GetUserList.ExecuteAsync(cancellationToken);
        }

        public Task<IEnumerableDataProcessResult<User>> GetListAsync()
        {
            return GetUserList.ExecuteAsync();
        }

        public IDataProcessResult<User> Insert(User user)
        {
            InsertUser.User = user;
            var result = InsertUser.Execute();
            InvokeIfSuccess(result, () => StaticSource.Add(user));

            return result;
        }

        public async Task<IDataProcessResult<User>> InsertAsync(User user, CancellationToken cancellationToken)
        {
            InsertUser.User = user;
            var result = await InsertUser.ExecuteAsync(cancellationToken);
            InvokeIfSuccess(result, () => StaticSource.Add(user));

            return result;
        }

        public async Task<IDataProcessResult<User>> InsertAsync(User user)
        {
            InsertUser.User = user;
            var result = await InsertUser.ExecuteAsync();
            InvokeIfSuccess(result, () => StaticSource.Add(user));

            return result;
        }

        public IDataProcessResult<User> Update(User user)
        {
            UpdateUser.User = user;
            var result = UpdateUser.Execute();
            InvokeIfSuccess(result, () => StaticSource.Update(user));

            return result;
        }

        public async Task<IDataProcessResult<User>> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            UpdateUser.User = user;
            var result = await UpdateUser.ExecuteAsync(cancellationToken);
            InvokeIfSuccess(result, () => StaticSource.Update(user));

            return result;
        }

        public async Task<IDataProcessResult<User>> UpdateAsync(User user)
        {
            UpdateUser.User = user;
            var result = await UpdateUser.ExecuteAsync();
            InvokeIfSuccess(result, () => StaticSource.Update(user));

            return result;
        }
    }
}
