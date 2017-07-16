using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LGU.Entities.Core;
using LGU.EntityProcesses.Core;
using LGU.Entities;

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

        public IDataProcessResult<UserType> GetById(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new DataProcessResult<UserType>(StaticSource[id]);
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
                return new DataProcessResult<UserType>(ProcessResultStatus.Failed, "Invalid user type identifier.");
            }
        }

        public async Task<IDataProcessResult<UserType>> GetByIdAsync(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new DataProcessResult<UserType>(StaticSource[id]);
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
                return new DataProcessResult<UserType>(ProcessResultStatus.Failed, "Invalid user type identifier.");
            }
        }

        public async Task<IDataProcessResult<UserType>> GetByIdAsync(short id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new DataProcessResult<UserType>(StaticSource[id]);
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
                return new DataProcessResult<UserType>(ProcessResultStatus.Failed, "Invalid user type identifier.");
            }
        }

        public IEnumerableDataProcessResult<UserType> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerableDataProcessResult<UserType>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerableDataProcessResult<UserType>> GetListAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
