using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class TimeLogManager : ManagerBase<TimeLog, long>, ITimeLogManager
    {
        private readonly IDeleteTimeLog r_DeleteTimeLog;
        private readonly IGetTimeLogById r_GetTimeLogById;
        private readonly IGetTimeLogList r_GetTimeLogList;
        private readonly IInsertTimeLog r_InsertTimeLog;
        private readonly ILogEmployee r_LogEmployee;
        private readonly IUpdateTimeLog r_UpdateTimeLog;

        public TimeLogManager(
            IDeleteTimeLog deleteTimeLog,
            IGetTimeLogById getTimeLogById,
            IGetTimeLogList getTimeLogList,
            IInsertTimeLog insertTimeLog,
            ILogEmployee logEmployee,
            IUpdateTimeLog updateTimeLog)
        {
            r_DeleteTimeLog = deleteTimeLog;
            r_GetTimeLogById = getTimeLogById;
            r_GetTimeLogList = getTimeLogList;
            r_InsertTimeLog = insertTimeLog;
            r_LogEmployee = logEmployee;
            r_UpdateTimeLog = updateTimeLog;
        }

        public IProcessResult<TimeLog> Delete(TimeLog data)
        {
            if (data != null)
            {
                r_DeleteTimeLog.TimeLog = data;
                return r_DeleteTimeLog.Execute();
            }
            else
            {
                return new ProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log.");
            }
        }

        public async Task<IProcessResult<TimeLog>> DeleteAsync(TimeLog data)
        {
            if (data != null)
            {
                r_DeleteTimeLog.TimeLog = data;
                return await r_DeleteTimeLog.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log.");
            }
        }

        public async Task<IProcessResult<TimeLog>> DeleteAsync(TimeLog data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_DeleteTimeLog.TimeLog = data;
                return await r_DeleteTimeLog.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log.");
            }
        }

        public IProcessResult<TimeLog> GetById(long id)
        {
            if (id > 0)
            {
                r_GetTimeLogById.TimeLogId = id;
                return r_GetTimeLogById.Execute();
            }
            else
            {
                return new ProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log identifier.");
            }
        }

        public async Task<IProcessResult<TimeLog>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                r_GetTimeLogById.TimeLogId = id;
                return await r_GetTimeLogById.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log identifier.");
            }
        }

        public async Task<IProcessResult<TimeLog>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                r_GetTimeLogById.TimeLogId = id;
                return await r_GetTimeLogById.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log identifier.");
            }
        }

        public IEnumerableProcessResult<TimeLog> GetList()
        {
            return r_GetTimeLogList.Execute();
        }

        public Task<IEnumerableProcessResult<TimeLog>> GetListAsync()
        {
            return r_GetTimeLogList.ExecuteAsync();
        }

        public Task<IEnumerableProcessResult<TimeLog>> GetListAsync(CancellationToken cancellationToken)
        {
            return r_GetTimeLogList.ExecuteAsync(cancellationToken);
        }

        public IProcessResult<TimeLog> Insert(TimeLog data)
        {
            if (data != null)
            {
                r_InsertTimeLog.TimeLog = data;
                return r_InsertTimeLog.Execute();
            }
            else
            {
                return new ProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log.");
            }
        }

        public async Task<IProcessResult<TimeLog>> InsertAsync(TimeLog data)
        {
            if (data != null)
            {
                r_InsertTimeLog.TimeLog = data;
                return await r_InsertTimeLog.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log.");
            }
        }

        public async Task<IProcessResult<TimeLog>> InsertAsync(TimeLog data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_InsertTimeLog.TimeLog = data;
                return await r_InsertTimeLog.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log.");
            }
        }

        public IProcessResult<TimeLog> Log(Employee employee)
        {
            if (employee != null)
            {
                r_LogEmployee.Employee = employee;
                return r_LogEmployee.Execute();
            }
            else
            {
                return new ProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IProcessResult<TimeLog>> LogAsync(Employee employee)
        {
            if (employee != null)
            {
                r_LogEmployee.Employee = employee;
                return await r_LogEmployee.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IProcessResult<TimeLog>> LogAsync(Employee employee, CancellationToken cancellationToken)
        {
            if (employee != null)
            {
                r_LogEmployee.Employee = employee;
                return await r_LogEmployee.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public IProcessResult<TimeLog> Update(TimeLog data)
        {
            if (data != null)
            {
                r_UpdateTimeLog.TimeLog = data;
                return r_UpdateTimeLog.Execute();
            }
            else
            {
                return new ProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log.");
            }
        }

        public async Task<IProcessResult<TimeLog>> UpdateAsync(TimeLog data)
        {
            if (data != null)
            {
                r_UpdateTimeLog.TimeLog = data;
                return await r_UpdateTimeLog.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log.");
            }
        }

        public async Task<IProcessResult<TimeLog>> UpdateAsync(TimeLog data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_UpdateTimeLog.TimeLog = data;
                return await r_UpdateTimeLog.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log.");
            }
        }
    }
}
