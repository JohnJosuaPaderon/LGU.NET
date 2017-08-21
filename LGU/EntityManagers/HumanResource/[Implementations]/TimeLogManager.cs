﻿using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class TimeLogManager : ManagerBase<TimeLog, long>, ITimeLogManager
    {
        private readonly IDeleteTimeLog r_Delete;
        private readonly IGetTimeLogById r_GetById;
        private readonly IGetTimeLogList r_GetList;
        private readonly IInsertTimeLog r_Insert;
        private readonly ILogEmployee r_LogEmployee;
        private readonly IUpdateTimeLog r_Update;
        private readonly IGetActualTimeLogListByEmployeeCutOff r_GetActualListByEmployeeCutOff;
        private readonly IGetTimeLogListByCutOff r_GetListByCutOff;
        private readonly IGetTimeLogListByDepartmentCutOff r_GetListByDepartmentCutOff;
        private readonly IGetTimeLogListByEmployeeCutOff r_GetListByEmployeeCutOff;

        public TimeLogManager(
            IDeleteTimeLog deleteTimeLog,
            IGetTimeLogById getTimeLogById,
            IGetTimeLogList getTimeLogList,
            IInsertTimeLog insertTimeLog,
            ILogEmployee logEmployee,
            IUpdateTimeLog updateTimeLog,
            IGetActualTimeLogListByEmployeeCutOff getActualListByEmployeeCutOff,
            IGetTimeLogListByCutOff getListByCutOff,
            IGetTimeLogListByDepartmentCutOff getListByDepartmentCutOff,
            IGetTimeLogListByEmployeeCutOff getListByEmployeeCutOff)
        {
            r_Delete = deleteTimeLog;
            r_GetById = getTimeLogById;
            r_GetList = getTimeLogList;
            r_Insert = insertTimeLog;
            r_LogEmployee = logEmployee;
            r_Update = updateTimeLog;
            r_GetActualListByEmployeeCutOff = getActualListByEmployeeCutOff;
            r_GetListByCutOff = getListByCutOff;
            r_GetListByDepartmentCutOff = getListByDepartmentCutOff;
            r_GetListByEmployeeCutOff = getListByEmployeeCutOff;
        }

        public IProcessResult<TimeLog> Delete(TimeLog data)
        {
            if (data != null)
            {
                r_Delete.TimeLog = data;
                return r_Delete.Execute();
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
                r_Delete.TimeLog = data;
                return await r_Delete.ExecuteAsync();
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
                r_Delete.TimeLog = data;
                return await r_Delete.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log.");
            }
        }

        public IEnumerableProcessResult<TimeLog> GetActualListByEmployeeCutOff(Employee employee, ValueRange<DateTime> cutOff)
        {
            if (employee != null)
            {
                r_GetActualListByEmployeeCutOff.Employee = employee;
                r_GetActualListByEmployeeCutOff.CutOff = cutOff;
                return r_GetActualListByEmployeeCutOff.Execute();
            }
            else
            {
                return new EnumerableProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IEnumerableProcessResult<TimeLog>> GetActualListByEmployeeCutOffAsync(Employee employee, ValueRange<DateTime> cutOff)
        {
            if (employee != null)
            {
                r_GetActualListByEmployeeCutOff.Employee = employee;
                r_GetActualListByEmployeeCutOff.CutOff = cutOff;
                return await r_GetActualListByEmployeeCutOff.ExecuteAsync();
            }
            else
            {
                return new EnumerableProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IEnumerableProcessResult<TimeLog>> GetActualListByEmployeeCutOffAsync(Employee employee, ValueRange<DateTime> cutOff, CancellationToken cancellationToken)
        {
            if (employee != null)
            {
                r_GetActualListByEmployeeCutOff.Employee = employee;
                r_GetActualListByEmployeeCutOff.CutOff = cutOff;
                return await r_GetActualListByEmployeeCutOff.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new EnumerableProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public IProcessResult<TimeLog> GetById(long id)
        {
            if (id > 0)
            {
                r_GetById.TimeLogId = id;
                return r_GetById.Execute();
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
                r_GetById.TimeLogId = id;
                return await r_GetById.ExecuteAsync();
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
                r_GetById.TimeLogId = id;
                return await r_GetById.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log identifier.");
            }
        }

        public IEnumerableProcessResult<TimeLog> GetList()
        {
            return r_GetList.Execute();
        }

        public Task<IEnumerableProcessResult<TimeLog>> GetListAsync()
        {
            return r_GetList.ExecuteAsync();
        }

        public Task<IEnumerableProcessResult<TimeLog>> GetListAsync(CancellationToken cancellationToken)
        {
            return r_GetList.ExecuteAsync(cancellationToken);
        }

        public IEnumerableProcessResult<TimeLog> GetListByCutOff(ValueRange<DateTime> cutOff)
        {
            r_GetListByCutOff.CutOff = cutOff;
            return r_GetListByCutOff.Execute();
        }

        public async Task<IEnumerableProcessResult<TimeLog>> GetListByCutOffAsync(ValueRange<DateTime> cutOff)
        {
            r_GetListByCutOff.CutOff = cutOff;
            return await r_GetListByCutOff.ExecuteAsync();
        }

        public async Task<IEnumerableProcessResult<TimeLog>> GetListByCutOffAsync(ValueRange<DateTime> cutOff, CancellationToken cancellationToken)
        {
            r_GetListByCutOff.CutOff = cutOff;
            return await r_GetListByCutOff.ExecuteAsync(cancellationToken);
        }

        public IEnumerableProcessResult<TimeLog> GetListByDepartmentCutOff(Department department, ValueRange<DateTime> cutOff)
        {
            if (department != null)
            {
                r_GetListByDepartmentCutOff.Department = department;
                r_GetListByDepartmentCutOff.CutOff = cutOff;
                return r_GetListByDepartmentCutOff.Execute();
            }
            else
            {
                return new EnumerableProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IEnumerableProcessResult<TimeLog>> GetListByDepartmentCutOffAsync(Department department, ValueRange<DateTime> cutOff)
        {
            if (department != null)
            {
                r_GetListByDepartmentCutOff.Department = department;
                r_GetListByDepartmentCutOff.CutOff = cutOff;
                return await r_GetListByDepartmentCutOff.ExecuteAsync();
            }
            else
            {
                return new EnumerableProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IEnumerableProcessResult<TimeLog>> GetListByDepartmentCutOffAsync(Department department, ValueRange<DateTime> cutOff, CancellationToken cancellationToken)
        {
            if (department != null)
            {
                r_GetListByDepartmentCutOff.Department = department;
                r_GetListByDepartmentCutOff.CutOff = cutOff;
                return await r_GetListByDepartmentCutOff.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new EnumerableProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public IEnumerableProcessResult<TimeLog> GetListByEmployeeCutOff(Employee employee, ValueRange<DateTime> cutOff)
        {
            if (employee != null)
            {
                r_GetListByEmployeeCutOff.Employee = employee;
                r_GetListByEmployeeCutOff.CutOff = cutOff;
                return r_GetListByEmployeeCutOff.Execute();
            }
            else
            {
                return new EnumerableProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IEnumerableProcessResult<TimeLog>> GetListByEmployeeCutOffAsync(Employee employee, ValueRange<DateTime> cutOff)
        {
            if (employee != null)
            {
                r_GetListByEmployeeCutOff.Employee = employee;
                r_GetListByEmployeeCutOff.CutOff = cutOff;
                return await r_GetListByEmployeeCutOff.ExecuteAsync();
            }
            else
            {
                return new EnumerableProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IEnumerableProcessResult<TimeLog>> GetListByEmployeeCutOffAsync(Employee employee, ValueRange<DateTime> cutOff, CancellationToken cancellationToken)
        {
            if (employee != null)
            {
                r_GetListByEmployeeCutOff.Employee = employee;
                r_GetListByEmployeeCutOff.CutOff = cutOff;
                return await r_GetListByEmployeeCutOff.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new EnumerableProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public IProcessResult<TimeLog> Insert(TimeLog data)
        {
            if (data != null)
            {
                r_Insert.TimeLog = data;
                return r_Insert.Execute();
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
                r_Insert.TimeLog = data;
                return await r_Insert.ExecuteAsync();
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
                r_Insert.TimeLog = data;
                return await r_Insert.ExecuteAsync(cancellationToken);
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
                r_Update.TimeLog = data;
                return r_Update.Execute();
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
                r_Update.TimeLog = data;
                return await r_Update.ExecuteAsync();
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
                r_Update.TimeLog = data;
                return await r_Update.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<TimeLog>(ProcessResultStatus.Failed, "Invalid time log.");
            }
        }
    }
}
