using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class MultipleChoiceQuestionConverter : IMultipleChoiceQuestionConverter
    {
        private IExamSetManager ExamSetManager;
        
        private IMultipleChoiceQuestion GetData(IExamSet set, DbDataReader reader)
        {
            if (set != null)
            {
                return new MultipleChoiceQuestion(set, reader.GetNullableInt32("MaxAnswerCount"))
                {
                    Id = reader.GetInt64("Id"),
                    Description = reader.GetString("Description"),
                    Points = reader.GetInt32("Points")
                };
            }
            else
            {
                return null;
            }
        }

        private IMultipleChoiceQuestion GetData(DbDataReader reader)
        {
            var setResult = ExamSetManager.GetById(reader.GetInt32("SetId"));

            return GetData(setResult.Data, reader);
        }

        private async Task<IMultipleChoiceQuestion> GetDataAsync(DbDataReader reader)
        {
            var setResult = await ExamSetManager.GetByIdAsync(reader.GetInt32("SetId"));

            return GetData(setResult.Data, reader);
        }

        private async Task<IMultipleChoiceQuestion> GetDataAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var setResult = await ExamSetManager.GetByIdAsync(reader.GetInt32("SetId"), cancellationToken);

            return GetData(setResult.Data, reader);
        }

        public IEnumerableProcessResult<IMultipleChoiceQuestion> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<IMultipleChoiceQuestion>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IMultipleChoiceQuestion>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IMultipleChoiceQuestion>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IMultipleChoiceQuestion>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<IMultipleChoiceQuestion>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<IMultipleChoiceQuestion>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IMultipleChoiceQuestion>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IMultipleChoiceQuestion>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IMultipleChoiceQuestion>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<IMultipleChoiceQuestion>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IMultipleChoiceQuestion>(ex);
            }
        }

        public IProcessResult<IMultipleChoiceQuestion> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IMultipleChoiceQuestion>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IMultipleChoiceQuestion>(ex);
            }
        }

        public async Task<IProcessResult<IMultipleChoiceQuestion>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IMultipleChoiceQuestion>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IMultipleChoiceQuestion>(ex);
            }
        }

        public async Task<IProcessResult<IMultipleChoiceQuestion>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IMultipleChoiceQuestion>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IMultipleChoiceQuestion>(ex);
            }
        }

        public void InitializeDependency()
        {
            ExamSetManager = ApplicationDomain.GetService<IExamSetManager>();
        }
    }
}
