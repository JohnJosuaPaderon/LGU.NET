using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class EmployeeWorkTimeScheduleManager : ManagerBase<IEmployeeWorkTimeSchedule, long>, IEmployeeWorkTimeScheduleManager
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

        public IProcessResult<IEmployeeWorkTimeSchedule> Delete(IEmployeeWorkTimeSchedule data)
        {
            if (data != null)
            {
                r_Delete.WorkTimeSchedule = data;
                return RemoveIfSuccess(r_Delete.Execute());
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
                return RemoveIfSuccess(await r_Delete.ExecuteAsync());
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
                return RemoveIfSuccess(await r_Delete.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IEmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule.");
            }
        }

        public IProcessResult<IEmployeeWorkTimeSchedule> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IEmployeeWorkTimeSchedule>(StaticSource[id]);
                }
                else
                {
                    r_GetById.WorkTimeScheduleId = id;
                    return AddUpdateIfSuccess(r_GetById.Execute());
                }
            }
            else
            {
                return new ProcessResult<IEmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule identifier.");
            }
        }

        public async Task<IProcessResult<IEmployeeWorkTimeSchedule>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IEmployeeWorkTimeSchedule>(StaticSource[id]);
                }
                else
                {
                    r_GetById.WorkTimeScheduleId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<IEmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule identifier.");
            }
        }

        public async Task<IProcessResult<IEmployeeWorkTimeSchedule>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IEmployeeWorkTimeSchedule>(StaticSource[id]);
                }
                else
                {
                    r_GetById.WorkTimeScheduleId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<IEmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule identifier.");
            }
        }

        public IEnumerableProcessResult<IEmployeeWorkTimeSchedule> GetList()
        {
            return AddUpdateIfSuccess(r_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<IEmployeeWorkTimeSchedule>> GetListAsync()
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<IEmployeeWorkTimeSchedule>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync(cancellationToken));
        }

        public IProcessResult<IEmployeeWorkTimeSchedule> Insert(IEmployeeWorkTimeSchedule data)
        {
            if (data != null)
            {
                r_Insert.WorkTimeSchedule = data;
                return AddIfSuccess(r_Insert.Execute());
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
                r_Insert.WorkTimeSchedule = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync());
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
                r_Insert.WorkTimeSchedule = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync(cancellationToken));
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
                r_Update.WorkTimeSchedule = data;
                return UpdateIfSuccess(r_Update.Execute());
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
                r_Update.WorkTimeSchedule = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync());
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
                r_Update.WorkTimeSchedule = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IEmployeeWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work time schedule.");
            }
        }
    }
}
