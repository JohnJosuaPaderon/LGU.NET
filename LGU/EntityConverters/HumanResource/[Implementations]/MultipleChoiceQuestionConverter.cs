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

        private MultipleChoiceQuestion GetData(ExamSet set, SqlDataReader reader)
        {
            if (set != null)
            {
                return new MultipleChoiceQuestion(set, reader.GetBoolean("IsMultipleAnswer"))
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

        private MultipleChoiceQuestion GetData(SqlDataReader reader)
        {
            var setResult = r_ExamSetManager.GetById(reader.GetInt32("SetId"));

            return GetData(setResult.Data, reader);
        }

        private async Task<MultipleChoiceQuestion> GetDataAsync(SqlDataReader reader)
        {
            var setResult = await r_ExamSetManager.GetByIdAsync(reader.GetInt32("SetId"));

            return GetData(setResult.Data, reader);
        }

        private async Task<MultipleChoiceQuestion> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var setResult = await r_ExamSetManager.GetByIdAsync(reader.GetInt32("SetId"), cancellationToken);

            return GetData(setResult.Data, reader);
        }

        public IEnumerableProcessResult<MultipleChoiceQuestion> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<MultipleChoiceQuestion>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<MultipleChoiceQuestion>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<MultipleChoiceQuestion>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<MultipleChoiceQuestion>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<MultipleChoiceQuestion>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<MultipleChoiceQuestion>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<MultipleChoiceQuestion>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<MultipleChoiceQuestion>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<MultipleChoiceQuestion>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<MultipleChoiceQuestion>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<MultipleChoiceQuestion>(ex);
            }
        }

        public IProcessResult<MultipleChoiceQuestion> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<MultipleChoiceQuestion>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<MultipleChoiceQuestion>(ex);
            }
        }

        public async Task<IProcessResult<MultipleChoiceQuestion>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<MultipleChoiceQuestion>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<MultipleChoiceQuestion>(ex);
            }
        }

        public async Task<IProcessResult<MultipleChoiceQuestion>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<MultipleChoiceQuestion>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<MultipleChoiceQuestion>(ex);
            }
        }
    }
}
