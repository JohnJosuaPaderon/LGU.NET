using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class ExamEssayAnswerManager : IExamEssayAnswerManager
    {
        private readonly IDeleteExamEssayAnswer r_DeleteExamEssayAnswer;
        private readonly IGetExamEssayAnswerList r_GetExamEssayAnswerList;
        private readonly IInsertExamEssayAnswer r_InsertExamEssayAnswer;
        private readonly IUpdateExamEssayAnswer r_UpdateExamEssayAnswer;

        public ExamEssayAnswerManager(
            IDeleteExamEssayAnswer deleteExamEssayAnswer,
            IGetExamEssayAnswerList getExamEssayAnswerList,
            IInsertExamEssayAnswer insertExamEssayAnswer,
            IUpdateExamEssayAnswer updateExamEssayAnswer)
        {
            r_DeleteExamEssayAnswer = deleteExamEssayAnswer;
            r_GetExamEssayAnswerList = getExamEssayAnswerList;
            r_InsertExamEssayAnswer = insertExamEssayAnswer;
            r_UpdateExamEssayAnswer = updateExamEssayAnswer;
        }

        public IProcessResult<IExamEssayAnswer> Delete(IExamEssayAnswer data)
        {
            if (data != null)
            {
                r_DeleteExamEssayAnswer.ExamEssayAnswer = data;
                return r_DeleteExamEssayAnswer.Execute();
            }
            else
            {
                return new ProcessResult<IExamEssayAnswer>(ProcessResultStatus.Failed, "Invalid exam essay answer.");
            }
        }

        public async Task<IProcessResult<IExamEssayAnswer>> DeleteAsync(IExamEssayAnswer data)
        {
            if (data != null)
            {
                r_DeleteExamEssayAnswer.ExamEssayAnswer = data;
                return await r_DeleteExamEssayAnswer.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<IExamEssayAnswer>(ProcessResultStatus.Failed, "Invalid exam essay answer.");
            }
        }

        public async Task<IProcessResult<IExamEssayAnswer>> DeleteAsync(IExamEssayAnswer data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_DeleteExamEssayAnswer.ExamEssayAnswer = data;
                return await r_DeleteExamEssayAnswer.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<IExamEssayAnswer>(ProcessResultStatus.Failed, "Invalid exam essay answer.");
            }
        }

        public IEnumerableProcessResult<IExamEssayAnswer> GetList()
        {
            return r_GetExamEssayAnswerList.Execute();
        }

        public Task<IEnumerableProcessResult<IExamEssayAnswer>> GetListAsync()
        {
            return r_GetExamEssayAnswerList.ExecuteAsync();
        }

        public Task<IEnumerableProcessResult<IExamEssayAnswer>> GetListAsync(CancellationToken cancellationToken)
        {
            return r_GetExamEssayAnswerList.ExecuteAsync(cancellationToken);
        }

        public IProcessResult<IExamEssayAnswer> Insert(IExamEssayAnswer data)
        {
            if (data != null)
            {
                r_InsertExamEssayAnswer.ExamEssayAnswer = data;
                return r_InsertExamEssayAnswer.Execute();
            }
            else
            {
                return new ProcessResult<IExamEssayAnswer>(ProcessResultStatus.Failed, "Invalid exam essay answer.");
            }
        }

        public async Task<IProcessResult<IExamEssayAnswer>> InsertAsync(IExamEssayAnswer data)
        {
            if (data != null)
            {
                r_InsertExamEssayAnswer.ExamEssayAnswer = data;
                return await r_InsertExamEssayAnswer.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<IExamEssayAnswer>(ProcessResultStatus.Failed, "Invalid exam essay answer.");
            }
        }

        public async Task<IProcessResult<IExamEssayAnswer>> InsertAsync(IExamEssayAnswer data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_InsertExamEssayAnswer.ExamEssayAnswer = data;
                return await r_InsertExamEssayAnswer.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<IExamEssayAnswer>(ProcessResultStatus.Failed, "Invalid exam essay answer.");
            }
        }

        public IProcessResult<IExamEssayAnswer> Update(IExamEssayAnswer data)
        {
            if (data != null)
            {
                r_UpdateExamEssayAnswer.ExamEssayAnswer = data;
                return r_UpdateExamEssayAnswer.Execute();
            }
            else
            {
                return new ProcessResult<IExamEssayAnswer>(ProcessResultStatus.Failed, "Invalid exam essay answer.");
            }
        }

        public async Task<IProcessResult<IExamEssayAnswer>> UpdateAsync(IExamEssayAnswer data)
        {
            if (data != null)
            {
                r_UpdateExamEssayAnswer.ExamEssayAnswer = data;
                return await r_UpdateExamEssayAnswer.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<IExamEssayAnswer>(ProcessResultStatus.Failed, "Invalid exam essay answer.");
            }
        }

        public async Task<IProcessResult<IExamEssayAnswer>> UpdateAsync(IExamEssayAnswer data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_UpdateExamEssayAnswer.ExamEssayAnswer = data;
                return await r_UpdateExamEssayAnswer.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<IExamEssayAnswer>(ProcessResultStatus.Failed, "Invalid exam essay answer.");
            }
        }
    }
}
