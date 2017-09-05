using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class EmployeeSalaryGradeStepManager : IEmployeeSalaryGradeStepManager
    {
        public EmployeeSalaryGradeStepManager(
            IDeleteEmployeeSalaryGradeStep delete,
            IGetEmployeeSalaryGradeStepList getList,
            IInsertEmployeeSalaryGradeStep insert,
            IUpdateEmployeeSalaryGradeStep update)
        {
            r_Delete = delete;
            r_GetList = getList;
            r_Insert = insert;
            r_Update = update;
        }

        private readonly IDeleteEmployeeSalaryGradeStep r_Delete;
        private readonly IGetEmployeeSalaryGradeStepList r_GetList;
        private readonly IInsertEmployeeSalaryGradeStep r_Insert;
        private readonly IUpdateEmployeeSalaryGradeStep r_Update;

        public IProcessResult<IEmployeeSalaryGradeStep> Delete(IEmployeeSalaryGradeStep data)
        {
            if (data != null)
            {
                r_Delete.EmployeeSalaryGradeStep = data;
                return r_Delete.Execute();
            }
            else
            {
                return new ProcessResult<IEmployeeSalaryGradeStep>(ProcessResultStatus.Failed, "Invalid employee salary grade step.");
            }
        }

        public async Task<IProcessResult<IEmployeeSalaryGradeStep>> DeleteAsync(IEmployeeSalaryGradeStep data)
        {
            if (data != null)
            {
                r_Delete.EmployeeSalaryGradeStep = data;
                return await r_Delete.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<IEmployeeSalaryGradeStep>(ProcessResultStatus.Failed, "Invalid employee salary grade step.");
            }
        }

        public async Task<IProcessResult<IEmployeeSalaryGradeStep>> DeleteAsync(IEmployeeSalaryGradeStep data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Delete.EmployeeSalaryGradeStep = data;
                return await r_Delete.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<IEmployeeSalaryGradeStep>(ProcessResultStatus.Failed, "Invalid employee salary grade step.");
            }
        }

        public IEnumerableProcessResult<IEmployeeSalaryGradeStep> GetList()
        {
            return r_GetList.Execute();
        }

        public async Task<IEnumerableProcessResult<IEmployeeSalaryGradeStep>> GetListAsync()
        {
            return await r_GetList.ExecuteAsync();
        }

        public async Task<IEnumerableProcessResult<IEmployeeSalaryGradeStep>> GetListAsync(CancellationToken cancellationToken)
        {
            return await r_GetList.ExecuteAsync(cancellationToken);
        }

        public IProcessResult<IEmployeeSalaryGradeStep> Insert(IEmployeeSalaryGradeStep data)
        {
            if (data != null)
            {
                r_Insert.EmployeeSalaryGradeStep = data;
                return r_Insert.Execute();
            }
            else
            {
                return new ProcessResult<IEmployeeSalaryGradeStep>(ProcessResultStatus.Failed, "Invalid employee salary grade step.");
            }
        }

        public async Task<IProcessResult<IEmployeeSalaryGradeStep>> InsertAsync(IEmployeeSalaryGradeStep data)
        {
            if (data != null)
            {
                r_Insert.EmployeeSalaryGradeStep = data;
                return await r_Insert.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<IEmployeeSalaryGradeStep>(ProcessResultStatus.Failed, "Invalid employee salary grade step.");
            }
        }

        public async Task<IProcessResult<IEmployeeSalaryGradeStep>> InsertAsync(IEmployeeSalaryGradeStep data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Insert.EmployeeSalaryGradeStep = data;
                return await r_Insert.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<IEmployeeSalaryGradeStep>(ProcessResultStatus.Failed, "Invalid employee salary grade step.");
            }
        }

        public IProcessResult<IEmployeeSalaryGradeStep> Update(IEmployeeSalaryGradeStep data)
        {
            if (data != null)
            {
                r_Update.EmployeeSalaryGradeStep = data;
                return r_Update.Execute();
;           }
            else
            {
                return new ProcessResult<IEmployeeSalaryGradeStep>(ProcessResultStatus.Failed, "Invalid employee salary grade step.");
            }
        }

        public async Task<IProcessResult<IEmployeeSalaryGradeStep>> UpdateAsync(IEmployeeSalaryGradeStep data)
        {
            if (data != null)
            {
                r_Update.EmployeeSalaryGradeStep = data;
                return await r_Update.ExecuteAsync();
                ;
            }
            else
            {
                return new ProcessResult<IEmployeeSalaryGradeStep>(ProcessResultStatus.Failed, "Invalid employee salary grade step.");
            }
        }

        public async Task<IProcessResult<IEmployeeSalaryGradeStep>> UpdateAsync(IEmployeeSalaryGradeStep data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Update.EmployeeSalaryGradeStep = data;
                return await r_Update.ExecuteAsync(cancellationToken);
                ;
            }
            else
            {
                return new ProcessResult<IEmployeeSalaryGradeStep>(ProcessResultStatus.Failed, "Invalid employee salary grade step.");
            }
        }
    }
}
