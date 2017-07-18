using LGU.Entities;
using LGU.Entities.Core;
using LGU.EntityProcesses.Core;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public sealed class UserTypeManager : IUserTypeManager
    {
        private readonly IGetUserTypeById GetByIdProc;
        private readonly IGetUserTypeList GetListProc;

        private static EntityCollection<UserType, short> StaticSource { get; } = new EntityCollection<UserType, short>();

        public UserTypeManager(IGetUserTypeById getByIdProc, IGetUserTypeList getListProc)
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
                    GetByIdProc.UserTypeId = id;
                    var result = GetByIdProc.Execute();
                    InvokeIfSuccess(result.Status, () => StaticSource.AddUpdate(result.Data));

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
                    GetByIdProc.UserTypeId = id;
                    var result = await GetByIdProc.ExecuteAsync();
                    InvokeIfSuccess(result.Status, () => StaticSource.AddUpdate(result.Data));

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
                    GetByIdProc.UserTypeId = id;
                    var result = await GetByIdProc.ExecuteAsync(cancellationToken);
                    InvokeIfSuccess(result.Status, () => StaticSource.AddUpdate(result.Data));

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
            throw new NotImplementedException();
        }

        public Task<IEnumerableProcessResult<UserType>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerableProcessResult<UserType>> GetListAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
