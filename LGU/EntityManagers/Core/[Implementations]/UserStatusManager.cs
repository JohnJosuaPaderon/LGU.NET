using LGU.Entities;
using LGU.Entities.Core;
using LGU.EntityProcesses.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public sealed class UserStatusManager : IUserStatusManager
    {
        private readonly IGetUserStatusById GetByIdProc;
        private readonly IGetUserStatusList GetListProc;

        private static EntityCollection<UserStatus, short> StaticSource { get; } = new EntityCollection<UserStatus, short>();

        public UserStatusManager(
            IGetUserStatusById getByIdProc,
            IGetUserStatusList getListProc)
        {
            GetByIdProc = getByIdProc;
            GetListProc = getListProc;
        }

        private static void InvokeIfSuccess(ProcessResultStatus status, Action expression)
        {
            if (status == ProcessResultStatus.Success)
            {
                expression();
            }
        }

        public IDataProcessResult<UserStatus> GetById(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new DataProcessResult<UserStatus>(StaticSource[id]);
                }
                else
                {
                    GetByIdProc.UserStatusId = id;
                    var result = GetByIdProc.Execute();
                    InvokeIfSuccess(result.Status, () => StaticSource.AddUpdate(result.Data));

                    return result;
                }
            }
            else
            {
                return new DataProcessResult<UserStatus>(ProcessResultStatus.Failed, "Invalid user status identifier.");
            }
        }

        public async Task<IDataProcessResult<UserStatus>> GetByIdAsync(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new DataProcessResult<UserStatus>(StaticSource[id]);
                }
                else
                {
                    GetByIdProc.UserStatusId = id;
                    var result = await GetByIdProc.ExecuteAsync();
                    InvokeIfSuccess(result.Status, () => StaticSource.AddUpdate(result.Data));

                    return result;
                }
            }
            else
            {
                return new DataProcessResult<UserStatus>(ProcessResultStatus.Failed, "Invalid user status identifier.");
            }
        }

        public async Task<IDataProcessResult<UserStatus>> GetByIdAsync(short id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new DataProcessResult<UserStatus>(StaticSource[id]);
                }
                else
                {
                    GetByIdProc.UserStatusId = id;
                    var result = await GetByIdProc.ExecuteAsync(cancellationToken);
                    InvokeIfSuccess(result.Status, () => StaticSource.AddUpdate(result.Data));

                    return result;
                }
            }
            else
            {
                return new DataProcessResult<UserStatus>(ProcessResultStatus.Failed, "Invalid user status identifier.");
            }
        }

        public IEnumerableDataProcessResult<UserStatus> GetList()
        {
            return GetListProc.Execute();
        }

        public Task<IEnumerableDataProcessResult<UserStatus>> GetListAsync()
        {
            return GetListProc.ExecuteAsync();
        }

        public Task<IEnumerableDataProcessResult<UserStatus>> GetListAsync(CancellationToken cancellationToken)
        {
            return GetListProc.ExecuteAsync(cancellationToken);
        }
    }
}
