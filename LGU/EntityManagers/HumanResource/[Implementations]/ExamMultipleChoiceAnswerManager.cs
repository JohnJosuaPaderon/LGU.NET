using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class ExamMultipleChoiceAnswerManager : IExamMultipleChoiceAnswerManager
    {
        private readonly IDeleteExamMultipleChoiceAnswer r_DeleteExamMultipleChoiceAnswer;
        private readonly IGetExamMultipleChoiceAnswerList r_GetExamMultipleChoiceAnswerList;
        private readonly IInsertExamMultipleChoiceAnswer r_InsertExamMultipleChoiceAnswer;
        private readonly IUpdateExamMultipleChoiceAnswer r_UpdateExamMultipleChoiceAnswer;

        public ExamMultipleChoiceAnswerManager(
            IDeleteExamMultipleChoiceAnswer deleteExamMultipleChoiceAnswer,
            IGetExamMultipleChoiceAnswerList getExamMultipleChoiceAnswerList,
            IInsertExamMultipleChoiceAnswer insertExamMultipleChoiceAnswer,
            IUpdateExamMultipleChoiceAnswer updateExamMultipleChoiceAnswer)
        {
            r_DeleteExamMultipleChoiceAnswer = deleteExamMultipleChoiceAnswer;
            r_GetExamMultipleChoiceAnswerList = getExamMultipleChoiceAnswerList;
            r_InsertExamMultipleChoiceAnswer = insertExamMultipleChoiceAnswer;
            r_UpdateExamMultipleChoiceAnswer = updateExamMultipleChoiceAnswer;
        }

        public IProcessResult<ExamMultipleChoiceAnswer> Delete(ExamMultipleChoiceAnswer data)
        {
            if (data != null)
            {
                r_DeleteExamMultipleChoiceAnswer.ExamMultipleChoiceAnswer = data;
                return r_DeleteExamMultipleChoiceAnswer.Execute();
            }
            else
            {
                return new ProcessResult<ExamMultipleChoiceAnswer>(ProcessResultStatus.Failed, "Invalid exam multiple choice answer.");
            }
        }

        public async Task<IProcessResult<ExamMultipleChoiceAnswer>> DeleteAsync(ExamMultipleChoiceAnswer data)
        {
            if (data != null)
            {
                r_DeleteExamMultipleChoiceAnswer.ExamMultipleChoiceAnswer = data;
                return await r_DeleteExamMultipleChoiceAnswer.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<ExamMultipleChoiceAnswer>(ProcessResultStatus.Failed, "Invalid exam multiple choice answer.");
            }
        }

        public async Task<IProcessResult<ExamMultipleChoiceAnswer>> DeleteAsync(ExamMultipleChoiceAnswer data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_DeleteExamMultipleChoiceAnswer.ExamMultipleChoiceAnswer = data;
                return await r_DeleteExamMultipleChoiceAnswer.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<ExamMultipleChoiceAnswer>(ProcessResultStatus.Failed, "Invalid exam multiple choice answer.");
            }
        }

        public IEnumerableProcessResult<ExamMultipleChoiceAnswer> GetList()
        {
            return r_GetExamMultipleChoiceAnswerList.Execute();
        }

        public Task<IEnumerableProcessResult<ExamMultipleChoiceAnswer>> GetListAsync()
        {
            return r_GetExamMultipleChoiceAnswerList.ExecuteAsync();
        }

        public Task<IEnumerableProcessResult<ExamMultipleChoiceAnswer>> GetListAsync(CancellationToken cancellationToken)
        {
            return r_GetExamMultipleChoiceAnswerList.ExecuteAsync(cancellationToken);
        }

        public IProcessResult<ExamMultipleChoiceAnswer> Insert(ExamMultipleChoiceAnswer data)
        {
            if (data != null)
            {
                r_InsertExamMultipleChoiceAnswer.ExamMultipleChoiceAnswer = data;
                return r_InsertExamMultipleChoiceAnswer.Execute();
            }
            else
            {
                return new ProcessResult<ExamMultipleChoiceAnswer>(ProcessResultStatus.Failed, "Invalid exam multiple choice answer.");
            }
        }

        public async Task<IProcessResult<ExamMultipleChoiceAnswer>> InsertAsync(ExamMultipleChoiceAnswer data)
        {
            if (data != null)
            {
                r_InsertExamMultipleChoiceAnswer.ExamMultipleChoiceAnswer = data;
                return await r_InsertExamMultipleChoiceAnswer.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<ExamMultipleChoiceAnswer>(ProcessResultStatus.Failed, "Invalid exam multiple choice answer.");
            }
        }

        public async Task<IProcessResult<ExamMultipleChoiceAnswer>> InsertAsync(ExamMultipleChoiceAnswer data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_InsertExamMultipleChoiceAnswer.ExamMultipleChoiceAnswer = data;
                return await r_InsertExamMultipleChoiceAnswer.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<ExamMultipleChoiceAnswer>(ProcessResultStatus.Failed, "Invalid exam multiple choice answer.");
            }
        }

        public IProcessResult<ExamMultipleChoiceAnswer> Update(ExamMultipleChoiceAnswer data)
        {
            if (data != null)
            {
                r_UpdateExamMultipleChoiceAnswer.ExamMultipleChoiceAnswer = data;
                return r_UpdateExamMultipleChoiceAnswer.Execute();
            }
            else
            {
                return new ProcessResult<ExamMultipleChoiceAnswer>(ProcessResultStatus.Failed, "Invalid exam multiple choice answer.");
            }
        }

        public async Task<IProcessResult<ExamMultipleChoiceAnswer>> UpdateAsync(ExamMultipleChoiceAnswer data)
        {
            if (data != null)
            {
                r_UpdateExamMultipleChoiceAnswer.ExamMultipleChoiceAnswer = data;
                return await r_UpdateExamMultipleChoiceAnswer.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<ExamMultipleChoiceAnswer>(ProcessResultStatus.Failed, "Invalid exam multiple choice answer.");
            }
        }

        public async Task<IProcessResult<ExamMultipleChoiceAnswer>> UpdateAsync(ExamMultipleChoiceAnswer data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_UpdateExamMultipleChoiceAnswer.ExamMultipleChoiceAnswer = data;
                return await r_UpdateExamMultipleChoiceAnswer.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<ExamMultipleChoiceAnswer>(ProcessResultStatus.Failed, "Invalid exam multiple choice answer.");
            }
        }
    }
}
