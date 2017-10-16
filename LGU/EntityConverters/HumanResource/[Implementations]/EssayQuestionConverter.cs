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
    public sealed class EssayQuestionConverter : IEssayQuestionConverter
    {
        public EssayQuestionConverter(IExamSetManager examSetManager)
        {
            _ExamSetManager = examSetManager;
        }

        private readonly IExamSetManager _ExamSetManager;

        private IEssayQuestion GetData(IExamSet set, DbDataReader reader)
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

        private IEssayQuestion GetData(DbDataReader reader)
        {
            var setResult = _ExamSetManager.GetById(reader.GetInt32("SetId"));

            return GetData(setResult.Data, reader);
        }

        private async Task<IEssayQuestion> GetDataAsync(DbDataReader reader)
        {
            var setResult = await _ExamSetManager.GetByIdAsync(reader.GetInt32("SetId"));

            return GetData(setResult.Data, reader);
        }

        private async Task<IEssayQuestion> GetDataAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var setResult = await _ExamSetManager.GetByIdAsync(reader.GetInt32("SetId"), cancellationToken);

            return GetData(setResult.Data, reader);
        }

        public IEnumerableProcessResult<IEssayQuestion> EnumerableFromReader(DbDataReader reader)
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

        public async Task<IEnumerableProcessResult<IEssayQuestion>> EnumerableFromReaderAsync(DbDataReader reader)
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

        public async Task<IEnumerableProcessResult<IEssayQuestion>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
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

        public IProcessResult<IEssayQuestion> FromReader(DbDataReader reader)
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

        public async Task<IProcessResult<IEssayQuestion>> FromReaderAsync(DbDataReader reader)
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

        public async Task<IProcessResult<IEssayQuestion>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
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
