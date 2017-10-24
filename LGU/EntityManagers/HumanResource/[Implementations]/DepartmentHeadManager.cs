using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class DepartmentHeadManager : EntityManagerBase<IDepartmentHead, long>, IDepartmentHeadManager
    {
        private const string MESSAGE_INVALID = "Invalid department head.";
        private const string MESSAGE_INVALID_IDENTIFIER = "Invalid department head identifier.";

        public DepartmentHeadManager(
            IDeleteDepartmentHead delete,
            IGetDepartmentHeadById getById,
            IGetDepartmentHeadList getList,
            IInsertDepartmentHead<SqlConnection, SqlTransaction> insert,
            IUpdateDepartmentHead update)
        {
            _Delete = delete;
            _GetById = getById;
            _GetList = getList;
            _Insert = insert;
            _Update = update;

            _InvalidResult = new ProcessResult<IDepartmentHead>(ProcessResultStatus.Failed, MESSAGE_INVALID);
            _InvalidIdentifierResult = new ProcessResult<IDepartmentHead>(ProcessResultStatus.Failed, MESSAGE_INVALID_IDENTIFIER);
        }

        private readonly IDeleteDepartmentHead _Delete;
        private readonly IGetDepartmentHeadById _GetById;
        private readonly IGetDepartmentHeadList _GetList;
        private readonly IInsertDepartmentHead<SqlConnection, SqlTransaction> _Insert;
        private readonly IUpdateDepartmentHead _Update;
        private readonly IProcessResult<IDepartmentHead> _InvalidResult;
        private readonly IProcessResult<IDepartmentHead> _InvalidIdentifierResult;

        public IProcessResult<IDepartmentHead> Delete(IDepartmentHead data)
        {
            if (data != null)
            {
                _Delete.DepartmentHead = data;
                return RemoveIfSuccess(_Delete.Execute());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IDepartmentHead>> DeleteAsync(IDepartmentHead data)
        {
            if (data != null)
            {
                _Delete.DepartmentHead = data;
                return RemoveIfSuccess(await _Delete.ExecuteAsync());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IDepartmentHead>> DeleteAsync(IDepartmentHead data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                _Delete.DepartmentHead = data;
                return RemoveIfSuccess(await _Delete.ExecuteAsync(cancellationToken));
            }
            else
            {
                return _InvalidResult;
            }
        }

        public IProcessResult<IDepartmentHead> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IDepartmentHead>(StaticSource[id]);
                }
                else
                {
                    _GetById.DepartmentHeadId = id;
                    return AddUpdateIfSuccess(_GetById.Execute());
                }
            }
            else
            {
                return _InvalidIdentifierResult;
            }
        }

        public async Task<IProcessResult<IDepartmentHead>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IDepartmentHead>(StaticSource[id]);
                }
                else
                {
                    _GetById.DepartmentHeadId = id;
                    return AddUpdateIfSuccess(await _GetById.ExecuteAsync());
                }
            }
            else
            {
                return _InvalidIdentifierResult;
            }
        }

        public async Task<IProcessResult<IDepartmentHead>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IDepartmentHead>(StaticSource[id]);
                }
                else
                {
                    _GetById.DepartmentHeadId = id;
                    return AddUpdateIfSuccess(await _GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return _InvalidIdentifierResult;
            }
        }

        public IEnumerableProcessResult<IDepartmentHead> GetList()
        {
            return AddUpdateIfSuccess(_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<IDepartmentHead>> GetListAsync()
        {
            return AddUpdateIfSuccess(await _GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<IDepartmentHead>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await _GetList.ExecuteAsync(cancellationToken));
        }

        public IProcessResult<IDepartmentHead> Insert(IDepartmentHead data)
        {
            if (data != null)
            {
                _Insert.DepartmentHead = data;
                return AddIfSuccess(_Insert.Execute());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IDepartmentHead>> InsertAsync(IDepartmentHead data)
        {
            if (data != null)
            {
                _Insert.DepartmentHead = data;
                return AddIfSuccess(await _Insert.ExecuteAsync());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IDepartmentHead>> InsertAsync(IDepartmentHead data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                _Insert.DepartmentHead = data;
                return AddIfSuccess(await _Insert.ExecuteAsync(cancellationToken));
            }
            else
            {
                return _InvalidResult;
            }
        }

        public IProcessResult<IDepartmentHead> Update(IDepartmentHead data)
        {
            if (data != null)
            {
                _Update.DepartmentHead = data;
                return UpdateIfSuccess(_Update.Execute());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IDepartmentHead>> UpdateAsync(IDepartmentHead data)
        {
            if (data != null)
            {
                _Update.DepartmentHead = data;
                return UpdateIfSuccess(await _Update.ExecuteAsync());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IDepartmentHead>> UpdateAsync(IDepartmentHead data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                _Update.DepartmentHead = data;
                return UpdateIfSuccess(await _Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return _InvalidResult;
            }
        }
    }
}
