using LGU.Entities.Core;
using LGU.EntityProcesses.Core;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public sealed class GenderManager : ManagerBase<Gender, short>, IGenderManager
    {

        private readonly IGetGenderById r_GetGenderById;
        private readonly IGetGenderList r_GetGenderList;
        
        public GenderManager(
            IGetGenderById getGenderById,
            IGetGenderList getGenderList)
        {
            r_GetGenderById = getGenderById;
            r_GetGenderList = getGenderList;
        }

        public IProcessResult<Gender> GetById(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Gender>(StaticSource[id]);
                }
                else
                {
                    r_GetGenderById.GenderId = id;
                    var result = r_GetGenderById.Execute();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<Gender>(ProcessResultStatus.Failed, "Invalid gender identifier.");
            }
        }

        public async Task<IProcessResult<Gender>> GetByIdAsync(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Gender>(StaticSource[id]);
                }
                else
                {
                    r_GetGenderById.GenderId = id;
                    var result = await r_GetGenderById.ExecuteAsync();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<Gender>(ProcessResultStatus.Failed, "Invalid gender identifier.");
            }
        }

        public async Task<IProcessResult<Gender>> GetByIdAsync(short id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Gender>(StaticSource[id]);
                }
                else
                {
                    r_GetGenderById.GenderId = id;
                    var result = await r_GetGenderById.ExecuteAsync(cancellationToken);
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<Gender>(ProcessResultStatus.Failed, "Invalid gender identifier.");
            }
        }

        public IEnumerableProcessResult<Gender> GetList()
        {
            var result = r_GetGenderList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<Gender>> GetListAsync()
        {
            var result = await r_GetGenderList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<Gender>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetGenderList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }
    }
}
