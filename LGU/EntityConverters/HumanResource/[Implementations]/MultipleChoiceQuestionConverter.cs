using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class MultipleChoiceQuestionConverter : IMultipleChoiceQuestionConverter<SqlDataReader>
    {
        private readonly IExamSetManager r_ExamSetManager;

        public MultipleChoiceQuestionConverter(IExamSetManager examSetManager)
        {
            r_ExamSetManager = examSetManager;
        }

        private IMultipleChoiceQuestion GetData(IExamSet set, SqlDataReader reader)
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

        private IMultipleChoiceQuestion GetData(SqlDataReader reader)
        {
            var setResult = r_ExamSetManager.GetById(reader.GetInt32("SetId"));

            return GetData(setResult.Data, reader);
        }

        private async Task<IMultipleChoiceQuestion> GetDataAsync(SqlDataReader reader)
        {
            var setResult = await r_ExamSetManager.GetByIdAsync(reader.GetInt32("SetId"));

            return GetData(setResult.Data, reader);
        }

        private async Task<IMultipleChoiceQuestion> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var setResult = await r_ExamSetManager.GetByIdAsync(reader.GetInt32("SetId"), cancellationToken);

            return GetData(setResult.Data, reader);
        }

        public IEnumerableProcessResult<IMultipleChoiceQuestion> EnumerableFromReader(SqlDataReader reader)
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

        public async Task<IEnumerableProcessResult<IMultipleChoiceQuestion>> EnumerableFromReaderAsync(SqlDataReader reader)
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

        public async Task<IEnumerableProcessResult<IMultipleChoiceQuestion>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
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

        public IProcessResult<IMultipleChoiceQuestion> FromReader(SqlDataReader reader)
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

        public async Task<IProcessResult<IMultipleChoiceQuestion>> FromReaderAsync(SqlDataReader reader)
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

        public async Task<IProcessResult<IMultipleChoiceQuestion>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
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
    }
}
