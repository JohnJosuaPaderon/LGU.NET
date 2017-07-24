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

        public IProcessResult<ExamEssayAnswer> Delete(ExamEssayAnswer data)
        {
            if (data != null)
            {
                r_DeleteExamEssayAnswer.ExamEssayAnswer = data;
                return r_DeleteExamEssayAnswer.Execute();
            }
            else
            {
                return new ProcessResult<ExamEssayAnswer>(ProcessResultStatus.Failed, "Invalid exam essay answer.");
            }
        }

        public async Task<IProcessResult<ExamEssayAnswer>> DeleteAsync(ExamEssayAnswer data)
        {
            if (data != null)
            {
                r_DeleteExamEssayAnswer.ExamEssayAnswer = data;
                return await r_DeleteExamEssayAnswer.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<ExamEssayAnswer>(ProcessResultStatus.Failed, "Invalid exam essay answer.");
            }
        }

        public async Task<IProcessResult<ExamEssayAnswer>> DeleteAsync(ExamEssayAnswer data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_DeleteExamEssayAnswer.ExamEssayAnswer = data;
                return await r_DeleteExamEssayAnswer.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<ExamEssayAnswer>(ProcessResultStatus.Failed, "Invalid exam essay answer.");
            }
        }

        public IEnumerableProcessResult<ExamEssayAnswer> GetList()
        {
            return r_GetExamEssayAnswerList.Execute();
        }

        public Task<IEnumerableProcessResult<ExamEssayAnswer>> GetListAsync()
        {
            return r_GetExamEssayAnswerList.ExecuteAsync();
        }

        public Task<IEnumerableProcessResult<ExamEssayAnswer>> GetListAsync(CancellationToken cancellationToken)
        {
            return r_GetExamEssayAnswerList.ExecuteAsync(cancellationToken);
        }

        public IProcessResult<ExamEssayAnswer> Insert(ExamEssayAnswer data)
        {
            if (data != null)
            {
                r_InsertExamEssayAnswer.ExamEssayAnswer = data;
                return r_InsertExamEssayAnswer.Execute();
            }
            else
            {
                return new ProcessResult<ExamEssayAnswer>(ProcessResultStatus.Failed, "Invalid exam essay answer.");
            }
        }

        public async Task<IProcessResult<ExamEssayAnswer>> InsertAsync(ExamEssayAnswer data)
        {
            if (data != null)
            {
                r_InsertExamEssayAnswer.ExamEssayAnswer = data;
                return await r_InsertExamEssayAnswer.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<ExamEssayAnswer>(ProcessResultStatus.Failed, "Invalid exam essay answer.");
            }
        }

        public async Task<IProcessResult<ExamEssayAnswer>> InsertAsync(ExamEssayAnswer data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_InsertExamEssayAnswer.ExamEssayAnswer = data;
                return await r_InsertExamEssayAnswer.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<ExamEssayAnswer>(ProcessResultStatus.Failed, "Invalid exam essay answer.");
            }
        }

        public IProcessResult<ExamEssayAnswer> Update(ExamEssayAnswer data)
        {
            if (data != null)
            {
                r_UpdateExamEssayAnswer.ExamEssayAnswer = data;
                return r_UpdateExamEssayAnswer.Execute();
            }
            else
            {
                return new ProcessResult<ExamEssayAnswer>(ProcessResultStatus.Failed, "Invalid exam essay answer.");
            }
        }

        public async Task<IProcessResult<ExamEssayAnswer>> UpdateAsync(ExamEssayAnswer data)
        {
            if (data != null)
            {
                r_UpdateExamEssayAnswer.ExamEssayAnswer = data;
                return await r_UpdateExamEssayAnswer.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<ExamEssayAnswer>(ProcessResultStatus.Failed, "Invalid exam essay answer.");
            }
        }

        public async Task<IProcessResult<ExamEssayAnswer>> UpdateAsync(ExamEssayAnswer data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_UpdateExamEssayAnswer.ExamEssayAnswer = data;
                return await r_UpdateExamEssayAnswer.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<ExamEssayAnswer>(ProcessResultStatus.Failed, "Invalid exam essay answer.");
            }
        }
    }
}
