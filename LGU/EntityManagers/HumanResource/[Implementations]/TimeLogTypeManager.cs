using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class TimeLogTypeManager : EntityManagerBase<ITimeLogType, short>, ITimeLogTypeManager
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

        public IProcessResult<ITimeLogType> GetById(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ITimeLogType>(StaticSource[id]);
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
                return new ProcessResult<ITimeLogType>(ProcessResultStatus.Failed, "Invalid time log type identifier.");
            }
        }

        public async Task<IProcessResult<ITimeLogType>> GetByIdAsync(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ITimeLogType>(StaticSource[id]);
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
                return new ProcessResult<ITimeLogType>(ProcessResultStatus.Failed, "Invalid time log type identifier.");
            }
        }

        public async Task<IProcessResult<ITimeLogType>> GetByIdAsync(short id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ITimeLogType>(StaticSource[id]);
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
                return new ProcessResult<ITimeLogType>(ProcessResultStatus.Failed, "Invalid time log type identifier.");
            }
        }

        public IEnumerableProcessResult<ITimeLogType> GetList()
        {
            var result = r_GetTimeLogTypeList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<ITimeLogType>> GetListAsync()
        {
            var result = await r_GetTimeLogTypeList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<ITimeLogType>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetTimeLogTypeList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }
    }
}
