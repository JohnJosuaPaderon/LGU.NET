using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class EmployeeWorkTimeScheduleManager : IEmployeeWorkTimeScheduleManager
    {
        private readonly IDeleteEmployeeWorkTimeSchedule r_Delete;
        private readonly IGetEmployeeWorkTimeScheduleList r_GetList;
        private readonly IInsertEmployeeWorkTimeSchedule r_Insert;
        private readonly IUpdateEmployeeWorkTimeSchedule r_Update;

        public EmployeeWorkTimeScheduleManager(
            IDeleteEmployeeWorkTimeSchedule delete,
            IGetEmployeeWorkTimeScheduleList getList,
            IInsertEmployeeWorkTimeSchedule insert,
            IUpdateEmployeeWorkTimeSchedule update)
        {
            r_Delete = delete;
            r_GetList = getList;
            r_Insert = insert;
            r_Update = update;
        }

        public IProcessResult<IEmployeeWorkTimeSchedule> Delete(IEmployeeWorkTimeSchedule data)
        {
            if (data != null)
            {
                r_Delete.WorkTimeSchedule = data;
                return r_Delete.Execute();
            }
            else
            {
                return new ProcessResult<IEmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule.");
            }
        }

        public async Task<IProcessResult<IEmployeeWorkTimeSchedule>> DeleteAsync(IEmployeeWorkTimeSchedule data)
        {
            if (data != null)
            {
                r_Delete.WorkTimeSchedule = data;
                return await r_Delete.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<IEmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule.");
            }
        }

        public async Task<IProcessResult<IEmployeeWorkTimeSchedule>> DeleteAsync(IEmployeeWorkTimeSchedule data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Delete.WorkTimeSchedule = data;
                return await r_Delete.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<IEmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule.");
            }
        }

        public IEnumerableProcessResult<IEmployeeWorkTimeSchedule> GetList()
        {
            return r_GetList.Execute();
        }

        public async Task<IEnumerableProcessResult<IEmployeeWorkTimeSchedule>> GetListAsync()
        {
            return await r_GetList.ExecuteAsync();
        }

        public async Task<IEnumerableProcessResult<IEmployeeWorkTimeSchedule>> GetListAsync(CancellationToken cancellationToken)
        {
            return await r_GetList.ExecuteAsync(cancellationToken);
        }

        public IProcessResult<IEmployeeWorkTimeSchedule> Insert(IEmployeeWorkTimeSchedule data)
        {
            if (data != null)
            {
                r_Insert.EmployeeWorkTimeSchedule = data;
                return r_Insert.Execute();
            }
            else
            {
                return new ProcessResult<IEmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule.");
            }
        }

        public async Task<IProcessResult<IEmployeeWorkTimeSchedule>> InsertAsync(IEmployeeWorkTimeSchedule data)
        {
            if (data != null)
            {
                r_Insert.EmployeeWorkTimeSchedule = data;
                return await r_Insert.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<IEmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule.");
            }
        }

        public async Task<IProcessResult<IEmployeeWorkTimeSchedule>> InsertAsync(IEmployeeWorkTimeSchedule data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Insert.EmployeeWorkTimeSchedule = data;
                return await r_Insert.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<IEmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule.");
            }
        }

        public IProcessResult<IEmployeeWorkTimeSchedule> Update(IEmployeeWorkTimeSchedule data)
        {
            if (data != null)
            {
                r_Update.EmployeeWorkTimeSchedule = data;
                return r_Update.Execute();
            }
            else
            {
                return new ProcessResult<IEmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule.");
            }
        }

        public async Task<IProcessResult<IEmployeeWorkTimeSchedule>> UpdateAsync(IEmployeeWorkTimeSchedule data)
        {
            if (data != null)
            {
                r_Update.EmployeeWorkTimeSchedule = data;
                return await r_Update.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<IEmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule.");
            }
        }

        public async Task<IProcessResult<IEmployeeWorkTimeSchedule>> UpdateAsync(IEmployeeWorkTimeSchedule data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Update.EmployeeWorkTimeSchedule = data;
                return await r_Update.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<IEmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule.");
            }
        }
    }
}
