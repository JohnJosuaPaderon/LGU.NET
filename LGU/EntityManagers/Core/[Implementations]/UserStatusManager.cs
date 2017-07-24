using LGU.Entities.Core;
using LGU.EntityProcesses.Core;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public sealed class UserStatusManager : ManagerBase<UserStatus, short>, IUserStatusManager
    {
        private readonly IGetUserStatusById r_GetUserStatusById;
        private readonly IGetUserStatusList r_GetUserStatusList;

        public UserStatusManager(
            IGetUserStatusById getUserStatusById,
            IGetUserStatusList getUserStatusList)
        {
            r_GetUserStatusById = getUserStatusById;
            r_GetUserStatusList = getUserStatusList;
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
                    r_GetUserStatusById.UserStatusId = id;
                    var result = r_GetUserStatusById.Execute();
                    AddUpdateIfSuccess(result);

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
                    r_GetUserStatusById.UserStatusId = id;
                    var result = await r_GetUserStatusById.ExecuteAsync();
                    AddUpdateIfSuccess(result);

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
                    r_GetUserStatusById.UserStatusId = id;
                    var result = await r_GetUserStatusById.ExecuteAsync(cancellationToken);
                    AddUpdateIfSuccess(result);

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
            var result = r_GetUserStatusList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<UserStatus>> GetListAsync()
        {
            var result = await r_GetUserStatusList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<UserStatus>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetUserStatusList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }
    }
}
