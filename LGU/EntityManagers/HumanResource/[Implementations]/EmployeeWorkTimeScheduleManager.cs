using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class EmployeeWorkTimeScheduleManager : ManagerBase<EmployeeWorkTimeSchedule, long>, IEmployeeWorkTimeScheduleManager
    {
        private readonly IDeleteEmployeeWorkTimeSchedule r_Delete;
        private readonly IGetEmployeeWorkTimeScheduleById r_GetById;
        private readonly IGetEmployeeWorkTimeScheduleList r_GetList;
        private readonly IInsertEmployeeWorkTimeSchedule r_Insert;
        private readonly IUpdateEmployeeWorkTimeSchedule r_Update;

        public EmployeeWorkTimeScheduleManager(
            IDeleteEmployeeWorkTimeSchedule delete,
            IGetEmployeeWorkTimeScheduleById getById,
            IGetEmployeeWorkTimeScheduleList getList,
            IInsertEmployeeWorkTimeSchedule insert,
            IUpdateEmployeeWorkTimeSchedule update)
        {
            r_Delete = delete;
            r_GetById = getById;
            r_GetList = getList;
            r_Insert = insert;
            r_Update = update;
        }

        public IProcessResult<EmployeeWorkTimeSchedule> Delete(EmployeeWorkTimeSchedule data)
        {
            if (data != null)
            {
                r_Delete.WorkTimeSchedule = data;
                return RemoveIfSuccess(r_Delete.Execute());
            }
            else
            {
                return new ProcessResult<EmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule.");
            }
        }

        public async Task<IProcessResult<EmployeeWorkTimeSchedule>> DeleteAsync(EmployeeWorkTimeSchedule data)
        {
            if (data != null)
            {
                r_Delete.WorkTimeSchedule = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<EmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule.");
            }
        }

        public async Task<IProcessResult<EmployeeWorkTimeSchedule>> DeleteAsync(EmployeeWorkTimeSchedule data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Delete.WorkTimeSchedule = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<EmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule.");
            }
        }

        public IProcessResult<EmployeeWorkTimeSchedule> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<EmployeeWorkTimeSchedule>(StaticSource[id]);
                }
                else
                {
                    r_GetById.WorkTimeScheduleId = id;
                    return AddUpdateIfSuccess(r_GetById.Execute());
                }
            }
            else
            {
                return new ProcessResult<EmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule identifier.");
            }
        }

        public async Task<IProcessResult<EmployeeWorkTimeSchedule>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<EmployeeWorkTimeSchedule>(StaticSource[id]);
                }
                else
                {
                    r_GetById.WorkTimeScheduleId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<EmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule identifier.");
            }
        }

        public async Task<IProcessResult<EmployeeWorkTimeSchedule>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<EmployeeWorkTimeSchedule>(StaticSource[id]);
                }
                else
                {
                    r_GetById.WorkTimeScheduleId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<EmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule identifier.");
            }
        }

        public IEnumerableProcessResult<EmployeeWorkTimeSchedule> GetList()
        {
            return AddUpdateIfSuccess(r_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<EmployeeWorkTimeSchedule>> GetListAsync()
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<EmployeeWorkTimeSchedule>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync(cancellationToken));
        }

        public IProcessResult<EmployeeWorkTimeSchedule> Insert(EmployeeWorkTimeSchedule data)
        {
            if (data != null)
            {
                r_Insert.WorkTimeSchedule = data;
                return AddIfSuccess(r_Insert.Execute());
            }
            else
            {
                return new ProcessResult<EmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule.");
            }
        }

        public async Task<IProcessResult<EmployeeWorkTimeSchedule>> InsertAsync(EmployeeWorkTimeSchedule data)
        {
            if (data != null)
            {
                r_Insert.WorkTimeSchedule = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<EmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule.");
            }
        }

        public async Task<IProcessResult<EmployeeWorkTimeSchedule>> InsertAsync(EmployeeWorkTimeSchedule data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Insert.WorkTimeSchedule = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<EmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule.");
            }
        }

        public IProcessResult<EmployeeWorkTimeSchedule> Update(EmployeeWorkTimeSchedule data)
        {
            if (data != null)
            {
                r_Update.WorkTimeSchedule = data;
                return UpdateIfSuccess(r_Update.Execute());
            }
            else
            {
                return new ProcessResult<EmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule.");
            }
        }

        public async Task<IProcessResult<EmployeeWorkTimeSchedule>> UpdateAsync(EmployeeWorkTimeSchedule data)
        {
            if (data != null)
            {
                r_Update.WorkTimeSchedule = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<EmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule.");
            }
        }

        public async Task<IProcessResult<EmployeeWorkTimeSchedule>> UpdateAsync(EmployeeWorkTimeSchedule data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Update.WorkTimeSchedule = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<EmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule.");
            }
        }
    }
}
