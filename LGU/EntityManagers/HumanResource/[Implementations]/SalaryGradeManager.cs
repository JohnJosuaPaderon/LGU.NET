using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class SalaryGradeManager : ManagerBase<ISalaryGrade, long>, ISalaryGradeManager
    {
        private readonly IDeleteSalaryGrade r_Delete;
        private readonly IGetSalaryGradeById r_GetById;
        private readonly IGetSalaryGradeList r_GetList;
        private readonly IInsertSalaryGrade r_Insert;
        private readonly IUpdateSalaryGrade r_Update;

        public SalaryGradeManager(
            IDeleteSalaryGrade delete,
            IGetSalaryGradeById getById,
            IGetSalaryGradeList getList,
            IInsertSalaryGrade insert,
            IUpdateSalaryGrade update)
        {
            r_Delete = delete;
            r_GetById = getById;
            r_GetList = getList;
            r_Insert = insert;
            r_Update = update;
        }

        public IProcessResult<ISalaryGrade> Delete(ISalaryGrade data)
        {
            if (data != null)
            {
                r_Delete.SalaryGrade = data;
                return RemoveIfSuccess(r_Delete.Execute());
            }
            else
            {
                return new ProcessResult<ISalaryGrade>(ProcessResultStatus.Failed, "Invalid salary grade.");
            }
        }

        public async Task<IProcessResult<ISalaryGrade>> DeleteAsync(ISalaryGrade data)
        {
            if (data != null)
            {
                r_Delete.SalaryGrade = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<ISalaryGrade>(ProcessResultStatus.Failed, "Invalid salary grade.");
            }
        }

        public async Task<IProcessResult<ISalaryGrade>> DeleteAsync(ISalaryGrade data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Delete.SalaryGrade = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<ISalaryGrade>(ProcessResultStatus.Failed, "Invalid salary grade.");
            }
        }

        public IProcessResult<ISalaryGrade> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ISalaryGrade>(StaticSource[id]);
                }
                else
                {
                    r_GetById.SalaryGradeId = id;
                    return AddUpdateIfSuccess(r_GetById.Execute());
                }
            }
            else
            {
                return new ProcessResult<ISalaryGrade>(ProcessResultStatus.Failed, "Invalid salary grade identifier.");
            }
        }

        public async Task<IProcessResult<ISalaryGrade>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ISalaryGrade>(StaticSource[id]);
                }
                else
                {
                    r_GetById.SalaryGradeId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<ISalaryGrade>(ProcessResultStatus.Failed, "Invalid salary grade identifier.");
            }
        }

        public async Task<IProcessResult<ISalaryGrade>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ISalaryGrade>(StaticSource[id]);
                }
                else
                {
                    r_GetById.SalaryGradeId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return new ProcessResult<ISalaryGrade>(ProcessResultStatus.Failed, "Invalid salary grade identifier.");
            }
        }

        public IEnumerableProcessResult<ISalaryGrade> GetList()
        {
            return AddUpdateIfSuccess(r_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<ISalaryGrade>> GetListAsync()
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<ISalaryGrade>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync(cancellationToken));
        }

        public IProcessResult<ISalaryGrade> Insert(ISalaryGrade data)
        {
            if (data != null)
            {
                r_Insert.SalaryGrade = data;
                return AddIfSuccess(r_Insert.Execute());
            }
            else
            {
                return new ProcessResult<ISalaryGrade>(ProcessResultStatus.Failed, "Invalid salary grade.");
            }
        }

        public async Task<IProcessResult<ISalaryGrade>> InsertAsync(ISalaryGrade data)
        {
            if (data != null)
            {
                r_Insert.SalaryGrade = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<ISalaryGrade>(ProcessResultStatus.Failed, "Invalid salary grade.");
            }
        }

        public async Task<IProcessResult<ISalaryGrade>> InsertAsync(ISalaryGrade data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Insert.SalaryGrade = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<ISalaryGrade>(ProcessResultStatus.Failed, "Invalid salary grade.");
            }
        }

        public IProcessResult<ISalaryGrade> Update(ISalaryGrade data)
        {
            if (data != null)
            {
                r_Update.SalaryGrade = data;
                return UpdateIfSuccess(r_Update.Execute());
            }
            else
            {
                return new ProcessResult<ISalaryGrade>(ProcessResultStatus.Failed, "Invalid salary grade.");
            }
        }

        public async Task<IProcessResult<ISalaryGrade>> UpdateAsync(ISalaryGrade data)
        {
            if (data != null)
            {
                r_Update.SalaryGrade = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<ISalaryGrade>(ProcessResultStatus.Failed, "Invalid salary grade.");
            }
        }

        public async Task<IProcessResult<ISalaryGrade>> UpdateAsync(ISalaryGrade data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Update.SalaryGrade = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<ISalaryGrade>(ProcessResultStatus.Failed, "Invalid salary grade.");
            }
        }
    }
}
