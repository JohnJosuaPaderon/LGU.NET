using LGU.Entities;
using LGU.Entities.Core;
using LGU.EntityProcesses.Core;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public sealed class GenderManager : IGenderManager
    {
        private readonly IGetGenderById GetByIdProc;
        private readonly IGetGenderList GetListProc;

        private static EntityCollection<Gender, short> StaticSource { get; set; } = new EntityCollection<Gender, short>();

        public GenderManager(
            IGetGenderById getByIdProc,
            IGetGenderList getListProc)
        {
            GetByIdProc = getByIdProc;
            GetListProc = getListProc;
        }

        public IDataProcessResult<Gender> GetById(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new DataProcessResult<Gender>(StaticSource[id]);
                }
                else
                {
                    GetByIdProc.GenderId = id;
                    var result = GetByIdProc.Execute();

                    if (result.Status == ProcessResultStatus.Success)
                    {
                        StaticSource.AddUpdate(result.Data);
                    }

                    return result;
                }
            }
            else
            {
                return new DataProcessResult<Gender>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IDataProcessResult<Gender>> GetByIdAsync(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new DataProcessResult<Gender>(StaticSource[id]);
                }
                else
                {
                    GetByIdProc.GenderId = id;
                    var result = await GetByIdProc.ExecuteAsync();

                    if (result.Status == ProcessResultStatus.Success)
                    {
                        StaticSource.AddUpdate(result.Data);
                    }

                    return result;
                }
            }
            else
            {
                return new DataProcessResult<Gender>(ProcessResultStatus.Failed);
            }
        }

        public async Task<IDataProcessResult<Gender>> GetByIdAsync(short id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new DataProcessResult<Gender>(StaticSource[id]);
                }
                else
                {
                    GetByIdProc.GenderId = id;
                    var result = await GetByIdProc.ExecuteAsync(cancellationToken);

                    if (result.Status == ProcessResultStatus.Success)
                    {
                        StaticSource.AddUpdate(result.Data);
                    }

                    return result;
                }
            }
            else
            {
                return new DataProcessResult<Gender>(ProcessResultStatus.Failed);
            }
        }

        public IEnumerableDataProcessResult<Gender> GetList()
        {
            return GetListProc.Execute();
        }

        public Task<IEnumerableDataProcessResult<Gender>> GetListAsync()
        {
            return GetListProc.ExecuteAsync();
        }

        public Task<IEnumerableDataProcessResult<Gender>> GetListAsync(CancellationToken cancellationToken)
        {
            return GetListProc.ExecuteAsync(cancellationToken);
        }
    }
}
