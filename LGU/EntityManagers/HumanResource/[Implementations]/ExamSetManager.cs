using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class ExamSetManager : ManagerBase<IExamSet, int>, IExamSetManager
    {
        private readonly IDeleteExamSet r_DeleteExamSet;
        private readonly IGetExamSetById r_GetExamSetById;
        private readonly IGetExamSetList r_GetExamSetList;
        private readonly IInsertExamSet r_InsertExamSet;
        private readonly IUpdateExamSet r_UpdateExamSet;

        public ExamSetManager(
            IDeleteExamSet deleteExamSet,
            IGetExamSetById getExamSetById,
            IGetExamSetList getExamSetList,
            IInsertExamSet insertExamSet,
            IUpdateExamSet updateExamSet)
        {
            r_DeleteExamSet = deleteExamSet;
            r_GetExamSetById = getExamSetById;
            r_GetExamSetList = getExamSetList;
            r_InsertExamSet = insertExamSet;
            r_UpdateExamSet = updateExamSet;
        }

        public IProcessResult<IExamSet> Delete(IExamSet data)
        {
            if (data != null)
            {
                r_DeleteExamSet.ExamSet = data;
                var result = r_DeleteExamSet.Execute();
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IExamSet>(ProcessResultStatus.Failed, "Invalid exam set.");
            }
        }

        public async Task<IProcessResult<IExamSet>> DeleteAsync(IExamSet data)
        {
            if (data != null)
            {
                r_DeleteExamSet.ExamSet = data;
                var result = await r_DeleteExamSet.ExecuteAsync();
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IExamSet>(ProcessResultStatus.Failed, "Invalid exam set.");
            }
        }

        public async Task<IProcessResult<IExamSet>> DeleteAsync(IExamSet data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_DeleteExamSet.ExamSet = data;
                var result = await r_DeleteExamSet.ExecuteAsync(cancellationToken);
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IExamSet>(ProcessResultStatus.Failed, "Invalid exam set.");
            }
        }

        public IProcessResult<IExamSet> GetById(int id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IExamSet>(StaticSource[id]);
                }
                else
                {
                    r_GetExamSetById.ExamSetId = id;
                    var result = r_GetExamSetById.Execute();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<IExamSet>(ProcessResultStatus.Failed, "Invalid exam set identifier.");
            }
        }

        public async Task<IProcessResult<IExamSet>> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IExamSet>(StaticSource[id]);
                }
                else
                {
                    r_GetExamSetById.ExamSetId = id;
                    var result = await r_GetExamSetById.ExecuteAsync();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<IExamSet>(ProcessResultStatus.Failed, "Invalid exam set identifier.");
            }
        }

        public async Task<IProcessResult<IExamSet>> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IExamSet>(StaticSource[id]);
                }
                else
                {
                    r_GetExamSetById.ExamSetId = id;
                    var result = await r_GetExamSetById.ExecuteAsync(cancellationToken);
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<IExamSet>(ProcessResultStatus.Failed, "Invalid exam set identifier.");
            }
        }

        public IEnumerableProcessResult<IExamSet> GetList()
        {
            var result = r_GetExamSetList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<IExamSet>> GetListAsync()
        {
            var result = await r_GetExamSetList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<IExamSet>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetExamSetList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }

        public IProcessResult<IExamSet> Insert(IExamSet data)
        {
            if (data != null)
            {
                r_InsertExamSet.ExamSet = data;
                var result = r_InsertExamSet.Execute();
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IExamSet>(ProcessResultStatus.Failed, "Invalid exam set.");
            }
        }

        public async Task<IProcessResult<IExamSet>> InsertAsync(IExamSet data)
        {
            if (data != null)
            {
                r_InsertExamSet.ExamSet = data;
                var result = await r_InsertExamSet.ExecuteAsync();
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IExamSet>(ProcessResultStatus.Failed, "Invalid exam set.");
            }
        }

        public async Task<IProcessResult<IExamSet>> InsertAsync(IExamSet data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_InsertExamSet.ExamSet = data;
                var result = await r_InsertExamSet.ExecuteAsync(cancellationToken);
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IExamSet>(ProcessResultStatus.Failed, "Invalid exam set.");
            }
        }

        public IProcessResult<IExamSet> Update(IExamSet data)
        {
            if (data != null)
            {
                r_UpdateExamSet.ExamSet = data;
                var result = r_UpdateExamSet.Execute();
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IExamSet>(ProcessResultStatus.Failed, "Invalid exam set.");
            }
        }

        public async Task<IProcessResult<IExamSet>> UpdateAsync(IExamSet data)
        {
            if (data != null)
            {
                r_UpdateExamSet.ExamSet = data;
                var result = await r_UpdateExamSet.ExecuteAsync();
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IExamSet>(ProcessResultStatus.Failed, "Invalid exam set.");
            }
        }

        public async Task<IProcessResult<IExamSet>> UpdateAsync(IExamSet data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_UpdateExamSet.ExamSet = data;
                var result = await r_UpdateExamSet.ExecuteAsync(cancellationToken);
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<IExamSet>(ProcessResultStatus.Failed, "Invalid exam set.");
            }
        }
    }
}
