using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class DepartmentManager : EntityManagerBase<IDepartment, int>, IDepartmentManager
    {
        private readonly IDeleteDepartment _Delete;
        private readonly IGetDepartmentById _GetById;
        private readonly IGetDepartmentList _GetList;
        private readonly IInsertDepartment _Insert;
        private readonly IUpdateDepartment _Update;
        private readonly ISearchDepartment _Search;
        private readonly IGetDepartmentListWithTimeLog _GetListWithTimeLog;

        public DepartmentManager(
            IDeleteDepartment delete,
            IGetDepartmentById getById,
            IGetDepartmentList getList,
            IInsertDepartment insert,
            IUpdateDepartment update,
            ISearchDepartment search,
            IGetDepartmentListWithTimeLog getListWithTimeLog)
        {
            _Delete = delete;
            _GetById = getById;
            _GetList = getList;
            _Insert = insert;
            _Update = update;
            _Search = search;
            _GetListWithTimeLog = getListWithTimeLog;
        }

        public IProcessResult<IDepartment> Delete(IDepartment data)
        {
            if (data != null)
            {
                _Delete.Department = data;
                return RemoveIfSuccess(_Delete.Execute());
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IProcessResult<IDepartment>> DeleteAsync(IDepartment data)
        {
            if (data != null)
            {
                _Delete.Department = data;
                return RemoveIfSuccess(await _Delete.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IProcessResult<IDepartment>> DeleteAsync(IDepartment data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                _Delete.Department = data;
                return RemoveIfSuccess(await _Delete.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public IProcessResult<IDepartment> GetById(int id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IDepartment>(StaticSource[id]);
                }
                else
                {
                    _GetById.DepartmentId = id;
                    return AddUpdateIfSuccess(_GetById.Execute()); 
                }
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department identifier.");
            }
        }

        public async Task<IProcessResult<IDepartment>> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IDepartment>(StaticSource[id]);
                }
                else
                {
                    _GetById.DepartmentId = id;
                    return AddUpdateIfSuccess(await _GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department identifier.");
            }
        }

        public async Task<IProcessResult<IDepartment>> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IDepartment>(StaticSource[id]);
                }
                else
                {
                    _GetById.DepartmentId = id;
                    return AddUpdateIfSuccess(await _GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department identifier.");
            }
        }

        public IEnumerableProcessResult<IDepartment> GetList()
        {
            return AddUpdateIfSuccess(_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<IDepartment>> GetListAsync()
        {
            return AddUpdateIfSuccess(await _GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<IDepartment>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await _GetList.ExecuteAsync(cancellationToken));
        }

        public IProcessResult<IDepartment> Insert(IDepartment data)
        {
            if (data != null)
            {
                _Insert.Department = data;
                return AddIfSuccess(_Insert.Execute());
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IProcessResult<IDepartment>> InsertAsync(IDepartment data)
        {
            if (data != null)
            {
                _Insert.Department = data;
                return AddIfSuccess(await _Insert.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IProcessResult<IDepartment>> InsertAsync(IDepartment data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                _Insert.Department = data;
                return AddIfSuccess(await _Insert.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public IProcessResult<IDepartment> Update(IDepartment data)
        {
            if (data != null)
            {
                _Update.Department = data;
                return UpdateIfSuccess(_Update.Execute());
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IProcessResult<IDepartment>> UpdateAsync(IDepartment data)
        {
            if (data != null)
            {
                _Update.Department = data;
                return UpdateIfSuccess(await _Update.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IProcessResult<IDepartment>> UpdateAsync(IDepartment data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                _Update.Department = data;
                return UpdateIfSuccess(await _Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public IEnumerableProcessResult<IDepartment> Search(string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                _Search.SearchKey = searchKey;
                return AddUpdateIfSuccess(_Search.Execute());
            }
            else
            {
                return new EnumerableProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public async Task<IEnumerableProcessResult<IDepartment>> SearchAsync(string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                _Search.SearchKey = searchKey;
                return AddUpdateIfSuccess(await _Search.ExecuteAsync());
            }
            else
            {
                return new EnumerableProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public async Task<IEnumerableProcessResult<IDepartment>> SearchAsync(string searchKey, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                _Search.SearchKey = searchKey;
                return AddUpdateIfSuccess(await _Search.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new EnumerableProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public IEnumerableProcessResult<IDepartment> GetListWithTimeLog(ValueRange<DateTime> cutOff)
        {
            _GetListWithTimeLog.CutOff = cutOff;
            return AddUpdateIfSuccess(_GetListWithTimeLog.Execute());
        }

        public async Task<IEnumerableProcessResult<IDepartment>> GetListWithTimeLogAsync(ValueRange<DateTime> cutOff)
        {
            _GetListWithTimeLog.CutOff = cutOff;
            return AddUpdateIfSuccess(await _GetListWithTimeLog.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<IDepartment>> GetListWithTimeLogAsync(ValueRange<DateTime> cutOff, CancellationToken cancellationToken)
        {
            _GetListWithTimeLog.CutOff = cutOff;
            return AddUpdateIfSuccess(await _GetListWithTimeLog.ExecuteAsync(cancellationToken));
        }
    }
}
