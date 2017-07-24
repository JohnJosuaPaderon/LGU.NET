using LGU.Entities.Core;
using LGU.EntityProcesses.Core;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public sealed class UserTypeManager : ManagerBase<UserType, short>, IUserTypeManager
    {
        private readonly IGetUserTypeById r_GetUserTypeById;
        private readonly IGetUserTypeList r_GetUserTypeList;
        
        public UserTypeManager(IGetUserTypeById getUserTypeById, IGetUserTypeList getUserTypeList)
        {
            r_GetUserTypeById = getUserTypeById;
            r_GetUserTypeList = getUserTypeList;
        }

        public IProcessResult<UserType> GetById(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<UserType>(StaticSource[id]);
                }
                else
                {
                    r_GetUserTypeById.UserTypeId = id;
                    var result = r_GetUserTypeById.Execute();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<UserType>(ProcessResultStatus.Failed, "Invalid user type identifier.");
            }
        }

        public async Task<IProcessResult<UserType>> GetByIdAsync(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<UserType>(StaticSource[id]);
                }
                else
                {
                    r_GetUserTypeById.UserTypeId = id;
                    var result = await r_GetUserTypeById.ExecuteAsync();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<UserType>(ProcessResultStatus.Failed, "Invalid user type identifier.");
            }
        }

        public async Task<IProcessResult<UserType>> GetByIdAsync(short id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<UserType>(StaticSource[id]);
                }
                else
                {
                    r_GetUserTypeById.UserTypeId = id;
                    var result = await r_GetUserTypeById.ExecuteAsync(cancellationToken);
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<UserType>(ProcessResultStatus.Failed, "Invalid user type identifier.");
            }
        }

        public IEnumerableProcessResult<UserType> GetList()
        {
            var result = r_GetUserTypeList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<UserType>> GetListAsync()
        {
            var result = await r_GetUserTypeList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<UserType>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetUserTypeList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }
    }
}
