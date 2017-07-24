using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class EssayQuestionManager : ManagerBase<EssayQuestion, long>, IEssayQuestionManager
    {
        private readonly IDeleteEssayQuestion r_DeleteEssayQuestion;
        private readonly IGetEssayQuestionById r_GetEssayQuestionById;
        private readonly IGetEssayQuestionList r_GetEssayQuestionList;
        private readonly IInsertEssayQuestion r_InsertEssayQuestion;
        private readonly IUpdateEssayQuestion r_UpdateEssayQuestion;

        public EssayQuestionManager(
            IDeleteEssayQuestion deleteEssayQuestion,
            IGetEssayQuestionById getEssayQuestionById,
            IGetEssayQuestionList getEssayQuestionList,
            IInsertEssayQuestion insertEssayQuestion,
            IUpdateEssayQuestion updateEssayQuestion)
        {
            r_DeleteEssayQuestion = deleteEssayQuestion;
            r_GetEssayQuestionById = getEssayQuestionById;
            r_GetEssayQuestionList = getEssayQuestionList;
            r_InsertEssayQuestion = insertEssayQuestion;
            r_UpdateEssayQuestion = updateEssayQuestion;
        }

        public IProcessResult<EssayQuestion> Delete(EssayQuestion data)
        {
            if (data != null)
            {
                r_DeleteEssayQuestion.EssayQuestion = data;
                var result = r_DeleteEssayQuestion.Execute();
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<EssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question.");
            }
        }

        public async Task<IProcessResult<EssayQuestion>> DeleteAsync(EssayQuestion data)
        {
            if (data != null)
            {
                r_DeleteEssayQuestion.EssayQuestion = data;
                var result = await r_DeleteEssayQuestion.ExecuteAsync();
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<EssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question.");
            }
        }

        public async Task<IProcessResult<EssayQuestion>> DeleteAsync(EssayQuestion data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_DeleteEssayQuestion.EssayQuestion = data;
                var result = await r_DeleteEssayQuestion.ExecuteAsync(cancellationToken);
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<EssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question.");
            }
        }

        public IProcessResult<EssayQuestion> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<EssayQuestion>(StaticSource[id]);
                }
                else
                {
                    r_GetEssayQuestionById.EssayQuestionId = id;
                    var result = r_GetEssayQuestionById.Execute();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<EssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question identifier.");
            }
        }

        public async Task<IProcessResult<EssayQuestion>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<EssayQuestion>(StaticSource[id]);
                }
                else
                {
                    r_GetEssayQuestionById.EssayQuestionId = id;
                    var result = await r_GetEssayQuestionById.ExecuteAsync();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<EssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question identifier.");
            }
        }

        public async Task<IProcessResult<EssayQuestion>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<EssayQuestion>(StaticSource[id]);
                }
                else
                {
                    r_GetEssayQuestionById.EssayQuestionId = id;
                    var result = await r_GetEssayQuestionById.ExecuteAsync(cancellationToken);
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<EssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question identifier.");
            }
        }

        public IEnumerableProcessResult<EssayQuestion> GetList()
        {
            var result = r_GetEssayQuestionList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<EssayQuestion>> GetListAsync()
        {
            var result = await r_GetEssayQuestionList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<EssayQuestion>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetEssayQuestionList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }

        public IProcessResult<EssayQuestion> Insert(EssayQuestion data)
        {
            if (data != null)
            {
                r_InsertEssayQuestion.EssayQuestion = data;
                var result = r_InsertEssayQuestion.Execute();
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<EssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question.");
            }
        }

        public async Task<IProcessResult<EssayQuestion>> InsertAsync(EssayQuestion data)
        {
            if (data != null)
            {
                r_InsertEssayQuestion.EssayQuestion = data;
                var result = await r_InsertEssayQuestion.ExecuteAsync();
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<EssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question.");
            }
        }

        public async Task<IProcessResult<EssayQuestion>> InsertAsync(EssayQuestion data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_InsertEssayQuestion.EssayQuestion = data;
                var result = await r_InsertEssayQuestion.ExecuteAsync(cancellationToken);
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<EssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question.");
            }
        }

        public IProcessResult<EssayQuestion> Update(EssayQuestion data)
        {
            if (data != null)
            {
                r_UpdateEssayQuestion.EssayQuestion = data;
                var result = r_UpdateEssayQuestion.Execute();
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<EssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question.");
            }
        }

        public async Task<IProcessResult<EssayQuestion>> UpdateAsync(EssayQuestion data)
        {
            if (data != null)
            {
                r_UpdateEssayQuestion.EssayQuestion = data;
                var result = await r_UpdateEssayQuestion.ExecuteAsync();
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<EssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question.");
            }
        }

        public async Task<IProcessResult<EssayQuestion>> UpdateAsync(EssayQuestion data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_UpdateEssayQuestion.EssayQuestion = data;
                var result = await r_UpdateEssayQuestion.ExecuteAsync(cancellationToken);
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<EssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question.");
            }
        }
    }
}
