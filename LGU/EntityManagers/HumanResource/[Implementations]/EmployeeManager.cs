using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class EmployeeManager : ManagerBase<Employee, long>, IEmployeeManager
    {
        private readonly IDeleteEmployee r_DeleteEmployee;
        private readonly IGetEmployeeById r_GetEmployeeById;
        private readonly IGetEmployeeList r_GetEmployeeList;
        private readonly IInsertEmployee r_InsertEmployee;
        private readonly IUpdateEmployee r_UpdateEmployee;
        private readonly ISearchEmployee r_SearchEmployee;

        public EmployeeManager(
            IDeleteEmployee deleteEmployee,
            IGetEmployeeById getEmployeeById,
            IGetEmployeeList getEmployeeList,
            IInsertEmployee insertEmployee,
            IUpdateEmployee updateEmployee,
            ISearchEmployee searchEmployee)
        {
            r_DeleteEmployee = deleteEmployee;
            r_GetEmployeeById = getEmployeeById;
            r_GetEmployeeList = getEmployeeList;
            r_InsertEmployee = insertEmployee;
            r_UpdateEmployee = updateEmployee;
            r_SearchEmployee = searchEmployee;
        }

        public IProcessResult<Employee> Delete(Employee data)
        {
            if (data != null)
            {
                r_DeleteEmployee.Employee = data;
                var result = r_DeleteEmployee.Execute();
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IProcessResult<Employee>> DeleteAsync(Employee data)
        {
            if (data != null)
            {
                r_DeleteEmployee.Employee = data;
                var result = await r_DeleteEmployee.ExecuteAsync();
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IProcessResult<Employee>> DeleteAsync(Employee data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_DeleteEmployee.Employee = data;
                var result = await r_DeleteEmployee.ExecuteAsync(cancellationToken);
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public IProcessResult<Employee> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Employee>(StaticSource[id]);
                }

                r_GetEmployeeById.EmployeeId = id;
                var result = r_GetEmployeeById.Execute();
                AddUpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee identifier.");
            }
        }

        public async Task<IProcessResult<Employee>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Employee>(StaticSource[id]);
                }
                else
                {
                    r_GetEmployeeById.EmployeeId = id;
                    var result = await r_GetEmployeeById.ExecuteAsync();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee identifier.");
            }
        }

        public async Task<IProcessResult<Employee>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Employee>(StaticSource[id]);
                }
                else
                {
                    r_GetEmployeeById.EmployeeId = id;
                    var result = await r_GetEmployeeById.ExecuteAsync(cancellationToken);
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee identifier.");
            }
        }

        public IEnumerableProcessResult<Employee> GetList()
        {
            var result = r_GetEmployeeList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<Employee>> GetListAsync()
        {
            var result = await r_GetEmployeeList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<Employee>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetEmployeeList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }

        public IProcessResult<Employee> Insert(Employee data)
        {
            if (data != null)
            {
                r_InsertEmployee.Employee = data;
                var result = r_InsertEmployee.Execute();
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IProcessResult<Employee>> InsertAsync(Employee data)
        {
            if (data != null)
            {
                r_InsertEmployee.Employee = data;
                var result = await r_InsertEmployee.ExecuteAsync();
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IProcessResult<Employee>> InsertAsync(Employee data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_InsertEmployee.Employee = data;
                var result = await r_InsertEmployee.ExecuteAsync(cancellationToken);
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public IProcessResult<Employee> Update(Employee data)
        {
            if (data != null)
            {
                r_UpdateEmployee.Employee = data;
                var result = r_UpdateEmployee.Execute();
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IProcessResult<Employee>> UpdateAsync(Employee data)
        {
            if (data != null)
            {
                r_UpdateEmployee.Employee = data;
                var result = await r_UpdateEmployee.ExecuteAsync();
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IProcessResult<Employee>> UpdateAsync(Employee data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_UpdateEmployee.Employee = data;
                var result = await r_UpdateEmployee.ExecuteAsync(cancellationToken);
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public IEnumerableProcessResult<Employee> Search(string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                r_SearchEmployee.SearchKey = searchKey;
                var result = r_SearchEmployee.Execute();
                AddUpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new EnumerableProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public async Task<IEnumerableProcessResult<Employee>> SearchAsync(string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                r_SearchEmployee.SearchKey = searchKey;
                var result = await r_SearchEmployee.ExecuteAsync();
                AddUpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new EnumerableProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public async Task<IEnumerableProcessResult<Employee>> SearchAsync(string searchKey, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                r_SearchEmployee.SearchKey = searchKey;
                var result = await r_SearchEmployee.ExecuteAsync(cancellationToken);
                AddUpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new EnumerableProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }
    }
}
