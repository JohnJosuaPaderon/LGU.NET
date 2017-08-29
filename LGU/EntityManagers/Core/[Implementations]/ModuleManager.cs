using LGU.Entities.Core;
using LGU.EntityProcesses.Core;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public sealed class ModuleManager : ManagerBase<IModule, short>, IModuleManager
    {
        private readonly IGetModuleById r_GetModuleById;
        private readonly IGetModuleList r_GetModuleList;

        public ModuleManager(
            IGetModuleById getModuleById,
            IGetModuleList getModuleList)
        {
            r_GetModuleById = getModuleById;
            r_GetModuleList = getModuleList;
        }

        public IProcessResult<IModule> GetById(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IModule>(StaticSource[id]);
                }
                else
                {
                    r_GetModuleById.ModuleId = id;
                    var result = r_GetModuleById.Execute();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<IModule>(ProcessResultStatus.Failed, "Invalid module identifier.");
            }
        }

        public async Task<IProcessResult<IModule>> GetByIdAsync(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IModule>(StaticSource[id]);
                }
                else
                {
                    r_GetModuleById.ModuleId = id;
                    var result = await r_GetModuleById.ExecuteAsync();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<IModule>(ProcessResultStatus.Failed, "Invalid module identifier.");
            }
        }

        public async Task<IProcessResult<IModule>> GetByIdAsync(short id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IModule>(StaticSource[id]);
                }
                else
                {
                    r_GetModuleById.ModuleId = id;
                    var result = await r_GetModuleById.ExecuteAsync(cancellationToken);
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<IModule>(ProcessResultStatus.Failed, "Invalid module identifier.");
            }
        }

        public IEnumerableProcessResult<IModule> GetList()
        {
            var result = r_GetModuleList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<IModule>> GetListAsync()
        {
            var result = await r_GetModuleList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<IModule>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetModuleList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }
    }
}
