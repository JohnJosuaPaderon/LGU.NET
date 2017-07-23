using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class EmployeeFingerPrintSetManager : IEmployeeFingerPrintSetManager
    {
        private readonly IDeleteEmployeeFingerPrintSet r_DeleteEmployeeFingerPrintSet;
        private readonly IGetEmployeeFingerPrintSetList r_GetEmployeeFingerPrintSetList;
        private readonly IInsertEmployeeFingerPrintSet r_InsertEmployeeFingerPrintSetList;
        private readonly IUpdateEmployeeFingerPrintSet r_UpdateEmployeeFingerPrintSet;
        private readonly IGetEmployeeFingerPrintSetById r_GetEmployeeFingerPrintSetById;

        public EmployeeFingerPrintSetManager(
            IDeleteEmployeeFingerPrintSet deleteEmployeeFingerPrintSet,
            IGetEmployeeFingerPrintSetList getEmployeeFingerPrintSetList,
            IInsertEmployeeFingerPrintSet insertEmployeeFingerPrintSet,
            IUpdateEmployeeFingerPrintSet updateEmployeeFingerPrintSet,
            IGetEmployeeFingerPrintSetById getEmployeeFingerPrintSetById)
        {
            r_DeleteEmployeeFingerPrintSet = deleteEmployeeFingerPrintSet;
            r_GetEmployeeFingerPrintSetList = getEmployeeFingerPrintSetList;
            r_InsertEmployeeFingerPrintSetList = insertEmployeeFingerPrintSet;
            r_UpdateEmployeeFingerPrintSet = updateEmployeeFingerPrintSet;
            r_GetEmployeeFingerPrintSetById = getEmployeeFingerPrintSetById;
        }

        public IProcessResult<EmployeeFingerPrintSet> Delete(EmployeeFingerPrintSet data)
        {
            if (data != null)
            {
                r_DeleteEmployeeFingerPrintSet.FingerPrintSet = data;
                return r_DeleteEmployeeFingerPrintSet.Execute();
            }
            else
            {
                return new ProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed, "Invalid finger print set.");
            }
        }

        public async Task<IProcessResult<EmployeeFingerPrintSet>> DeleteAsync(EmployeeFingerPrintSet data)
        {
            if (data != null)
            {
                r_DeleteEmployeeFingerPrintSet.FingerPrintSet = data;
                return await r_DeleteEmployeeFingerPrintSet.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed, "Invalid finger print set.");
            }
        }

        public async Task<IProcessResult<EmployeeFingerPrintSet>> DeleteAsync(EmployeeFingerPrintSet data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_DeleteEmployeeFingerPrintSet.FingerPrintSet = data;
                return await r_DeleteEmployeeFingerPrintSet.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed, "Invalid finger print set.");
            }
        }

        public IProcessResult<EmployeeFingerPrintSet> GetById(Employee employee)
        {
            if (employee != null)
            {
                r_GetEmployeeFingerPrintSetById.Employee = employee;
                return r_GetEmployeeFingerPrintSetById.Execute();
            }
            else
            {
                return new ProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IProcessResult<EmployeeFingerPrintSet>> GetByIdAsync(Employee employee)
        {
            if (employee != null)
            {
                r_GetEmployeeFingerPrintSetById.Employee = employee;
                return await r_GetEmployeeFingerPrintSetById.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IProcessResult<EmployeeFingerPrintSet>> GetByIdAsync(Employee employee, CancellationToken cancellationToken)
        {
            if (employee != null)
            {
                r_GetEmployeeFingerPrintSetById.Employee = employee;
                return await r_GetEmployeeFingerPrintSetById.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public IEnumerableProcessResult<EmployeeFingerPrintSet> GetList()
        {
            return r_GetEmployeeFingerPrintSetList.Execute();
        }

        public Task<IEnumerableProcessResult<EmployeeFingerPrintSet>> GetListAsync()
        {
            return r_GetEmployeeFingerPrintSetList.ExecuteAsync();
        }

        public Task<IEnumerableProcessResult<EmployeeFingerPrintSet>> GetListAsync(CancellationToken cancellationToken)
        {
            return r_GetEmployeeFingerPrintSetList.ExecuteAsync(cancellationToken);
        }

        public IProcessResult<EmployeeFingerPrintSet> Insert(EmployeeFingerPrintSet data)
        {
            if (data != null)
            {
                r_InsertEmployeeFingerPrintSetList.FingerPrintSet = data;
                return r_InsertEmployeeFingerPrintSetList.Execute();
            }
            else
            {
                return new ProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IProcessResult<EmployeeFingerPrintSet>> InsertAsync(EmployeeFingerPrintSet data)
        {
            if (data != null)
            {
                r_InsertEmployeeFingerPrintSetList.FingerPrintSet = data;
                return await r_InsertEmployeeFingerPrintSetList.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IProcessResult<EmployeeFingerPrintSet>> InsertAsync(EmployeeFingerPrintSet data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_InsertEmployeeFingerPrintSetList.FingerPrintSet = data;
                return await r_InsertEmployeeFingerPrintSetList.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public IProcessResult<EmployeeFingerPrintSet> Update(EmployeeFingerPrintSet data)
        {
            if (data != null)
            {
                r_UpdateEmployeeFingerPrintSet.FingerPrintSet = data;
                return r_UpdateEmployeeFingerPrintSet.Execute();
            }
            else
            {
                return new ProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IProcessResult<EmployeeFingerPrintSet>> UpdateAsync(EmployeeFingerPrintSet data)
        {
            if (data != null)
            {
                r_UpdateEmployeeFingerPrintSet.FingerPrintSet = data;
                return await r_UpdateEmployeeFingerPrintSet.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IProcessResult<EmployeeFingerPrintSet>> UpdateAsync(EmployeeFingerPrintSet data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_UpdateEmployeeFingerPrintSet.FingerPrintSet = data;
                return await r_UpdateEmployeeFingerPrintSet.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }
    }
}
