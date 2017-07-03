using LGU.Entities;
using LGU.Entities.Core;
using LGU.EntityProcesses.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public class UserManager : IUserManager, IAsyncUserManager, ICancellableAsyncUserManager
    {
        protected static EntityCollection<User, ulong> StaticSource { get; } = new EntityCollection<User, ulong>();

        public UserManager(IDeleteUser deleteUser, IGetUserById getUserById, IGetUserList getUserList, IInsertUser insertUser, IUpdateUser updateUser)
        {
            IDeleteUser = deleteUser;
            IGetUserById = getUserById;
            IGetUserList = getUserList;
            IInsertUser = insertUser;
            IUpdateUser = updateUser;
        }

        protected IDeleteUser IDeleteUser { get; }
        protected IGetUserById IGetUserById { get; }
        protected IGetUserList IGetUserList { get; }
        protected IInsertUser IInsertUser { get; }
        protected IUpdateUser IUpdateUser { get; }

        
        private static void InvokeIfSuccess(IDataProcessResult<User> result, Action action)
        {
            if (result != null && result.Status == ProcessResultStatus.Success)
            {
                action();
            }
        }

        public IDataProcessResult<User> Delete(User user)
        {
            IDeleteUser.User = user;
            var result = IDeleteUser.Execute();
            InvokeIfSuccess(result, () => StaticSource.Remove(result.Data));

            return result;
        }

        public async Task<IDataProcessResult<User>> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            IDeleteUser.User = user;
            var result = await IDeleteUser.ExecuteAsync(cancellationToken);
            InvokeIfSuccess(result, () => StaticSource.Remove(result.Data));

            return result;
        }

        public async Task<IDataProcessResult<User>> DeleteAsync(User user)
        {
            IDeleteUser.User = user;
            var result = await IDeleteUser.ExecuteAsync();
            InvokeIfSuccess(result, () => StaticSource.Remove(result.Data));

            return result;
        }

        public IDataProcessResult<User> GetById(ulong userId)
        {
            IGetUserById.UserId = userId;
            var result = IGetUserById.Execute();
            InvokeIfSuccess(result, () => StaticSource.AddUpdate(result.Data));

            return result;
        }

        public async Task<IDataProcessResult<User>> GetByIdAsync(ulong userId, CancellationToken cancellationToken)
        {
            IGetUserById.UserId = userId;
            var result = await IGetUserById.ExecuteAsync(cancellationToken);
            InvokeIfSuccess(result, () => StaticSource.AddUpdate(result.Data));

            return result;
        }

        public async Task<IDataProcessResult<User>> GetByIdAsync(ulong userId)
        {
            IGetUserById.UserId = userId;
            var result = await IGetUserById.ExecuteAsync();
            InvokeIfSuccess(result, () => StaticSource.AddUpdate(result.Data));

            return result;
        }

        public IEnumerableDataProcessResult<User> GetList()
        {
            return IGetUserList.Execute();
        }

        public Task<IEnumerableDataProcessResult<User>> GetListAsync(CancellationToken cancellationToken)
        {
            return IGetUserList.ExecuteAsync(cancellationToken);
        }

        public Task<IEnumerableDataProcessResult<User>> GetListAsync()
        {
            return IGetUserList.ExecuteAsync();
        }

        public IDataProcessResult<User> Insert(User user)
        {
            IInsertUser.User = user;
            var result = IInsertUser.Execute();
            InvokeIfSuccess(result, () => StaticSource.Add(user));

            return result;
        }

        public async Task<IDataProcessResult<User>> InsertAsync(User user, CancellationToken cancellationToken)
        {
            IInsertUser.User = user;
            var result = await IInsertUser.ExecuteAsync(cancellationToken);
            InvokeIfSuccess(result, () => StaticSource.Add(user));

            return result;
        }

        public async Task<IDataProcessResult<User>> InsertAsync(User user)
        {
            IInsertUser.User = user;
            var result = await IInsertUser.ExecuteAsync();
            InvokeIfSuccess(result, () => StaticSource.Add(user));

            return result;
        }

        public IDataProcessResult<User> Update(User user)
        {
            IUpdateUser.User = user;
            var result = IUpdateUser.Execute();
            InvokeIfSuccess(result, () => StaticSource.Update(user));

            return result;
        }

        public async Task<IDataProcessResult<User>> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            IUpdateUser.User = user;
            var result = await IUpdateUser.ExecuteAsync(cancellationToken);
            InvokeIfSuccess(result, () => StaticSource.Update(user));

            return result;
        }

        public async Task<IDataProcessResult<User>> UpdateAsync(User user)
        {
            IUpdateUser.User = user;
            var result = await IUpdateUser.ExecuteAsync();
            InvokeIfSuccess(result, () => StaticSource.Update(user));

            return result;
        }
    }
}
