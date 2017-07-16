using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class TimeLogManager : ManagerBase, ITimeLogManager
    {
        private readonly IDeleteTimeLog DeleteProc;
        private readonly IGetTimeLogById GetByIdProc;
        private readonly IGetTimeLogList GetListProc;
        private readonly IInsertTimeLog InsertProc;
        private readonly ILogEmployee LogEmployeeProc;
        private readonly IUpdateTimeLog UpdateProc;

        public TimeLogManager(
            IDeleteTimeLog deleteProc,
            IGetTimeLogById getByIdProc,
            IGetTimeLogList getListProc,
            IInsertTimeLog insertProc,
            ILogEmployee logEmployeeProc,
            IUpdateTimeLog updateProc)
        {
            DeleteProc = deleteProc;
            GetByIdProc = getByIdProc;
            GetListProc = getListProc;
            InsertProc = insertProc;
            LogEmployeeProc = logEmployeeProc;
            UpdateProc = updateProc;
        }

        public IDataProcessResult<TimeLog> Delete(TimeLog data)
        {
            if (data != null)
            {
                DeleteProc.TimeLog = data;
                return DeleteProc.Execute();
            }
            else
            {
                return new DataProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log.");
            }
        }

        public async Task<IDataProcessResult<TimeLog>> DeleteAsync(TimeLog data)
        {
            if (data != null)
            {
                DeleteProc.TimeLog = data;
                return await DeleteProc.ExecuteAsync();
            }
            else
            {
                return new DataProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log.");
            }
        }

        public async Task<IDataProcessResult<TimeLog>> DeleteAsync(TimeLog data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                DeleteProc.TimeLog = data;
                return await DeleteProc.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new DataProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log.");
            }
        }

        public IDataProcessResult<TimeLog> GetById(long id)
        {
            if (id > 0)
            {
                GetByIdProc.TimeLogId = id;
                return GetByIdProc.Execute();
            }
            else
            {
                return new DataProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log identifier.");
            }
        }

        public async Task<IDataProcessResult<TimeLog>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                GetByIdProc.TimeLogId = id;
                return await GetByIdProc.ExecuteAsync();
            }
            else
            {
                return new DataProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log identifier.");
            }
        }

        public async Task<IDataProcessResult<TimeLog>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                GetByIdProc.TimeLogId = id;
                return await GetByIdProc.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new DataProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log identifier.");
            }
        }

        public IEnumerableDataProcessResult<TimeLog> GetList()
        {
            return GetListProc.Execute();
        }

        public Task<IEnumerableDataProcessResult<TimeLog>> GetListAsync()
        {
            return GetListProc.ExecuteAsync();
        }

        public Task<IEnumerableDataProcessResult<TimeLog>> GetListAsync(CancellationToken cancellationToken)
        {
            return GetListProc.ExecuteAsync(cancellationToken);
        }

        public IDataProcessResult<TimeLog> Insert(TimeLog data)
        {
            if (data != null)
            {
                InsertProc.TimeLog = data;
                return InsertProc.Execute();
            }
            else
            {
                return new DataProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log.");
            }
        }

        public async Task<IDataProcessResult<TimeLog>> InsertAsync(TimeLog data)
        {
            if (data != null)
            {
                InsertProc.TimeLog = data;
                return await InsertProc.ExecuteAsync();
            }
            else
            {
                return new DataProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log.");
            }
        }

        public async Task<IDataProcessResult<TimeLog>> InsertAsync(TimeLog data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                InsertProc.TimeLog = data;
                return await InsertProc.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new DataProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log.");
            }
        }

        public IDataProcessResult<TimeLog> Log(Employee employee)
        {
            if (employee != null)
            {
                LogEmployeeProc.Employee = employee;
                return LogEmployeeProc.Execute();
            }
            else
            {
                return new DataProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IDataProcessResult<TimeLog>> LogAsync(Employee employee)
        {
            if (employee != null)
            {
                LogEmployeeProc.Employee = employee;
                return await LogEmployeeProc.ExecuteAsync();
            }
            else
            {
                return new DataProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IDataProcessResult<TimeLog>> LogAsync(Employee employee, CancellationToken cancellationToken)
        {
            if (employee != null)
            {
                LogEmployeeProc.Employee = employee;
                return await LogEmployeeProc.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new DataProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public IDataProcessResult<TimeLog> Update(TimeLog data)
        {
            if (data != null)
            {
                UpdateProc.TimeLog = data;
                return UpdateProc.Execute();
            }
            else
            {
                return new DataProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log.");
            }
        }

        public async Task<IDataProcessResult<TimeLog>> UpdateAsync(TimeLog data)
        {
            if (data != null)
            {
                UpdateProc.TimeLog = data;
                return await UpdateProc.ExecuteAsync();
            }
            else
            {
                return new DataProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log.");
            }
        }

        public async Task<IDataProcessResult<TimeLog>> UpdateAsync(TimeLog data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                UpdateProc.TimeLog = data;
                return await UpdateProc.ExecuteAsync();
            }
            else
            {
                return new DataProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log.");
            }
        }
    }
}
