using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class MultipleChoiceQuestionManager : ManagerBase<IMultipleChoiceQuestion, long>, IMultipleChoiceQuestionManager
    {
        private readonly IDeleteMultipleChoiceQuestion r_DeleteMultipleChoiceQuestion;
        private readonly IGetMultipleChoiceQuestionById r_GetMultipleChoiceQuestionById;
        private readonly IGetMultipleChoiceQuestionList r_GetMultipleChoiceQuestionList;
        private readonly IInsertMultipleChoiceQuestion r_InsertMultipleChoiceQuestion;
        private readonly IUpdateMultipleChoiceQuestion r_UpdateMultipleChoiceQuestion;

        public MultipleChoiceQuestionManager(
            IDeleteMultipleChoiceQuestion deleteMultipleChoiceQuestion,
            IGetMultipleChoiceQuestionById getMultipleChoiceQuestionById,
            IGetMultipleChoiceQuestionList getMultipleChoiceQuestionList,
            IInsertMultipleChoiceQuestion insertMultipleChoiceQuestion,
            IUpdateMultipleChoiceQuestion updateMultipleChoiceQuestion)
        {
            r_DeleteMultipleChoiceQuestion = deleteMultipleChoiceQuestion;
            r_GetMultipleChoiceQuestionById = getMultipleChoiceQuestionById;
            r_GetMultipleChoiceQuestionList = getMultipleChoiceQuestionList;
            r_InsertMultipleChoiceQuestion = insertMultipleChoiceQuestion;
            r_UpdateMultipleChoiceQuestion = updateMultipleChoiceQuestion;
        }

        public IProcessResult<IMultipleChoiceQuestion> Delete(IMultipleChoiceQuestion data)
        {
            if (data != null)
            {
                r_DeleteMultipleChoiceQuestion.MultipleChoiceQuestion = data;
                var result = r_DeleteMultipleChoiceQuestion.Execute();
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IMultipleChoiceQuestion>(ProcessResultStatus.Failed, "Invalid multiple choice question.");
            }
        }

        public async Task<IProcessResult<IMultipleChoiceQuestion>> DeleteAsync(IMultipleChoiceQuestion data)
        {
            if (data != null)
            {
                r_DeleteMultipleChoiceQuestion.MultipleChoiceQuestion = data;
                var result = await r_DeleteMultipleChoiceQuestion.ExecuteAsync();
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IMultipleChoiceQuestion>(ProcessResultStatus.Failed, "Invalid multiple choice question.");
            }
        }

        public async Task<IProcessResult<IMultipleChoiceQuestion>> DeleteAsync(IMultipleChoiceQuestion data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_DeleteMultipleChoiceQuestion.MultipleChoiceQuestion = data;
                var result = await r_DeleteMultipleChoiceQuestion.ExecuteAsync(cancellationToken);
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IMultipleChoiceQuestion>(ProcessResultStatus.Failed, "Invalid multiple choice question.");
            }
        }

        public IProcessResult<IMultipleChoiceQuestion> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IMultipleChoiceQuestion>(StaticSource[id]);
                }
                else
                {
                    r_GetMultipleChoiceQuestionById.MultipleChoiceQuestionId = id;
                    var result = r_GetMultipleChoiceQuestionById.Execute();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<IMultipleChoiceQuestion>(ProcessResultStatus.Failed, "Invalid multiple choice question identifier.");
            }
        }

        public async Task<IProcessResult<IMultipleChoiceQuestion>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IMultipleChoiceQuestion>(StaticSource[id]);
                }
                else
                {
                    r_GetMultipleChoiceQuestionById.MultipleChoiceQuestionId = id;
                    var result = await r_GetMultipleChoiceQuestionById.ExecuteAsync();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<IMultipleChoiceQuestion>(ProcessResultStatus.Failed, "Invalid multiple choice question identifier.");
            }
        }

        public async Task<IProcessResult<IMultipleChoiceQuestion>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IMultipleChoiceQuestion>(StaticSource[id]);
                }
                else
                {
                    r_GetMultipleChoiceQuestionById.MultipleChoiceQuestionId = id;
                    var result = await r_GetMultipleChoiceQuestionById.ExecuteAsync(cancellationToken);
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<IMultipleChoiceQuestion>(ProcessResultStatus.Failed, "Invalid multiple choice question identifier.");
            }
        }

        public IEnumerableProcessResult<IMultipleChoiceQuestion> GetList()
        {
            var result = r_GetMultipleChoiceQuestionList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<IMultipleChoiceQuestion>> GetListAsync()
        {
            var result = await r_GetMultipleChoiceQuestionList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<IMultipleChoiceQuestion>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetMultipleChoiceQuestionList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }

        public IProcessResult<IMultipleChoiceQuestion> Insert(IMultipleChoiceQuestion data)
        {
            if (data != null)
            {
                r_InsertMultipleChoiceQuestion.MultipleChoiceQuestion = data;
                var result = r_InsertMultipleChoiceQuestion.Execute();
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IMultipleChoiceQuestion>(ProcessResultStatus.Failed, "Invalid multiple choice question.");
            }
        }

        public async Task<IProcessResult<IMultipleChoiceQuestion>> InsertAsync(IMultipleChoiceQuestion data)
        {
            if (data != null)
            {
                r_InsertMultipleChoiceQuestion.MultipleChoiceQuestion = data;
                var result = await r_InsertMultipleChoiceQuestion.ExecuteAsync();
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IMultipleChoiceQuestion>(ProcessResultStatus.Failed, "Invalid multiple choice question.");
            }
        }

        public async Task<IProcessResult<IMultipleChoiceQuestion>> InsertAsync(IMultipleChoiceQuestion data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_InsertMultipleChoiceQuestion.MultipleChoiceQuestion = data;
                var result = await r_InsertMultipleChoiceQuestion.ExecuteAsync(cancellationToken);
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IMultipleChoiceQuestion>(ProcessResultStatus.Failed, "Invalid multiple choice question.");
            }
        }

        public IProcessResult<IMultipleChoiceQuestion> Update(IMultipleChoiceQuestion data)
        {
            if (data != null)
            {
                r_UpdateMultipleChoiceQuestion.MultipleChoiceQuestion = data;
                var result = r_UpdateMultipleChoiceQuestion.Execute();
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IMultipleChoiceQuestion>(ProcessResultStatus.Failed, "Invalid multiple choice question.");
            }
        }

        public async Task<IProcessResult<IMultipleChoiceQuestion>> UpdateAsync(IMultipleChoiceQuestion data)
        {
            if (data != null)
            {
                r_UpdateMultipleChoiceQuestion.MultipleChoiceQuestion = data;
                var result = await r_UpdateMultipleChoiceQuestion.ExecuteAsync();
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IMultipleChoiceQuestion>(ProcessResultStatus.Failed, "Invalid multiple choice question.");
            }
        }

        public async Task<IProcessResult<IMultipleChoiceQuestion>> UpdateAsync(IMultipleChoiceQuestion data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_UpdateMultipleChoiceQuestion.MultipleChoiceQuestion = data;
                var result = await r_UpdateMultipleChoiceQuestion.ExecuteAsync(cancellationToken);
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IMultipleChoiceQuestion>(ProcessResultStatus.Failed, "Invalid multiple choice question.");
            }
        }
    }
}
