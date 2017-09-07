using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class WorkTimeScheduleManager : ManagerBase<IWorkTimeSchedule, int>, IWorkTimeScheduleManager
    {
        private readonly IDeleteWorkTimeSchedule r_Delete;
        private readonly IGetWorkTimeScheduleById r_GetById;
        private readonly IGetWorkTimeScheduleList r_GetList;
        private readonly IInsertWorkTimeSchedule r_Insert;
        private readonly IUpdateWorkTimeSchedule r_Update;

        public WorkTimeScheduleManager(
            IDeleteWorkTimeSchedule delete,
            IGetWorkTimeScheduleById getById,
            IGetWorkTimeScheduleList getList,
            IInsertWorkTimeSchedule insert,
            IUpdateWorkTimeSchedule update)
        {
            r_Delete = delete;
            r_GetById = getById;
            r_GetList = getList;
            r_Insert = insert;
            r_Update = update;
        }

        public IProcessResult<IWorkTimeSchedule> Delete(IWorkTimeSchedule data)
        {
            if (data != null)
            {
                r_Delete.WorkTimeSchedule = data;
                return RemoveIfSuccess(r_Delete.Execute());
            }
            else
            {
                return new ProcessResult<IWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work-time schedule.");
            }
        }

        public async Task<IProcessResult<IWorkTimeSchedule>> DeleteAsync(IWorkTimeSchedule data)
        {
            if (data != null)
            {
                r_Delete.WorkTimeSchedule = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work-time schedule.");
            }
        }

        public async Task<IProcessResult<IWorkTimeSchedule>> DeleteAsync(IWorkTimeSchedule data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Delete.WorkTimeSchedule = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work-time schedule.");
            }
        }

        public IProcessResult<IWorkTimeSchedule> GetById(int id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IWorkTimeSchedule>(StaticSource[id]);
                }
                else
                {
                    r_GetById.WorkTimeScheduleId = id;
                    return AddUpdateIfSuccess(r_GetById.Execute());
                }
            }
            else
            {
                return new ProcessResult<IWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work-time schedule identifier.");
            }
        }

        public async Task<IProcessResult<IWorkTimeSchedule>> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IWorkTimeSchedule>(StaticSource[id]);
                }
                else
                {
                    r_GetById.WorkTimeScheduleId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<IWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work-time schedule identifier.");
            }
        }

        public async Task<IProcessResult<IWorkTimeSchedule>> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IWorkTimeSchedule>(StaticSource[id]);
                }
                else
                {
                    r_GetById.WorkTimeScheduleId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return new ProcessResult<IWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work-time schedule identifier.");
            }
        }

        public IEnumerableProcessResult<IWorkTimeSchedule> GetList()
        {
            return AddUpdateIfSuccess(r_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<IWorkTimeSchedule>> GetListAsync()
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<IWorkTimeSchedule>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync(cancellationToken));
        }

        public IProcessResult<IWorkTimeSchedule> Insert(IWorkTimeSchedule data)
        {
            if (data != null)
            {
                r_Insert.WorkTimeSchedule = data;
                return AddIfSuccess(r_Insert.Execute());
            }
            else
            {
                return new ProcessResult<IWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work-time schedule.");
            }
        }

        public async Task<IProcessResult<IWorkTimeSchedule>> InsertAsync(IWorkTimeSchedule data)
        {
            if (data != null)
            {
                r_Insert.WorkTimeSchedule = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work-time schedule.");
            }
        }

        public async Task<IProcessResult<IWorkTimeSchedule>> InsertAsync(IWorkTimeSchedule data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Insert.WorkTimeSchedule = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work-time schedule.");
            }
        }

        public IProcessResult<IWorkTimeSchedule> Update(IWorkTimeSchedule data)
        {
            if (data != null)
            {
                r_Update.WorkTimeSchedule = data;
                return UpdateIfSuccess(r_Update.Execute());
            }
            else
            {
                return new ProcessResult<IWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work-time schedule.");
            }
        }

        public async Task<IProcessResult<IWorkTimeSchedule>> UpdateAsync(IWorkTimeSchedule data)
        {
            if (data != null)
            {
                r_Update.WorkTimeSchedule = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work-time schedule.");
            }
        }

        public async Task<IProcessResult<IWorkTimeSchedule>> UpdateAsync(IWorkTimeSchedule data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Update.WorkTimeSchedule = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IWorkTimeSchedule>(ProcessResultStatus.Failed, "Invalid work-time schedule.");
            }
        }
    }
}
