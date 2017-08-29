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

        public IProcessResult<IExamMultipleChoiceAnswer> Delete(IExamMultipleChoiceAnswer data)
        {
            if (data != null)
            {
                r_DeleteExamMultipleChoiceAnswer.ExamMultipleChoiceAnswer = data;
                return r_DeleteExamMultipleChoiceAnswer.Execute();
            }
            else
            {
                return new ProcessResult<IExamMultipleChoiceAnswer>(ProcessResultStatus.Failed, "Invalid exam multiple choice answer.");
            }
        }

        public async Task<IProcessResult<IExamMultipleChoiceAnswer>> DeleteAsync(IExamMultipleChoiceAnswer data)
        {
            if (data != null)
            {
                r_DeleteExamMultipleChoiceAnswer.ExamMultipleChoiceAnswer = data;
                return await r_DeleteExamMultipleChoiceAnswer.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<IExamMultipleChoiceAnswer>(ProcessResultStatus.Failed, "Invalid exam multiple choice answer.");
            }
        }

        public async Task<IProcessResult<IExamMultipleChoiceAnswer>> DeleteAsync(IExamMultipleChoiceAnswer data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_DeleteExamMultipleChoiceAnswer.ExamMultipleChoiceAnswer = data;
                return await r_DeleteExamMultipleChoiceAnswer.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<IExamMultipleChoiceAnswer>(ProcessResultStatus.Failed, "Invalid exam multiple choice answer.");
            }
        }

        public IEnumerableProcessResult<IExamMultipleChoiceAnswer> GetList()
        {
            return r_GetExamMultipleChoiceAnswerList.Execute();
        }

        public Task<IEnumerableProcessResult<IExamMultipleChoiceAnswer>> GetListAsync()
        {
            return r_GetExamMultipleChoiceAnswerList.ExecuteAsync();
        }

        public Task<IEnumerableProcessResult<IExamMultipleChoiceAnswer>> GetListAsync(CancellationToken cancellationToken)
        {
            return r_GetExamMultipleChoiceAnswerList.ExecuteAsync(cancellationToken);
        }

        public IProcessResult<IExamMultipleChoiceAnswer> Insert(IExamMultipleChoiceAnswer data)
        {
            if (data != null)
            {
                r_InsertExamMultipleChoiceAnswer.ExamMultipleChoiceAnswer = data;
                return r_InsertExamMultipleChoiceAnswer.Execute();
            }
            else
            {
                return new ProcessResult<IExamMultipleChoiceAnswer>(ProcessResultStatus.Failed, "Invalid exam multiple choice answer.");
            }
        }

        public async Task<IProcessResult<IExamMultipleChoiceAnswer>> InsertAsync(IExamMultipleChoiceAnswer data)
        {
            if (data != null)
            {
                r_InsertExamMultipleChoiceAnswer.ExamMultipleChoiceAnswer = data;
                return await r_InsertExamMultipleChoiceAnswer.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<IExamMultipleChoiceAnswer>(ProcessResultStatus.Failed, "Invalid exam multiple choice answer.");
            }
        }

        public async Task<IProcessResult<IExamMultipleChoiceAnswer>> InsertAsync(IExamMultipleChoiceAnswer data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_InsertExamMultipleChoiceAnswer.ExamMultipleChoiceAnswer = data;
                return await r_InsertExamMultipleChoiceAnswer.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<IExamMultipleChoiceAnswer>(ProcessResultStatus.Failed, "Invalid exam multiple choice answer.");
            }
        }

        public IProcessResult<IExamMultipleChoiceAnswer> Update(IExamMultipleChoiceAnswer data)
        {
            if (data != null)
            {
                r_UpdateExamMultipleChoiceAnswer.ExamMultipleChoiceAnswer = data;
                return r_UpdateExamMultipleChoiceAnswer.Execute();
            }
            else
            {
                return new ProcessResult<IExamMultipleChoiceAnswer>(ProcessResultStatus.Failed, "Invalid exam multiple choice answer.");
            }
        }

        public async Task<IProcessResult<IExamMultipleChoiceAnswer>> UpdateAsync(IExamMultipleChoiceAnswer data)
        {
            if (data != null)
            {
                r_UpdateExamMultipleChoiceAnswer.ExamMultipleChoiceAnswer = data;
                return await r_UpdateExamMultipleChoiceAnswer.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<IExamMultipleChoiceAnswer>(ProcessResultStatus.Failed, "Invalid exam multiple choice answer.");
            }
        }

        public async Task<IProcessResult<IExamMultipleChoiceAnswer>> UpdateAsync(IExamMultipleChoiceAnswer data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_UpdateExamMultipleChoiceAnswer.ExamMultipleChoiceAnswer = data;
                return await r_UpdateExamMultipleChoiceAnswer.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<IExamMultipleChoiceAnswer>(ProcessResultStatus.Failed, "Invalid exam multiple choice answer.");
            }
        }
    }
}
