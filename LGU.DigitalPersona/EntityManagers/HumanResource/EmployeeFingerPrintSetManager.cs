using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class EmployeeFingerPrintSetManager : IEmployeeFingerPrintSetManager
    {
        private readonly IDeleteEmployeeFingerPrintSet DeleteProc;
        private readonly IGetEmployeeFingerPrintSetList GetListProc;
        private readonly IInsertEmployeeFingerPrintSet InsertProc;
        private readonly IUpdateEmployeeFingerPrintSet UpdateProc;
        private readonly IGetEmployeeFingerPrintSetById GetByIdProc;

        public EmployeeFingerPrintSetManager(
            IDeleteEmployeeFingerPrintSet deleteProc,
            IGetEmployeeFingerPrintSetList getListProc,
            IInsertEmployeeFingerPrintSet insertProc,
            IUpdateEmployeeFingerPrintSet updateProc,
            IGetEmployeeFingerPrintSetById getByIdProc)
        {
            DeleteProc = deleteProc;
            GetListProc = getListProc;
            InsertProc = insertProc;
            UpdateProc = updateProc;
            GetByIdProc = getByIdProc;
        }

        public IDataProcessResult<EmployeeFingerPrintSet> Delete(EmployeeFingerPrintSet data)
        {
            if (data != null)
            {
                DeleteProc.FingerPrintSet = data;
                return DeleteProc.Execute();
            }
            else
            {
                return new DataProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed, "Invalid finger print set.");
            }
        }

        public async Task<IDataProcessResult<EmployeeFingerPrintSet>> DeleteAsync(EmployeeFingerPrintSet data)
        {
            if (data != null)
            {
                DeleteProc.FingerPrintSet = data;
                return await DeleteProc.ExecuteAsync();
            }
            else
            {
                return new DataProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed, "Invalid finger print set.");
            }
        }

        public async Task<IDataProcessResult<EmployeeFingerPrintSet>> DeleteAsync(EmployeeFingerPrintSet data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                DeleteProc.FingerPrintSet = data;
                return await DeleteProc.ExecuteAsync();
            }
            else
            {
                return new DataProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed, "Invalid finger print set.");
            }
        }

        public IDataProcessResult<EmployeeFingerPrintSet> GetById(Employee employee)
        {
            if (employee != null)
            {
                GetByIdProc.Employee = employee;
                return GetByIdProc.Execute();
            }
            else
            {
                return new DataProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IDataProcessResult<EmployeeFingerPrintSet>> GetByIdAsync(Employee employee)
        {
            if (employee != null)
            {
                GetByIdProc.Employee = employee;
                return await GetByIdProc.ExecuteAsync();
            }
            else
            {
                return new DataProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IDataProcessResult<EmployeeFingerPrintSet>> GetByIdAsync(Employee employee, CancellationToken cancellationToken)
        {
            if (employee != null)
            {
                GetByIdProc.Employee = employee;
                return await GetByIdProc.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new DataProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public IEnumerableDataProcessResult<EmployeeFingerPrintSet> GetList()
        {
            return GetListProc.Execute();
        }

        public Task<IEnumerableDataProcessResult<EmployeeFingerPrintSet>> GetListAsync()
        {
            return GetListProc.ExecuteAsync();
        }

        public Task<IEnumerableDataProcessResult<EmployeeFingerPrintSet>> GetListAsync(CancellationToken cancellationToken)
        {
            return GetListProc.ExecuteAsync(cancellationToken);
        }

        public IDataProcessResult<EmployeeFingerPrintSet> Insert(EmployeeFingerPrintSet data)
        {
            if (data != null)
            {
                InsertProc.FingerPrintSet = data;
                return InsertProc.Execute();
            }
            else
            {
                return new DataProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IDataProcessResult<EmployeeFingerPrintSet>> InsertAsync(EmployeeFingerPrintSet data)
        {
            if (data != null)
            {
                InsertProc.FingerPrintSet = data;
                return await InsertProc.ExecuteAsync();
            }
            else
            {
                return new DataProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IDataProcessResult<EmployeeFingerPrintSet>> InsertAsync(EmployeeFingerPrintSet data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                InsertProc.FingerPrintSet = data;
                return await InsertProc.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new DataProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public IDataProcessResult<EmployeeFingerPrintSet> Update(EmployeeFingerPrintSet data)
        {
            if (data != null)
            {
                UpdateProc.FingerPrintSet = data;
                return UpdateProc.Execute();
            }
            else
            {
                return new DataProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IDataProcessResult<EmployeeFingerPrintSet>> UpdateAsync(EmployeeFingerPrintSet data)
        {
            if (data != null)
            {
                UpdateProc.FingerPrintSet = data;
                return await UpdateProc.ExecuteAsync();
            }
            else
            {
                return new DataProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IDataProcessResult<EmployeeFingerPrintSet>> UpdateAsync(EmployeeFingerPrintSet data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                UpdateProc.FingerPrintSet = data;
                return await UpdateProc.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new DataProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }
    }
}
