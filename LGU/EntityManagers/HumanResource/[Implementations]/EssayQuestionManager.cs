using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class EssayQuestionManager : EntityManagerBase<IEssayQuestion, long>, IEssayQuestionManager
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

        public IProcessResult<IEssayQuestion> Delete(IEssayQuestion data)
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
                return new ProcessResult<IEssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question.");
            }
        }

        public async Task<IProcessResult<IEssayQuestion>> DeleteAsync(IEssayQuestion data)
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
                return new ProcessResult<IEssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question.");
            }
        }

        public async Task<IProcessResult<IEssayQuestion>> DeleteAsync(IEssayQuestion data, CancellationToken cancellationToken)
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
                return new ProcessResult<IEssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question.");
            }
        }

        public IProcessResult<IEssayQuestion> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IEssayQuestion>(StaticSource[id]);
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
                return new ProcessResult<IEssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question identifier.");
            }
        }

        public async Task<IProcessResult<IEssayQuestion>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IEssayQuestion>(StaticSource[id]);
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
                return new ProcessResult<IEssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question identifier.");
            }
        }

        public async Task<IProcessResult<IEssayQuestion>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IEssayQuestion>(StaticSource[id]);
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
                return new ProcessResult<IEssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question identifier.");
            }
        }

        public IEnumerableProcessResult<IEssayQuestion> GetList()
        {
            var result = r_GetEssayQuestionList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<IEssayQuestion>> GetListAsync()
        {
            var result = await r_GetEssayQuestionList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<IEssayQuestion>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetEssayQuestionList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }

        public IProcessResult<IEssayQuestion> Insert(IEssayQuestion data)
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
                return new ProcessResult<IEssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question.");
            }
        }

        public async Task<IProcessResult<IEssayQuestion>> InsertAsync(IEssayQuestion data)
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
                return new ProcessResult<IEssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question.");
            }
        }

        public async Task<IProcessResult<IEssayQuestion>> InsertAsync(IEssayQuestion data, CancellationToken cancellationToken)
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
                return new ProcessResult<IEssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question.");
            }
        }

        public IProcessResult<IEssayQuestion> Update(IEssayQuestion data)
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
                return new ProcessResult<IEssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question.");
            }
        }

        public async Task<IProcessResult<IEssayQuestion>> UpdateAsync(IEssayQuestion data)
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
                return new ProcessResult<IEssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question.");
            }
        }

        public async Task<IProcessResult<IEssayQuestion>> UpdateAsync(IEssayQuestion data, CancellationToken cancellationToken)
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
                return new ProcessResult<IEssayQuestion>(ProcessResultStatus.Failed, "Invalid essay question.");
            }
        }
    }
}
