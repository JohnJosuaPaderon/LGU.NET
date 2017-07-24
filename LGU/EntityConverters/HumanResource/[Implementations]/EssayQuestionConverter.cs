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
    public sealed class EssayQuestionConverter : IEssayQuestionConverter<SqlDataReader>
    {
        private readonly IExamSetManager r_ExamSetManager;

        public EssayQuestionConverter(IExamSetManager examSetManager)
        {
            r_ExamSetManager = examSetManager;
        }

        private EssayQuestion GetData(ExamSet set, SqlDataReader reader)
        {
            if (set != null)
            {
                return new EssayQuestion(set)
                {
                    Id = reader.GetInt64("Id"),
                    Description = reader.GetString("Description"),
                    Points = reader.GetInt32("Points"),
                    MaxAnswerLength = reader.GetNullableInt32("MaxAnswerLength")
                };
            }
            else
            {
                return null;
            }
        }

        private EssayQuestion GetData(SqlDataReader reader)
        {
            var setResult = r_ExamSetManager.GetById(reader.GetInt32("SetId"));

            return GetData(setResult.Data, reader);
        }

        private async Task<EssayQuestion> GetDataAsync(SqlDataReader reader)
        {
            var setResult = await r_ExamSetManager.GetByIdAsync(reader.GetInt32("SetId"));

            return GetData(setResult.Data, reader);
        }

        private async Task<EssayQuestion> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var setResult = await r_ExamSetManager.GetByIdAsync(reader.GetInt32("SetId"), cancellationToken);

            return GetData(setResult.Data, reader);
        }

        public IEnumerableProcessResult<EssayQuestion> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<EssayQuestion>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<EssayQuestion>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<EssayQuestion>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<EssayQuestion>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<EssayQuestion>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<EssayQuestion>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<EssayQuestion>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<EssayQuestion>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<EssayQuestion>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<EssayQuestion>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<EssayQuestion>(ex);
            }
        }

        public IProcessResult<EssayQuestion> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<EssayQuestion>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<EssayQuestion>(ex);
            }
        }

        public async Task<IProcessResult<EssayQuestion>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<EssayQuestion>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<EssayQuestion>(ex);
            }
        }

        public async Task<IProcessResult<EssayQuestion>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<EssayQuestion>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<EssayQuestion>(ex);
            }
        }
    }
}
