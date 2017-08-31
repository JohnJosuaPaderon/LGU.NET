using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class SalaryGradeStepManager : ManagerBase<ISalaryGradeStep, long>, ISalaryGradeStepManager
    {
        private readonly IDeleteSalaryGradeStep r_Delete;
        private readonly IGetSalaryGradeStepById r_GetById;
        private readonly IGetSalaryGradeStepList r_GetList;
        private readonly IInsertSalaryGradeStep r_Insert;
        private readonly IUpdateSalaryGradeStep r_Update;
        private readonly IGetSalaryGradeStepListBySalaryGrade r_GetListBySalaryGrade;

        public SalaryGradeStepManager(
            IDeleteSalaryGradeStep delete,
            IGetSalaryGradeStepById getById,
            IGetSalaryGradeStepList getList,
            IInsertSalaryGradeStep insert,
            IUpdateSalaryGradeStep update,
            IGetSalaryGradeStepListBySalaryGrade getListBySalaryGrade)
        {
            r_Delete = delete;
            r_GetById = getById;
            r_GetList = getList;
            r_Insert = insert;
            r_Update = update;
            r_GetListBySalaryGrade = getListBySalaryGrade;
        }

        public IProcessResult<ISalaryGradeStep> Delete(ISalaryGradeStep data)
        {
            if (data != null)
            {
                r_Delete.SalaryGradeStep = data;
                return RemoveIfSuccess(r_Delete.Execute());
            }
            else
            {
                return new ProcessResult<ISalaryGradeStep>(ProcessResultStatus.Failed, "Invalid salary grade step.");
            }
        }

        public async Task<IProcessResult<ISalaryGradeStep>> DeleteAsync(ISalaryGradeStep data)
        {
            if (data != null)
            {
                r_Delete.SalaryGradeStep = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<ISalaryGradeStep>(ProcessResultStatus.Failed, "Invalid salary grade step.");
            }
        }

        public async Task<IProcessResult<ISalaryGradeStep>> DeleteAsync(ISalaryGradeStep data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Delete.SalaryGradeStep = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<ISalaryGradeStep>(ProcessResultStatus.Failed, "Invalid salary grade step.");
            }
        }

        public IProcessResult<ISalaryGradeStep> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ISalaryGradeStep>(StaticSource[id]);
                }
                else
                {
                    r_GetById.SalaryGradeStepId = id;
                    return AddUpdateIfSuccess(r_GetById.Execute());
                }
            }
            else
            {
                return new ProcessResult<ISalaryGradeStep>(ProcessResultStatus.Failed, "Invalid salary grade step identifier.");
            }
        }

        public async Task<IProcessResult<ISalaryGradeStep>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ISalaryGradeStep>(StaticSource[id]);
                }
                else
                {
                    r_GetById.SalaryGradeStepId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<ISalaryGradeStep>(ProcessResultStatus.Failed, "Invalid salary grade step identifier.");
            }
        }

        public async Task<IProcessResult<ISalaryGradeStep>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ISalaryGradeStep>(StaticSource[id]);
                }
                else
                {
                    r_GetById.SalaryGradeStepId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return new ProcessResult<ISalaryGradeStep>(ProcessResultStatus.Failed, "Invalid salary grade step identifier.");
            }
        }

        public IEnumerableProcessResult<ISalaryGradeStep> GetList()
        {
            return AddUpdateIfSuccess(r_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<ISalaryGradeStep>> GetListAsync()
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<ISalaryGradeStep>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync(cancellationToken));
        }

        public IEnumerableProcessResult<ISalaryGradeStep> GetListBySalaryGrade(ISalaryGrade salaryGrade)
        {
            if (salaryGrade != null)
            {
                r_GetListBySalaryGrade.SalaryGrade = salaryGrade;
                return AddUpdateIfSuccess(r_GetListBySalaryGrade.Execute());
            }
            else
            {
                return new EnumerableProcessResult<ISalaryGradeStep>(ProcessResultStatus.Failed, "Invalid salary grade.");
            }
        }

        public async Task<IEnumerableProcessResult<ISalaryGradeStep>> GetListBySalaryGradeAsync(ISalaryGrade salaryGrade)
        {
            if (salaryGrade != null)
            {
                r_GetListBySalaryGrade.SalaryGrade = salaryGrade;
                return AddUpdateIfSuccess(await r_GetListBySalaryGrade.ExecuteAsync());
            }
            else
            {
                return new EnumerableProcessResult<ISalaryGradeStep>(ProcessResultStatus.Failed, "Invalid salary grade.");
            }
        }

        public async Task<IEnumerableProcessResult<ISalaryGradeStep>> GetListBySalaryGradeAsync(ISalaryGrade salaryGrade, CancellationToken cancellationToken)
        {
            if (salaryGrade != null)
            {
                r_GetListBySalaryGrade.SalaryGrade = salaryGrade;
                return AddUpdateIfSuccess(await r_GetListBySalaryGrade.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new EnumerableProcessResult<ISalaryGradeStep>(ProcessResultStatus.Failed, "Invalid salary grade.");
            }
        }

        public IProcessResult<ISalaryGradeStep> Insert(ISalaryGradeStep data)
        {
            if (data != null)
            {
                r_Insert.SalaryGradeStep = data;
                return AddIfSuccess(r_Insert.Execute());
            }
            else
            {
                return new ProcessResult<ISalaryGradeStep>(ProcessResultStatus.Failed, "Invalid salary grade step.");
            }
        }

        public async Task<IProcessResult<ISalaryGradeStep>> InsertAsync(ISalaryGradeStep data)
        {
            if (data != null)
            {
                r_Insert.SalaryGradeStep = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<ISalaryGradeStep>(ProcessResultStatus.Failed, "Invalid salary grade step.");
            }
        }

        public async Task<IProcessResult<ISalaryGradeStep>> InsertAsync(ISalaryGradeStep data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Insert.SalaryGradeStep = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<ISalaryGradeStep>(ProcessResultStatus.Failed, "Invalid salary grade step.");
            }
        }

        public IProcessResult<ISalaryGradeStep> Update(ISalaryGradeStep data)
        {
            if (data != null)
            {
                r_Update.SalaryGradeStep = data;
                return UpdateIfSuccess(r_Update.Execute());
            }
            else
            {
                return new ProcessResult<ISalaryGradeStep>(ProcessResultStatus.Failed, "Invalid salary grade step.");
            }
        }

        public async Task<IProcessResult<ISalaryGradeStep>> UpdateAsync(ISalaryGradeStep data)
        {
            if (data != null)
            {
                r_Update.SalaryGradeStep = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<ISalaryGradeStep>(ProcessResultStatus.Failed, "Invalid salary grade step.");
            }
        }

        public async Task<IProcessResult<ISalaryGradeStep>> UpdateAsync(ISalaryGradeStep data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Update.SalaryGradeStep = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<ISalaryGradeStep>(ProcessResultStatus.Failed, "Invalid salary grade step.");
            }
        }
    }
}
