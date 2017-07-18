using LGU.Entities;
using LGU.Entities.Core;
using LGU.EntityProcesses.Core;
using LGU.Processes;
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

        public IProcessResult<UserStatus> GetById(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<UserStatus>(StaticSource[id]);
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
                return new ProcessResult<UserStatus>(ProcessResultStatus.Failed, "Invalid user status identifier.");
            }
        }

        public async Task<IProcessResult<UserStatus>> GetByIdAsync(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<UserStatus>(StaticSource[id]);
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
                return new ProcessResult<UserStatus>(ProcessResultStatus.Failed, "Invalid user status identifier.");
            }
        }

        public async Task<IProcessResult<UserStatus>> GetByIdAsync(short id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<UserStatus>(StaticSource[id]);
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
                return new ProcessResult<UserStatus>(ProcessResultStatus.Failed, "Invalid user status identifier.");
            }
        }

        public IEnumerableProcessResult<UserStatus> GetList()
        {
            return GetListProc.Execute();
        }

        public Task<IEnumerableProcessResult<UserStatus>> GetListAsync()
        {
            return GetListProc.ExecuteAsync();
        }

        public Task<IEnumerableProcessResult<UserStatus>> GetListAsync(CancellationToken cancellationToken)
        {
            return GetListProc.ExecuteAsync(cancellationToken);
        }
    }
}
