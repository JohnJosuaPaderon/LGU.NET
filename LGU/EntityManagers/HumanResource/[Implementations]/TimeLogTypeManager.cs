using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class TimeLogTypeManager : ManagerBase<TimeLogType, short>, ITimeLogTypeManager
    {
        private readonly IGetTimeLogTypeById r_GetTimeLogTypeById;
        private readonly IGetTimeLogTypeList r_GetTimeLogTypeList;
        
        public TimeLogTypeManager(
            IGetTimeLogTypeById getTimeLogTypeById,
            IGetTimeLogTypeList getTimeLogTypeList)
        {
            r_GetTimeLogTypeById = getTimeLogTypeById;
            r_GetTimeLogTypeList = getTimeLogTypeList;
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
    }
}
