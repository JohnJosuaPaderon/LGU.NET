﻿using LGU.Entities;
using LGU.Entities.Core;
using LGU.EntityProcesses.Core;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public sealed class UserManager : IUserManager
    {
        private static EntityCollection<User, long> StaticSource { get; } = new EntityCollection<User, long>();

        private readonly IDeleteUser DeleteProc;
        private readonly IGetUserById GetByIdProc;
        private readonly IGetUserList GetListProc;
        private readonly IInsertUser InsertProc;
        private readonly IUpdateUser UpdateProc;
        private readonly ILoginUser LoginProc;

        public UserManager(
            IDeleteUser deleteProc, 
            IGetUserById getByIdProc,
            IGetUserList getListProc,
            IInsertUser insertProc,
            IUpdateUser updateProc,
            ILoginUser loginProc)
        {
            DeleteProc = deleteProc;
            GetByIdProc = getByIdProc;
            GetListProc = getListProc;
            InsertProc = insertProc;
            UpdateProc = updateProc;
            LoginProc = loginProc;
        }
        
        private static void InvokeIfSuccess(IProcessResult<User> result, Action action)
        {
            if (result != null && result.Status == ProcessResultStatus.Success)
            {
                action();
            }
        }

        public IProcessResult<User> Delete(User user)
        {
            DeleteProc.User = user;
            var result = DeleteProc.Execute();
            InvokeIfSuccess(result, () => StaticSource.Remove(result.Data));

            return result;
        }

        public async Task<IProcessResult<User>> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            DeleteProc.User = user;
            var result = await DeleteProc.ExecuteAsync(cancellationToken);
            InvokeIfSuccess(result, () => StaticSource.Remove(result.Data));

            return result;
        }

        public async Task<IProcessResult<User>> DeleteAsync(User user)
        {
            DeleteProc.User = user;
            var result = await DeleteProc.ExecuteAsync();
            InvokeIfSuccess(result, () => StaticSource.Remove(result.Data));

            return result;
        }

        public IProcessResult<User> GetById(long userId)
        {
            GetByIdProc.UserId = userId;
            var result = GetByIdProc.Execute();
            InvokeIfSuccess(result, () => StaticSource.AddUpdate(result.Data));

            return result;
        }

        public async Task<IProcessResult<User>> GetByIdAsync(long userId, CancellationToken cancellationToken)
        {
            GetByIdProc.UserId = userId;
            var result = await GetByIdProc.ExecuteAsync(cancellationToken);
            InvokeIfSuccess(result, () => StaticSource.AddUpdate(result.Data));

            return result;
        }

        public async Task<IProcessResult<User>> GetByIdAsync(long userId)
        {
            GetByIdProc.UserId = userId;
            var result = await GetByIdProc.ExecuteAsync();
            InvokeIfSuccess(result, () => StaticSource.AddUpdate(result.Data));

            return result;
        }

        public IEnumerableProcessResult<User> GetList()
        {
            return GetListProc.Execute();
        }

        public Task<IEnumerableProcessResult<User>> GetListAsync(CancellationToken cancellationToken)
        {
            return GetListProc.ExecuteAsync(cancellationToken);
        }

        public Task<IEnumerableProcessResult<User>> GetListAsync()
        {
            return GetListProc.ExecuteAsync();
        }

        public IProcessResult<User> Insert(User user)
        {
            InsertProc.User = user;
            var result = InsertProc.Execute();
            InvokeIfSuccess(result, () => StaticSource.Add(user));

            return result;
        }

        public async Task<IProcessResult<User>> InsertAsync(User user, CancellationToken cancellationToken)
        {
            InsertProc.User = user;
            var result = await InsertProc.ExecuteAsync(cancellationToken);
            InvokeIfSuccess(result, () => StaticSource.Add(user));

            return result;
        }

        public async Task<IProcessResult<User>> InsertAsync(User user)
        {
            InsertProc.User = user;
            var result = await InsertProc.ExecuteAsync();
            InvokeIfSuccess(result, () => StaticSource.Add(user));

            return result;
        }

        public IProcessResult<User> Update(User user)
        {
            UpdateProc.User = user;
            var result = UpdateProc.Execute();
            InvokeIfSuccess(result, () => StaticSource.Update(user));

            return result;
        }

        public async Task<IProcessResult<User>> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            UpdateProc.User = user;
            var result = await UpdateProc.ExecuteAsync(cancellationToken);
            InvokeIfSuccess(result, () => StaticSource.Update(user));

            return result;
        }

        public async Task<IProcessResult<User>> UpdateAsync(User user)
        {
            UpdateProc.User = user;
            var result = await UpdateProc.ExecuteAsync();
            InvokeIfSuccess(result, () => StaticSource.Update(user));

            return result;
        }

        public IProcessResult<User> Login(UserCredentials userCredentials)
        {
            LoginProc.UserCredentials = userCredentials;
            return LoginProc.Execute();
        }

        public Task<IProcessResult<User>> LoginAsync(UserCredentials userCredentials)
        {
            LoginProc.UserCredentials = userCredentials;
            return LoginProc.ExecuteAsync();
        }

        public Task<IProcessResult<User>> LoginAsync(UserCredentials userCredentials, CancellationToken cancellationToken)
        {
            LoginProc.UserCredentials = userCredentials;
            return LoginProc.ExecuteAsync(cancellationToken);
        }
    }
}
