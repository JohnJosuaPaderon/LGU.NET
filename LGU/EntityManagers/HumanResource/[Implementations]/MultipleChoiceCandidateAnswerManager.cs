using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class MultipleChoiceCandidateAnswerManager : ManagerBase<MultipleChoiceCandidateAnswer, long>, IMultipleChoiceCandidateAnswerManager
    {
        private readonly IDeleteMultipleChoiceCandidateAnswer r_DeleteMultipleChoiceCandidateAnswer;
        private readonly IGetMultipleChoiceCandidateAnswerById r_GetMultipleChoiceCandidateAnswerById;
        private readonly IGetMultipleChoiceCandidateAnswerList r_GetMultipleChoiceCandidateAnswerList;
        private readonly IInsertMultipleChoiceCandidateAnswer r_InsertMultipleChoiceCandidateAnswer;
        private readonly IUpdateMultipleChoiceCandidateAnswer r_UpdateMultipleChoiceCandidateAnswer;

        public MultipleChoiceCandidateAnswerManager(
            IDeleteMultipleChoiceCandidateAnswer deleteMultipleChoiceCandidateAnswer,
            IGetMultipleChoiceCandidateAnswerById getMultipleChoiceCandidateAnswerById,
            IGetMultipleChoiceCandidateAnswerList getMultipleChoiceCandidateAnswerList,
            IInsertMultipleChoiceCandidateAnswer insertMultipleChoiceCandidateAnswer,
            IUpdateMultipleChoiceCandidateAnswer updateMultipleChoiceCandidateAnswer)
        {
            r_DeleteMultipleChoiceCandidateAnswer = deleteMultipleChoiceCandidateAnswer;
            r_GetMultipleChoiceCandidateAnswerById = getMultipleChoiceCandidateAnswerById;
            r_GetMultipleChoiceCandidateAnswerList = getMultipleChoiceCandidateAnswerList;
            r_InsertMultipleChoiceCandidateAnswer = insertMultipleChoiceCandidateAnswer;
            r_UpdateMultipleChoiceCandidateAnswer = updateMultipleChoiceCandidateAnswer;
        }

        public IProcessResult<MultipleChoiceCandidateAnswer> Delete(MultipleChoiceCandidateAnswer data)
        {
            if (data != null)
            {
                r_DeleteMultipleChoiceCandidateAnswer.MultipleChoiceCandidateAnswer = data;
                var result = r_DeleteMultipleChoiceCandidateAnswer.Execute();
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<MultipleChoiceCandidateAnswer>(ProcessResultStatus.Failed, "Invalid multiple choice candidate answer.");
            }
        }

        public async Task<IProcessResult<MultipleChoiceCandidateAnswer>> DeleteAsync(MultipleChoiceCandidateAnswer data)
        {
            if (data != null)
            {
                r_DeleteMultipleChoiceCandidateAnswer.MultipleChoiceCandidateAnswer = data;
                var result = await r_DeleteMultipleChoiceCandidateAnswer.ExecuteAsync();
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<MultipleChoiceCandidateAnswer>(ProcessResultStatus.Failed, "Invalid multiple choice candidate answer.");
            }
        }

        public async Task<IProcessResult<MultipleChoiceCandidateAnswer>> DeleteAsync(MultipleChoiceCandidateAnswer data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_DeleteMultipleChoiceCandidateAnswer.MultipleChoiceCandidateAnswer = data;
                var result = await r_DeleteMultipleChoiceCandidateAnswer.ExecuteAsync(cancellationToken);
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<MultipleChoiceCandidateAnswer>(ProcessResultStatus.Failed, "Invalid multiple choice candidate answer.");
            }
        }

        public IProcessResult<MultipleChoiceCandidateAnswer> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<MultipleChoiceCandidateAnswer>(StaticSource[id]);
                }
                else
                {
                    r_GetMultipleChoiceCandidateAnswerById.MultipleChoiceCandidateAnswerId = id;
                    var result = r_GetMultipleChoiceCandidateAnswerById.Execute();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<MultipleChoiceCandidateAnswer>(ProcessResultStatus.Failed, "Invalid multiple choice candidate answer identifier.");
            }
        }

        public async Task<IProcessResult<MultipleChoiceCandidateAnswer>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<MultipleChoiceCandidateAnswer>(StaticSource[id]);
                }
                else
                {
                    r_GetMultipleChoiceCandidateAnswerById.MultipleChoiceCandidateAnswerId = id;
                    var result = await r_GetMultipleChoiceCandidateAnswerById.ExecuteAsync();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<MultipleChoiceCandidateAnswer>(ProcessResultStatus.Failed, "Invalid multiple choice candidate answer identifier.");
            }
        }

        public async Task<IProcessResult<MultipleChoiceCandidateAnswer>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<MultipleChoiceCandidateAnswer>(StaticSource[id]);
                }
                else
                {
                    r_GetMultipleChoiceCandidateAnswerById.MultipleChoiceCandidateAnswerId = id;
                    var result = await r_GetMultipleChoiceCandidateAnswerById.ExecuteAsync(cancellationToken);
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<MultipleChoiceCandidateAnswer>(ProcessResultStatus.Failed, "Invalid multiple choice candidate answer identifier.");
            }
        }

        public IEnumerableProcessResult<MultipleChoiceCandidateAnswer> GetList()
        {
            var result = r_GetMultipleChoiceCandidateAnswerList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<MultipleChoiceCandidateAnswer>> GetListAsync()
        {
            var result = await r_GetMultipleChoiceCandidateAnswerList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<MultipleChoiceCandidateAnswer>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetMultipleChoiceCandidateAnswerList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }

        public IProcessResult<MultipleChoiceCandidateAnswer> Insert(MultipleChoiceCandidateAnswer data)
        {
            if (data != null)
            {
                r_InsertMultipleChoiceCandidateAnswer.MultipleChoiceCandidateAnswer = data;
                var result = r_InsertMultipleChoiceCandidateAnswer.Execute();
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<MultipleChoiceCandidateAnswer>(ProcessResultStatus.Failed, "Invalid multiple choice candidate answer.");
            }
        }

        public async Task<IProcessResult<MultipleChoiceCandidateAnswer>> InsertAsync(MultipleChoiceCandidateAnswer data)
        {
            if (data != null)
            {
                r_InsertMultipleChoiceCandidateAnswer.MultipleChoiceCandidateAnswer = data;
                var result = await r_InsertMultipleChoiceCandidateAnswer.ExecuteAsync();
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<MultipleChoiceCandidateAnswer>(ProcessResultStatus.Failed, "Invalid multiple choice candidate answer.");
            }
        }

        public async Task<IProcessResult<MultipleChoiceCandidateAnswer>> InsertAsync(MultipleChoiceCandidateAnswer data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_InsertMultipleChoiceCandidateAnswer.MultipleChoiceCandidateAnswer = data;
                var result = await r_InsertMultipleChoiceCandidateAnswer.ExecuteAsync(cancellationToken);
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<MultipleChoiceCandidateAnswer>(ProcessResultStatus.Failed, "Invalid multiple choice candidate answer.");
            }
        }

        public IProcessResult<MultipleChoiceCandidateAnswer> Update(MultipleChoiceCandidateAnswer data)
        {
            if (data != null)
            {
                r_UpdateMultipleChoiceCandidateAnswer.MultipleChoiceCandidateAnswer = data;
                var result = r_UpdateMultipleChoiceCandidateAnswer.Execute();
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<MultipleChoiceCandidateAnswer>(ProcessResultStatus.Failed, "Invalid multiple choice candidate answer.");
            }
        }

        public async Task<IProcessResult<MultipleChoiceCandidateAnswer>> UpdateAsync(MultipleChoiceCandidateAnswer data)
        {
            if (data != null)
            {
                r_UpdateMultipleChoiceCandidateAnswer.MultipleChoiceCandidateAnswer = data;
                var result = await r_UpdateMultipleChoiceCandidateAnswer.ExecuteAsync();
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<MultipleChoiceCandidateAnswer>(ProcessResultStatus.Failed, "Invalid multiple choice candidate answer.");
            }
        }

        public async Task<IProcessResult<MultipleChoiceCandidateAnswer>> UpdateAsync(MultipleChoiceCandidateAnswer data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_UpdateMultipleChoiceCandidateAnswer.MultipleChoiceCandidateAnswer = data;
                var result = await r_UpdateMultipleChoiceCandidateAnswer.ExecuteAsync(cancellationToken);
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<MultipleChoiceCandidateAnswer>(ProcessResultStatus.Failed, "Invalid multiple choice candidate answer.");
            }
        }
    }
}
