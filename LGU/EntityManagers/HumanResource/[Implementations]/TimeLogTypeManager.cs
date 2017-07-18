using LGU.Entities;
using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class TimeLogTypeManager : ManagerBase, ITimeLogTypeManager
    {
        private readonly IDeleteTimeLogType DeleteProc;
        private readonly IGetTimeLogTypeById GetByIdProc;
        private readonly IGetTimeLogTypeList GetListProc;
        private readonly IInsertTimeLogType InsertProc;
        private readonly IUpdateTimeLogType UpdateProc;

        private static EntityCollection<TimeLogType, short> StaticSource { get; } = new EntityCollection<TimeLogType, short>();

        public TimeLogTypeManager(
            IDeleteTimeLogType deleteProc,
            IGetTimeLogTypeById getByIdProc,
            IGetTimeLogTypeList getListProc,
            IInsertTimeLogType insertProc,
            IUpdateTimeLogType updateProc)
        {
            DeleteProc = deleteProc;
            GetByIdProc = getByIdProc;
            GetListProc = getListProc;
            InsertProc = insertProc;
            UpdateProc = updateProc;
        }

        public IProcessResult<TimeLogType> Delete(TimeLogType data)
        {
            if (data != null)
            {
                DeleteProc.TimeLogType = data;
                var result = DeleteProc.Execute();
                InvokeIfSuccess(result.Status, () => StaticSource.Remove(result.Data));

                return result;
            }
            else
            {
                return new ProcessResult<TimeLogType>(ProcessResultStatus.Failed, "Invalid time log type.");
            }
        }

        public async Task<IProcessResult<TimeLogType>> DeleteAsync(TimeLogType data)
        {
            if (data != null)
            {
                DeleteProc.TimeLogType = data;
                var result = await DeleteProc.ExecuteAsync();
                InvokeIfSuccess(result.Status, () => StaticSource.Remove(result.Data));

                return result;
            }
            else
            {
                return new ProcessResult<TimeLogType>(ProcessResultStatus.Failed, "Invalid time log type.");
            }
        }

        public async Task<IProcessResult<TimeLogType>> DeleteAsync(TimeLogType data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                DeleteProc.TimeLogType = data;
                var result = await DeleteProc.ExecuteAsync(cancellationToken);
                InvokeIfSuccess(result.Status, () => StaticSource.Remove(result.Data));

                return result;
            }
            else
            {
                return new ProcessResult<TimeLogType>(ProcessResultStatus.Failed, "Invalid time log type.");
            }
        }

        public IProcessResult<TimeLogType> GetById(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<TimeLogType>(StaticSource[id]);
                }
                else
                {
                    GetByIdProc.TimeLogTypeId = id;
                    var result = GetByIdProc.Execute();
                    InvokeIfSuccess(result.Status, () => StaticSource.AddUpdate(result.Data));

                    return result;
                }
            }
            else
            {
                return new ProcessResult<TimeLogType>(ProcessResultStatus.Failed, "Invalid time log type identifier.");
            }
        }

        public async Task<IProcessResult<TimeLogType>> GetByIdAsync(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<TimeLogType>(StaticSource[id]);
                }
                else
                {
                    GetByIdProc.TimeLogTypeId = id;
                    var result = await GetByIdProc.ExecuteAsync();
                    InvokeIfSuccess(result.Status, () => StaticSource.AddUpdate(result.Data));

                    return result;
                }
            }
            else
            {
                return new ProcessResult<TimeLogType>(ProcessResultStatus.Failed, "Invalid time log type identifier.");
            }
        }

        public async Task<IProcessResult<TimeLogType>> GetByIdAsync(short id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<TimeLogType>(StaticSource[id]);
                }
                else
                {
                    GetByIdProc.TimeLogTypeId = id;
                    var result = await GetByIdProc.ExecuteAsync(cancellationToken);
                    InvokeIfSuccess(result.Status, () => StaticSource.AddUpdate(result.Data));

                    return result;
                }
            }
            else
            {
                return new ProcessResult<TimeLogType>(ProcessResultStatus.Failed, "Invalid time log type identifier.");
            }
        }

        public IEnumerableProcessResult<TimeLogType> GetList()
        {
            var result = GetListProc.Execute();
            InvokeIfSuccessAndListNotEmpty(result, tlt => StaticSource.AddUpdate(tlt));

            return result;
        }

        public async Task<IEnumerableProcessResult<TimeLogType>> GetListAsync()
        {
            var result = await GetListProc.ExecuteAsync();
            InvokeIfSuccessAndListNotEmpty(result, tlt => StaticSource.AddUpdate(tlt));

            return result;
        }

        public async Task<IEnumerableProcessResult<TimeLogType>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await GetListProc.ExecuteAsync(cancellationToken);
            InvokeIfSuccessAndListNotEmpty(result, tlt => StaticSource.AddUpdate(tlt));

            return result;
        }

        public IProcessResult<TimeLogType> Insert(TimeLogType data)
        {
            if (data != null)
            {
                InsertProc.TimeLogType = data;
                var result = InsertProc.Execute();
                InvokeIfSuccess(result.Status, () => StaticSource.Add(result.Data));

                return result;
            }
            else
            {
                return new ProcessResult<TimeLogType>(ProcessResultStatus.Failed, "Invalid time log type.");
            }
        }

        public async Task<IProcessResult<TimeLogType>> InsertAsync(TimeLogType data)
        {
            if (data != null)
            {
                InsertProc.TimeLogType = data;
                var result = await InsertProc.ExecuteAsync();
                InvokeIfSuccess(result.Status, () => StaticSource.Add(result.Data));

                return result;
            }
            else
            {
                return new ProcessResult<TimeLogType>(ProcessResultStatus.Failed, "Invalid time log type.");
            }
        }

        public async Task<IProcessResult<TimeLogType>> InsertAsync(TimeLogType data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                InsertProc.TimeLogType = data;
                var result = await InsertProc.ExecuteAsync(cancellationToken);
                InvokeIfSuccess(result.Status, () => StaticSource.Add(result.Data));

                return result;
            }
            else
            {
                return new ProcessResult<TimeLogType>(ProcessResultStatus.Failed, "Invalid time log type.");
            }
        }

        public IProcessResult<TimeLogType> Update(TimeLogType data)
        {
            if (data != null)
            {
                UpdateProc.TimeLogType = data;
                var result = UpdateProc.Execute();
                InvokeIfSuccess(result.Status, () => StaticSource.Update(result.Data));

                return result;
            }
            else
            {
                return new ProcessResult<TimeLogType>(ProcessResultStatus.Failed, "Invalid time log type.");
            }
        }

        public async Task<IProcessResult<TimeLogType>> UpdateAsync(TimeLogType data)
        {
            if (data != null)
            {
                UpdateProc.TimeLogType = data;
                var result = await UpdateProc.ExecuteAsync();
                InvokeIfSuccess(result.Status, () => StaticSource.Update(result.Data));

                return result;
            }
            else
            {
                return new ProcessResult<TimeLogType>(ProcessResultStatus.Failed, "Invalid time log type.");
            }
        }

        public async Task<IProcessResult<TimeLogType>> UpdateAsync(TimeLogType data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                UpdateProc.TimeLogType = data;
                var result = await UpdateProc.ExecuteAsync(cancellationToken);
                InvokeIfSuccess(result.Status, () => StaticSource.Update(result.Data));

                return result;
            }
            else
            {
                return new ProcessResult<TimeLogType>(ProcessResultStatus.Failed, "Invalid time log type.");
            }
        }
    }
}
