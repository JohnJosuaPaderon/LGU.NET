using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class SalaryGradeBatchManager : EntityManagerBase<ISalaryGradeBatch, int>, ISalaryGradeBatchManager
    {
        private readonly IDeleteSalaryGradeBatch r_Delete;
        private readonly IGetSalaryGradeBatchById r_GetById;
        private readonly IGetSalaryGradeBatchList r_GetList;
        private readonly IInsertSalaryGradeBatch r_Insert;
        private readonly IUpdateSalaryGradeBatch r_Update;
        private readonly IGetCurrentSalaryGradeBatch r_GetCurrent;

        public SalaryGradeBatchManager(
            IDeleteSalaryGradeBatch delete,
            IGetSalaryGradeBatchById getById,
            IGetSalaryGradeBatchList getList,
            IInsertSalaryGradeBatch insert,
            IUpdateSalaryGradeBatch update,
            IGetCurrentSalaryGradeBatch getCurrent)
        {
            r_Delete = delete;
            r_GetById = getById;
            r_GetList = getList;
            r_Insert = insert;
            r_Update = update;
            r_GetCurrent = getCurrent;
        }

        public IProcessResult<ISalaryGradeBatch> Delete(ISalaryGradeBatch data)
        {
            if (data != null)
            {
                r_Delete.SalaryGradeBatch = data;
                return RemoveIfSuccess(r_Delete.Execute());
            }
            else
            {
                return new ProcessResult<ISalaryGradeBatch>(ProcessResultStatus.Failed, "Invalid salary grade batch.");
            }
        }

        public async Task<IProcessResult<ISalaryGradeBatch>> DeleteAsync(ISalaryGradeBatch data)
        {
            if (data != null)
            {
                r_Delete.SalaryGradeBatch = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<ISalaryGradeBatch>(ProcessResultStatus.Failed, "Invalid salary grade batch.");
            }
        }

        public async Task<IProcessResult<ISalaryGradeBatch>> DeleteAsync(ISalaryGradeBatch data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Delete.SalaryGradeBatch = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<ISalaryGradeBatch>(ProcessResultStatus.Failed, "Invalid salary grade batch.");
            }
        }

        public IProcessResult<ISalaryGradeBatch> GetById(int id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ISalaryGradeBatch>(StaticSource[id]);
                }
                else
                {
                    r_GetById.SalaryGradeBatchId = id;
                    return AddUpdateIfSuccess(r_GetById.Execute());
                }
            }
            else
            {
                return new ProcessResult<ISalaryGradeBatch>(ProcessResultStatus.Failed, "Invalid salary grade batch identifier.");
            }
        }

        public async Task<IProcessResult<ISalaryGradeBatch>> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ISalaryGradeBatch>(StaticSource[id]);
                }
                else
                {
                    r_GetById.SalaryGradeBatchId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<ISalaryGradeBatch>(ProcessResultStatus.Failed, "Invalid salary grade batch identifier.");
            }
        }

        public async Task<IProcessResult<ISalaryGradeBatch>> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ISalaryGradeBatch>(StaticSource[id]);
                }
                else
                {
                    r_GetById.SalaryGradeBatchId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return new ProcessResult<ISalaryGradeBatch>(ProcessResultStatus.Failed, "Invalid salary grade batch identifier.");
            }
        }

        public IProcessResult<ISalaryGradeBatch> GetCurrent()
        {
            return AddUpdateIfSuccess(r_GetCurrent.Execute());
        }

        public async Task<IProcessResult<ISalaryGradeBatch>> GetCurrentAsync()
        {
            return AddUpdateIfSuccess(await r_GetCurrent.ExecuteAsync());
        }

        public async Task<IProcessResult<ISalaryGradeBatch>> GetCurrentAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await r_GetCurrent.ExecuteAsync(cancellationToken));
        }

        public IEnumerableProcessResult<ISalaryGradeBatch> GetList()
        {
            return AddUpdateIfSuccess(r_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<ISalaryGradeBatch>> GetListAsync()
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<ISalaryGradeBatch>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync(cancellationToken));
        }

        public IProcessResult<ISalaryGradeBatch> Insert(ISalaryGradeBatch data)
        {
            if (data != null)
            {
                r_Insert.SalaryGradeBatch = data;
                return AddIfSuccess(r_Insert.Execute());
            }
            else
            {
                return new ProcessResult<ISalaryGradeBatch>(ProcessResultStatus.Failed, "Invalid salary grade batch.");
            }
        }

        public async Task<IProcessResult<ISalaryGradeBatch>> InsertAsync(ISalaryGradeBatch data)
        {
            if (data != null)
            {
                r_Insert.SalaryGradeBatch = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<ISalaryGradeBatch>(ProcessResultStatus.Failed, "Invalid salary grade batch.");
            }
        }

        public async Task<IProcessResult<ISalaryGradeBatch>> InsertAsync(ISalaryGradeBatch data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Insert.SalaryGradeBatch = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<ISalaryGradeBatch>(ProcessResultStatus.Failed, "Invalid salary grade batch.");
            }
        }

        public IProcessResult<ISalaryGradeBatch> Update(ISalaryGradeBatch data)
        {
            if (data != null)
            {
                r_Update.SalaryGradeBatch = data;
                return UpdateIfSuccess(r_Update.Execute());
            }
            else
            {
                return new ProcessResult<ISalaryGradeBatch>(ProcessResultStatus.Failed, "Invalid salary grade batch.");
            }
        }

        public async Task<IProcessResult<ISalaryGradeBatch>> UpdateAsync(ISalaryGradeBatch data)
        {
            if (data != null)
            {
                r_Update.SalaryGradeBatch = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<ISalaryGradeBatch>(ProcessResultStatus.Failed, "Invalid salary grade batch.");
            }
        }

        public async Task<IProcessResult<ISalaryGradeBatch>> UpdateAsync(ISalaryGradeBatch data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Update.SalaryGradeBatch = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<ISalaryGradeBatch>(ProcessResultStatus.Failed, "Invalid salary grade batch.");
            }
        }
    }
}
