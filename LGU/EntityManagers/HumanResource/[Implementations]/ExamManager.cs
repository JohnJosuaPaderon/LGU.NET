using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class ExamManager : ManagerBase<Exam, long>, IExamManager
    {
        private readonly IDeleteExam r_DeleteExam;
        private readonly IGetExamById r_GetExamById;
        private readonly IGetExamList r_GetExamList;
        private readonly IInsertExam r_InsertExam;
        private readonly IUpdateExam r_UpdateExam;

        public ExamManager(
            IDeleteExam deleteExam,
            IGetExamById getExamById,
            IGetExamList getExamList,
            IInsertExam insertExam,
            IUpdateExam updateExam)
        {
            r_DeleteExam = deleteExam;
            r_GetExamById = getExamById;
            r_GetExamList = getExamList;
            r_InsertExam = insertExam;
            r_UpdateExam = updateExam;
        }

        public IProcessResult<Exam> Delete(Exam data)
        {
            if (data != null)
            {
                r_DeleteExam.Exam = data;
                var result = r_DeleteExam.Execute();
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Exam>(ProcessResultStatus.Failed, "Invalid exam.");
            }
        }

        public async Task<IProcessResult<Exam>> DeleteAsync(Exam data)
        {
            if (data != null)
            {
                r_DeleteExam.Exam = data;
                var result = await r_DeleteExam.ExecuteAsync();
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Exam>(ProcessResultStatus.Failed, "Invalid exam.");
            }
        }

        public async Task<IProcessResult<Exam>> DeleteAsync(Exam data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_DeleteExam.Exam = data;
                var result = await r_DeleteExam.ExecuteAsync(cancellationToken);
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Exam>(ProcessResultStatus.Failed, "Invalid exam.");
            }
        }

        public IProcessResult<Exam> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Exam>(StaticSource[id]);
                }
                else
                {
                    r_GetExamById.ExamId = id;
                    var result = r_GetExamById.Execute();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<Exam>(ProcessResultStatus.Failed, "Invalid exam identifier.");
            }
        }

        public async Task<IProcessResult<Exam>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Exam>(StaticSource[id]);
                }
                else
                {
                    r_GetExamById.ExamId = id;
                    var result = await r_GetExamById.ExecuteAsync();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<Exam>(ProcessResultStatus.Failed, "Invalid exam identifier.");
            }
        }

        public async Task<IProcessResult<Exam>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Exam>(StaticSource[id]);
                }
                else
                {
                    r_GetExamById.ExamId = id;
                    var result = await r_GetExamById.ExecuteAsync(cancellationToken);
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<Exam>(ProcessResultStatus.Failed, "Invalid exam identifier.");
            }
        }

        public IEnumerableProcessResult<Exam> GetList()
        {
            var result = r_GetExamList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<Exam>> GetListAsync()
        {
            var result = await r_GetExamList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<Exam>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetExamList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }

        public IProcessResult<Exam> Insert(Exam data)
        {
            if (data != null)
            {
                r_InsertExam.Exam = data;
                var result = r_InsertExam.Execute();
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Exam>(ProcessResultStatus.Failed, "Invalid exam.");
            }
        }

        public async Task<IProcessResult<Exam>> InsertAsync(Exam data)
        {
            if (data != null)
            {
                r_InsertExam.Exam = data;
                var result = await r_InsertExam.ExecuteAsync();
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Exam>(ProcessResultStatus.Failed, "Invalid exam.");
            }
        }

        public async Task<IProcessResult<Exam>> InsertAsync(Exam data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_InsertExam.Exam = data;
                var result = await r_InsertExam.ExecuteAsync(cancellationToken);
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Exam>(ProcessResultStatus.Failed, "Invalid exam.");
            }
        }

        public IProcessResult<Exam> Update(Exam data)
        {
            if (data != null)
            {
                r_UpdateExam.Exam = data;
                var result = r_UpdateExam.Execute();
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Exam>(ProcessResultStatus.Failed, "Invalid exam.");
            }
        }

        public async Task<IProcessResult<Exam>> UpdateAsync(Exam data)
        {
            if (data != null)
            {
                r_UpdateExam.Exam = data;
                var result = await r_UpdateExam.ExecuteAsync();
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Exam>(ProcessResultStatus.Failed, "Invalid exam.");
            }
        }

        public async Task<IProcessResult<Exam>> UpdateAsync(Exam data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_UpdateExam.Exam = data;
                var result = await r_UpdateExam.ExecuteAsync(cancellationToken);
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Exam>(ProcessResultStatus.Failed, "Invalid exam.");
            }
        }
    }
}
