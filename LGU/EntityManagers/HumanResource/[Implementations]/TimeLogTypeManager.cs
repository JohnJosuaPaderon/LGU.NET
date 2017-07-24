using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class TimeLogTypeManager : ManagerBase<TimeLogType, short>, ITimeLogTypeManager
    {
        private readonly IDeleteTimeLogType r_DeleteTimeLogType;
        private readonly IGetTimeLogTypeById r_GetTimeLogTypeById;
        private readonly IGetTimeLogTypeList r_GetTimeLogTypeList;
        private readonly IInsertTimeLogType r_InsertTimeLogType;
        private readonly IUpdateTimeLogType r_UpdateTimeLogType;
        
        public TimeLogTypeManager(
            IDeleteTimeLogType deleteTimeLogType,
            IGetTimeLogTypeById getTimeLogTypeById,
            IGetTimeLogTypeList getTimeLogTypeList,
            IInsertTimeLogType insertTimeLogType,
            IUpdateTimeLogType updateTimeLogType)
        {
            r_DeleteTimeLogType = deleteTimeLogType;
            r_GetTimeLogTypeById = getTimeLogTypeById;
            r_GetTimeLogTypeList = getTimeLogTypeList;
            r_InsertTimeLogType = insertTimeLogType;
            r_UpdateTimeLogType = updateTimeLogType;
        }

        public IProcessResult<TimeLogType> Delete(TimeLogType data)
        {
            if (data != null)
            {
                r_DeleteTimeLogType.TimeLogType = data;
                var result = r_DeleteTimeLogType.Execute();
                RemoveIfSuccess(result);

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
                r_DeleteTimeLogType.TimeLogType = data;
                var result = await r_DeleteTimeLogType.ExecuteAsync();
                RemoveIfSuccess(result);

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
                r_DeleteTimeLogType.TimeLogType = data;
                var result = await r_DeleteTimeLogType.ExecuteAsync(cancellationToken);
                RemoveIfSuccess(result);

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
                    r_GetTimeLogTypeById.TimeLogTypeId = id;
                    var result = r_GetTimeLogTypeById.Execute();
                    AddUpdateIfSuccess(result);

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
                    r_GetTimeLogTypeById.TimeLogTypeId = id;
                    var result = await r_GetTimeLogTypeById.ExecuteAsync();
                    AddUpdateIfSuccess(result);

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
                    r_GetTimeLogTypeById.TimeLogTypeId = id;
                    var result = await r_GetTimeLogTypeById.ExecuteAsync(cancellationToken);
                    AddUpdateIfSuccess(result);

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
            var result = r_GetTimeLogTypeList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<TimeLogType>> GetListAsync()
        {
            var result = await r_GetTimeLogTypeList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<TimeLogType>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetTimeLogTypeList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }

        public IProcessResult<TimeLogType> Insert(TimeLogType data)
        {
            if (data != null)
            {
                r_InsertTimeLogType.TimeLogType = data;
                var result = r_InsertTimeLogType.Execute();
                AddIfSuccess(result);

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
                r_InsertTimeLogType.TimeLogType = data;
                var result = await r_InsertTimeLogType.ExecuteAsync();
                AddIfSuccess(result);

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
                r_InsertTimeLogType.TimeLogType = data;
                var result = await r_InsertTimeLogType.ExecuteAsync(cancellationToken);
                AddIfSuccess(result);

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
                r_UpdateTimeLogType.TimeLogType = data;
                var result = r_UpdateTimeLogType.Execute();
                UpdateIfSuccess(result);

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
                r_UpdateTimeLogType.TimeLogType = data;
                var result = await r_UpdateTimeLogType.ExecuteAsync();
                UpdateIfSuccess(result);

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
                r_UpdateTimeLogType.TimeLogType = data;
                var result = await r_UpdateTimeLogType.ExecuteAsync(cancellationToken);
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<TimeLogType>(ProcessResultStatus.Failed, "Invalid time log type.");
            }
        }
    }
}
