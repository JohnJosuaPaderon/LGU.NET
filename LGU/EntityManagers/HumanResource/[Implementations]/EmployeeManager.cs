using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class EmployeeManager : EntityManagerBase<IEmployee, long>, IEmployeeManager
    {
        private const string MESSAGE_INVALID = "Invalid employee.";
        private const string MESSAGE_INVALID_IDENTIFIER = "Invalid employee identifier.";
        private const string MESSAGE_INVALID_SEARCH_KEY = "Invalid search key.";
        private const string MESSAGE_INVALID_DEPARTMENT = "Invalid department.";
        private const string MESSAGE_INVALID_PAYROLL_TYPE = "Invalid payroll type.";

        public EmployeeManager(
            IDeleteEmployee delete,
            IGetEmployeeById getById,
            IGetEmployeeList getList,
            IInsertEmployee insert,
            IUpdateEmployee update,
            ISearchEmployee search,
            IGetEmployeeListWithTimeLog getListWithTimeLog,
            ISearchEmployeeWithTimeLog searchWithTimeLog,
            IGetEmployeeListWithTimeLogByDepartment getListWithTimeLogByDepartment,
            IGetEmployeeListByPayrollType getEmployeeListByPayrollType)
        {
            _Delete = delete;
            _GetById = getById;
            _GetList = getList;
            _Insert = insert;
            _Update = update;
            _Search = search;
            _GetListWithTimeLog = getListWithTimeLog;
            _SearchWithTimeLog = searchWithTimeLog;
            _GetListWithTimeLogByDepartment = getListWithTimeLogByDepartment;
            _GetListByPayrollType = getEmployeeListByPayrollType;

            _InvalidResult = new ProcessResult<IEmployee>(ProcessResultStatus.Failed, MESSAGE_INVALID);
            _InvalidIdentifierResult = new ProcessResult<IEmployee>(ProcessResultStatus.Failed, MESSAGE_INVALID_IDENTIFIER);
            _InvalidSearchKeyResult = new EnumerableProcessResult<IEmployee>(ProcessResultStatus.Failed, MESSAGE_INVALID_SEARCH_KEY);
            _InvalidDepartmentResult = new EnumerableProcessResult<IEmployee>(ProcessResultStatus.Failed, MESSAGE_INVALID_DEPARTMENT);
            _InvalidPayrollTypeResult = new EnumerableProcessResult<IEmployee>(ProcessResultStatus.Failed, MESSAGE_INVALID_PAYROLL_TYPE);
        }

        private readonly IDeleteEmployee _Delete;
        private readonly IGetEmployeeById _GetById;
        private readonly IGetEmployeeList _GetList;
        private readonly IInsertEmployee _Insert;
        private readonly IUpdateEmployee _Update;
        private readonly ISearchEmployee _Search;
        private readonly IGetEmployeeListWithTimeLog _GetListWithTimeLog;
        private readonly ISearchEmployeeWithTimeLog _SearchWithTimeLog;
        private readonly IGetEmployeeListWithTimeLogByDepartment _GetListWithTimeLogByDepartment;
        private readonly IGetEmployeeListByPayrollType _GetListByPayrollType;
        private readonly IProcessResult<IEmployee> _InvalidResult;
        private readonly IProcessResult<IEmployee> _InvalidIdentifierResult;
        private readonly IEnumerableProcessResult<IEmployee> _InvalidSearchKeyResult;
        private readonly IEnumerableProcessResult<IEmployee> _InvalidDepartmentResult;
        private readonly IEnumerableProcessResult<IEmployee> _InvalidPayrollTypeResult;

        public IProcessResult<IEmployee> Delete(IEmployee data)
        {
            if (data != null)
            {
                _Delete.Employee = data;
                return RemoveIfSuccess(_Delete.Execute());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IEmployee>> DeleteAsync(IEmployee data)
        {
            if (data != null)
            {
                _Delete.Employee = data;
                return RemoveIfSuccess(await _Delete.ExecuteAsync());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IEmployee>> DeleteAsync(IEmployee data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                _Delete.Employee = data;
                return RemoveIfSuccess(await _Delete.ExecuteAsync(cancellationToken));
            }
            else
            {
                return _InvalidResult;
            }
        }

        public IProcessResult<IEmployee> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IEmployee>(StaticSource[id]);
                }
                else
                {
                    _GetById.EmployeeId = id;
                    return AddUpdateIfSuccess(_GetById.Execute());
                }
            }
            else
            {
                return _InvalidIdentifierResult;
            }
        }

        public async Task<IProcessResult<IEmployee>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IEmployee>(StaticSource[id]);
                }
                else
                {
                    _GetById.EmployeeId = id;
                    return AddUpdateIfSuccess(await _GetById.ExecuteAsync());
                }
            }
            else
            {
                return _InvalidIdentifierResult;
            }
        }

        public async Task<IProcessResult<IEmployee>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IEmployee>(StaticSource[id]);
                }
                else
                {
                    _GetById.EmployeeId = id;
                    return AddUpdateIfSuccess(await _GetById.ExecuteAsync());
                }
            }
            else
            {
                return _InvalidIdentifierResult;
            }
        }

        public IEnumerableProcessResult<IEmployee> GetList()
        {
            return AddUpdateIfSuccess(_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<IEmployee>> GetListAsync()
        {
            return AddUpdateIfSuccess(await _GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<IEmployee>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await _GetList.ExecuteAsync(cancellationToken));
        }

        public IProcessResult<IEmployee> Insert(IEmployee data)
        {
            if (data != null)
            {
                _Insert.Employee = data;
                return AddIfSuccess(_Insert.Execute());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IEmployee>> InsertAsync(IEmployee data)
        {
            if (data != null)
            {
                _Insert.Employee = data;
                return AddIfSuccess(await _Insert.ExecuteAsync());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IEmployee>> InsertAsync(IEmployee data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                _Insert.Employee = data;
                return AddIfSuccess(await _Insert.ExecuteAsync());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public IProcessResult<IEmployee> Update(IEmployee data)
        {
            if (data != null)
            {
                _Update.Employee = data;
                return UpdateIfSuccess(_Update.Execute());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IEmployee>> UpdateAsync(IEmployee data)
        {
            if (data != null)
            {
                _Update.Employee = data;
                return UpdateIfSuccess(await _Update.ExecuteAsync());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IEmployee>> UpdateAsync(IEmployee data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                _Update.Employee = data;
                return UpdateIfSuccess(await _Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return _InvalidResult;
            }
        }

        public IEnumerableProcessResult<IEmployee> Search(string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                _Search.SearchKey = searchKey;
                return AddUpdateIfSuccess(_Search.Execute());
            }
            else
            {
                return _InvalidSearchKeyResult;
            }
        }

        public async Task<IEnumerableProcessResult<IEmployee>> SearchAsync(string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                _Search.SearchKey = searchKey;
                return AddUpdateIfSuccess(await _Search.ExecuteAsync());
            }
            else
            {
                return _InvalidSearchKeyResult;
            }
        }

        public async Task<IEnumerableProcessResult<IEmployee>> SearchAsync(string searchKey, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                _Search.SearchKey = searchKey;
                return AddUpdateIfSuccess(await _Search.ExecuteAsync(cancellationToken));
            }
            else
            {
                return _InvalidSearchKeyResult;
            }
        }

        public IEnumerableProcessResult<IEmployee> GetListWithTimeLog(ValueRange<DateTime> cutOff)
        {
            _GetListWithTimeLog.CutOff = cutOff;
            return AddUpdateIfSuccess(_GetListWithTimeLog.Execute());
        }

        public async Task<IEnumerableProcessResult<IEmployee>> GetListWithTimeLogAsync(ValueRange<DateTime> cutOff)
        {
            _GetListWithTimeLog.CutOff = cutOff;
            return AddUpdateIfSuccess(await _GetListWithTimeLog.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<IEmployee>> GetListWithTimeLogAsync(ValueRange<DateTime> cutOff, CancellationToken cancellationToken)
        {
            _GetListWithTimeLog.CutOff = cutOff;
            return AddUpdateIfSuccess(await _GetListWithTimeLog.ExecuteAsync(cancellationToken));
        }

        public IEnumerableProcessResult<IEmployee> SearchWithTimeLog(string searchKey, ValueRange<DateTime> cutOff)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                _SearchWithTimeLog.SearchKey = searchKey;
                _SearchWithTimeLog.CutOff = cutOff;
                return AddUpdateIfSuccess(_SearchWithTimeLog.Execute());
            }
            else
            {
                return _InvalidSearchKeyResult;
            }
        }

        public async Task<IEnumerableProcessResult<IEmployee>> SearchWithTimeLogAsync(string searchKey, ValueRange<DateTime> cutOff)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                _SearchWithTimeLog.SearchKey = searchKey;
                _SearchWithTimeLog.CutOff = cutOff;
                return AddUpdateIfSuccess(await _SearchWithTimeLog.ExecuteAsync());
            }
            else
            {
                return _InvalidSearchKeyResult;
            }
        }

        public async Task<IEnumerableProcessResult<IEmployee>> SearchWithTimeLogAsync(string searchKey, ValueRange<DateTime> cutOff, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                _SearchWithTimeLog.SearchKey = searchKey;
                _SearchWithTimeLog.CutOff = cutOff;
                return AddUpdateIfSuccess(await _SearchWithTimeLog.ExecuteAsync(cancellationToken));
            }
            else
            {
                return _InvalidSearchKeyResult;
            }
        }

        public IEnumerableProcessResult<IEmployee> GetListWithTimeLogByDepartment(ValueRange<DateTime> cutOff, IDepartment department)
        {
            if (department != null)
            {
                _GetListWithTimeLogByDepartment.CutOff = cutOff;
                _GetListWithTimeLogByDepartment.Department = department;
                return AddUpdateIfSuccess(_GetListWithTimeLogByDepartment.Execute());
            }
            else
            {
                return _InvalidDepartmentResult;
            }
        }

        public async Task<IEnumerableProcessResult<IEmployee>> GetListWithTimeLogByDepartmentAsync(ValueRange<DateTime> cutOff, IDepartment department)
        {
            if (department != null)
            {
                _GetListWithTimeLogByDepartment.CutOff = cutOff;
                _GetListWithTimeLogByDepartment.Department = department;
                return AddUpdateIfSuccess(await _GetListWithTimeLogByDepartment.ExecuteAsync());
            }
            else
            {
                return _InvalidDepartmentResult;
            }
        }

        public async Task<IEnumerableProcessResult<IEmployee>> GetListWithTimeLogByDepartmentAsync(ValueRange<DateTime> cutOff, IDepartment department, CancellationToken cancellationToken)
        {
            if (department != null)
            {
                _GetListWithTimeLogByDepartment.CutOff = cutOff;
                _GetListWithTimeLogByDepartment.Department = department;
                return AddUpdateIfSuccess(await _GetListWithTimeLogByDepartment.ExecuteAsync(cancellationToken));
            }
            else
            {
                return _InvalidDepartmentResult;
            }
        }

        public IEnumerableProcessResult<IEmployee> GetListByPayrollType(IPayrollType payrollType)
        {
            if (payrollType != null)
            {
                _GetListByPayrollType.PayrollType = payrollType;
                return AddUpdateIfSuccess(_GetListByPayrollType.Execute());
            }
            else
            {
                return _InvalidPayrollTypeResult;
            }
        }

        public async Task<IEnumerableProcessResult<IEmployee>> GetListByPayrollTypeAsync(IPayrollType payrollType)
        {
            if (payrollType != null)
            {
                _GetListByPayrollType.PayrollType = payrollType;
                return AddUpdateIfSuccess(await _GetListByPayrollType.ExecuteAsync());
            }
            else
            {
                return _InvalidPayrollTypeResult;
            }
        }

        public async Task<IEnumerableProcessResult<IEmployee>> GetListByPayrollTypeAsync(IPayrollType payrollType, CancellationToken cancellationToken)
        {
            if (payrollType != null)
            {
                _GetListByPayrollType.PayrollType = payrollType;
                return AddUpdateIfSuccess(await _GetListByPayrollType.ExecuteAsync(cancellationToken));
            }
            else
            {
                return _InvalidPayrollTypeResult;
            }
        }
    }
}
