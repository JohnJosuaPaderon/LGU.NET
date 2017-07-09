using LGU.Entities;
using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class EmployeeManager : IEmployeeManager
    {
        private readonly IDeleteEmployee DeleteEmployee;
        private readonly IGetEmployeeById GetEmployeeById;
        private readonly IGetEmployeeList GetEmployeeList;
        private readonly IInsertEmployee InsertEmployee;
        private readonly IUpdateEmployee UpdateEmployee;

        private static EntityCollection<Employee, long> StaticSource { get; } = new EntityCollection<Employee, long>();

        public EmployeeManager(
            IDeleteEmployee deleteEmployee,
            IGetEmployeeById getEmployeeById,
            IGetEmployeeList getEmployeeList,
            IInsertEmployee insertEmployee,
            IUpdateEmployee updateEmployee)
        {
            DeleteEmployee = deleteEmployee;
            GetEmployeeById = getEmployeeById;
            GetEmployeeList = getEmployeeList;
            InsertEmployee = insertEmployee;
            UpdateEmployee = updateEmployee;
        }

        public IDataProcessResult<Employee> Delete(Employee data)
        {
            if (data != null)
            {
                DeleteEmployee.Employee = data;
                var result = DeleteEmployee.Execute();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Remove(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IDataProcessResult<Employee>> DeleteAsync(Employee data)
        {
            if (data != null)
            {
                DeleteEmployee.Employee = data;
                var result = await DeleteEmployee.ExecuteAsync();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Remove(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IDataProcessResult<Employee>> DeleteAsync(Employee data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                DeleteEmployee.Employee = data;
                var result = await DeleteEmployee.ExecuteAsync(cancellationToken);

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Remove(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public IDataProcessResult<Employee> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new DataProcessResult<Employee>(StaticSource[id]);
                }

                GetEmployeeById.EmployeeId = id;
                var result = GetEmployeeById.Execute();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.AddUpdate(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee identifier.");
            }
        }

        public async Task<IDataProcessResult<Employee>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new DataProcessResult<Employee>(StaticSource[id]);
                }
                else
                {
                    GetEmployeeById.EmployeeId = id;
                    var result = await GetEmployeeById.ExecuteAsync();

                    if (result.Status == ProcessResultStatus.Success)
                    {
                        StaticSource.AddUpdate(result.Data);
                    }

                    return result;
                }
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee identifier.");
            }
        }

        public async Task<IDataProcessResult<Employee>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new DataProcessResult<Employee>(StaticSource[id]);
                }
                else
                {
                    GetEmployeeById.EmployeeId = id;
                    var result = await GetEmployeeById.ExecuteAsync(cancellationToken);

                    if (result.Status == ProcessResultStatus.Success)
                    {
                        StaticSource.AddUpdate(result.Data);
                    }

                    return result;
                }
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee identifier.");
            }
        }

        public IEnumerableDataProcessResult<Employee> GetList()
        {
            return GetEmployeeList.Execute();
        }

        public Task<IEnumerableDataProcessResult<Employee>> GetListAsync()
        {
            return GetEmployeeList.ExecuteAsync();
        }

        public Task<IEnumerableDataProcessResult<Employee>> GetListAsync(CancellationToken cancellationToken)
        {
            return GetEmployeeList.ExecuteAsync(cancellationToken);
        }

        public IDataProcessResult<Employee> Insert(Employee data)
        {
            if (data != null)
            {
                InsertEmployee.Employee = data;
                var result = InsertEmployee.Execute();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Add(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IDataProcessResult<Employee>> InsertAsync(Employee data)
        {
            if (data != null)
            {
                InsertEmployee.Employee = data;
                var result = await InsertEmployee.ExecuteAsync();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Add(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IDataProcessResult<Employee>> InsertAsync(Employee data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                InsertEmployee.Employee = data;
                var result = await InsertEmployee.ExecuteAsync(cancellationToken);

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Add(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public IDataProcessResult<Employee> Update(Employee data)
        {
            if (data != null)
            {
                UpdateEmployee.Employee = data;
                var result = UpdateEmployee.Execute();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Update(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IDataProcessResult<Employee>> UpdateAsync(Employee data)
        {
            if (data != null)
            {
                UpdateEmployee.Employee = data;
                var result = await UpdateEmployee.ExecuteAsync();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Update(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IDataProcessResult<Employee>> UpdateAsync(Employee data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                UpdateEmployee.Employee = data;
                var result = await UpdateEmployee.ExecuteAsync(cancellationToken);

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Update(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }
    }
}
