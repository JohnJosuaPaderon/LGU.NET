using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System;
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
        private readonly IGetUpdatedEmployeeFingerPrintSetList r_GetUpdatedEmployeeFingerPrintSetList;

        public EmployeeFingerPrintSetManager(
            IDeleteEmployeeFingerPrintSet deleteEmployeeFingerPrintSet,
            IGetEmployeeFingerPrintSetList getEmployeeFingerPrintSetList,
            IInsertEmployeeFingerPrintSet insertEmployeeFingerPrintSet,
            IUpdateEmployeeFingerPrintSet updateEmployeeFingerPrintSet,
            IGetEmployeeFingerPrintSetById getEmployeeFingerPrintSetById,
            IGetUpdatedEmployeeFingerPrintSetList getUpdatedEmployeeFingerPrintSetList)
        {
            r_DeleteEmployeeFingerPrintSet = deleteEmployeeFingerPrintSet;
            r_GetEmployeeFingerPrintSetList = getEmployeeFingerPrintSetList;
            r_InsertEmployeeFingerPrintSetList = insertEmployeeFingerPrintSet;
            r_UpdateEmployeeFingerPrintSet = updateEmployeeFingerPrintSet;
            r_GetEmployeeFingerPrintSetById = getEmployeeFingerPrintSetById;
            r_GetUpdatedEmployeeFingerPrintSetList = getUpdatedEmployeeFingerPrintSetList;
        }

        public IProcessResult<IEmployeeFingerPrintSet> Delete(IEmployeeFingerPrintSet data)
        {
            if (data != null)
            {
                r_DeleteEmployeeFingerPrintSet.FingerPrintSet = data;
                return r_DeleteEmployeeFingerPrintSet.Execute();
            }
            else
            {
                return new ProcessResult<IEmployeeFingerPrintSet>(ProcessResultStatus.Failed, "Invalid finger print set.");
            }
        }

        public async Task<IProcessResult<IEmployeeFingerPrintSet>> DeleteAsync(IEmployeeFingerPrintSet data)
        {
            if (data != null)
            {
                r_DeleteEmployeeFingerPrintSet.FingerPrintSet = data;
                return await r_DeleteEmployeeFingerPrintSet.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<IEmployeeFingerPrintSet>(ProcessResultStatus.Failed, "Invalid finger print set.");
            }
        }

        public async Task<IProcessResult<IEmployeeFingerPrintSet>> DeleteAsync(IEmployeeFingerPrintSet data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_DeleteEmployeeFingerPrintSet.FingerPrintSet = data;
                return await r_DeleteEmployeeFingerPrintSet.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<IEmployeeFingerPrintSet>(ProcessResultStatus.Failed, "Invalid finger print set.");
            }
        }

        public IProcessResult<IEmployeeFingerPrintSet> GetById(IEmployee employee)
        {
            if (employee != null)
            {
                r_GetEmployeeFingerPrintSetById.Employee = employee;
                return r_GetEmployeeFingerPrintSetById.Execute();
            }
            else
            {
                return new ProcessResult<IEmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IProcessResult<IEmployeeFingerPrintSet>> GetByIdAsync(IEmployee employee)
        {
            if (employee != null)
            {
                r_GetEmployeeFingerPrintSetById.Employee = employee;
                return await r_GetEmployeeFingerPrintSetById.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<IEmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IProcessResult<IEmployeeFingerPrintSet>> GetByIdAsync(IEmployee employee, CancellationToken cancellationToken)
        {
            if (employee != null)
            {
                r_GetEmployeeFingerPrintSetById.Employee = employee;
                return await r_GetEmployeeFingerPrintSetById.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<IEmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public IEnumerableProcessResult<IEmployeeFingerPrintSet> GetList()
        {
            return r_GetEmployeeFingerPrintSetList.Execute();
        }

        public Task<IEnumerableProcessResult<IEmployeeFingerPrintSet>> GetListAsync()
        {
            return r_GetEmployeeFingerPrintSetList.ExecuteAsync();
        }

        public Task<IEnumerableProcessResult<IEmployeeFingerPrintSet>> GetListAsync(CancellationToken cancellationToken)
        {
            return r_GetEmployeeFingerPrintSetList.ExecuteAsync(cancellationToken);
        }

        public IEnumerableProcessResult<IEmployeeFingerPrintSet> GetUpdatedList(DateTime logDate)
        {
            r_GetUpdatedEmployeeFingerPrintSetList.LogDate = logDate;
            return r_GetUpdatedEmployeeFingerPrintSetList.Execute();
        }

        public Task<IEnumerableProcessResult<IEmployeeFingerPrintSet>> GetUpdatedListAsync(DateTime logDate)
        {
            r_GetUpdatedEmployeeFingerPrintSetList.LogDate = logDate;
            return r_GetUpdatedEmployeeFingerPrintSetList.ExecuteAsync();
        }

        public Task<IEnumerableProcessResult<IEmployeeFingerPrintSet>> GetUpdatedListAsync(DateTime logDate, CancellationToken cancellationToken)
        {
            r_GetUpdatedEmployeeFingerPrintSetList.LogDate = logDate;
            return r_GetUpdatedEmployeeFingerPrintSetList.ExecuteAsync(cancellationToken);
        }

        public IProcessResult<IEmployeeFingerPrintSet> Insert(IEmployeeFingerPrintSet data)
        {
            if (data != null)
            {
                r_InsertEmployeeFingerPrintSetList.FingerPrintSet = data;
                return r_InsertEmployeeFingerPrintSetList.Execute();
            }
            else
            {
                return new ProcessResult<IEmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IProcessResult<IEmployeeFingerPrintSet>> InsertAsync(IEmployeeFingerPrintSet data)
        {
            if (data != null)
            {
                r_InsertEmployeeFingerPrintSetList.FingerPrintSet = data;
                return await r_InsertEmployeeFingerPrintSetList.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<IEmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IProcessResult<IEmployeeFingerPrintSet>> InsertAsync(IEmployeeFingerPrintSet data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_InsertEmployeeFingerPrintSetList.FingerPrintSet = data;
                return await r_InsertEmployeeFingerPrintSetList.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<IEmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public IProcessResult<IEmployeeFingerPrintSet> Update(IEmployeeFingerPrintSet data)
        {
            if (data != null)
            {
                r_UpdateEmployeeFingerPrintSet.FingerPrintSet = data;
                return r_UpdateEmployeeFingerPrintSet.Execute();
            }
            else
            {
                return new ProcessResult<IEmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IProcessResult<IEmployeeFingerPrintSet>> UpdateAsync(IEmployeeFingerPrintSet data)
        {
            if (data != null)
            {
                r_UpdateEmployeeFingerPrintSet.FingerPrintSet = data;
                return await r_UpdateEmployeeFingerPrintSet.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<IEmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IProcessResult<IEmployeeFingerPrintSet>> UpdateAsync(IEmployeeFingerPrintSet data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_UpdateEmployeeFingerPrintSet.FingerPrintSet = data;
                return await r_UpdateEmployeeFingerPrintSet.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<IEmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }
    }
}
