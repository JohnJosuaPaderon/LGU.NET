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

        private IEssayQuestion GetData(IExamSet set, SqlDataReader reader)
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

        private IEssayQuestion GetData(SqlDataReader reader)
        {
            var setResult = r_ExamSetManager.GetById(reader.GetInt32("SetId"));

            return GetData(setResult.Data, reader);
        }

        private async Task<IEssayQuestion> GetDataAsync(SqlDataReader reader)
        {
            var setResult = await r_ExamSetManager.GetByIdAsync(reader.GetInt32("SetId"));

            return GetData(setResult.Data, reader);
        }

        private async Task<IEssayQuestion> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var setResult = await r_ExamSetManager.GetByIdAsync(reader.GetInt32("SetId"), cancellationToken);

            return GetData(setResult.Data, reader);
        }

        public IEnumerableProcessResult<IEssayQuestion> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<IEssayQuestion>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IEssayQuestion>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEssayQuestion>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IEssayQuestion>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<IEssayQuestion>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<IEssayQuestion>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEssayQuestion>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IEssayQuestion>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IEssayQuestion>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<IEssayQuestion>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEssayQuestion>(ex);
            }
        }

        public IProcessResult<IEssayQuestion> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IEssayQuestion>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEssayQuestion>(ex);
            }
        }

        public async Task<IProcessResult<IEssayQuestion>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IEssayQuestion>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEssayQuestion>(ex);
            }
        }

        public async Task<IProcessResult<IEssayQuestion>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IEssayQuestion>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEssayQuestion>(ex);
            }
        }
    }
}
