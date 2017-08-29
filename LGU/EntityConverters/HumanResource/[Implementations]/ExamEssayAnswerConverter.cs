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
    public sealed class ExamEssayAnswerConverter : IExamEssayAnswerConverter<SqlDataReader>
    {
        private readonly IExamManager r_ExamManager;
        private readonly IEssayQuestionManager r_EssayQuestionManager;

        public ExamEssayAnswerConverter(
            IExamManager examManager,
            IEssayQuestionManager essayQuestionManager)
        {
            r_ExamManager = examManager;
            r_EssayQuestionManager = essayQuestionManager;
        }

        private IExamEssayAnswer GetData(IExam exam, IEssayQuestion question, SqlDataReader reader)
        {
            if (exam != null && question != null)
            {
                return new ExamEssayAnswer(exam, question)
                {
                    Description = reader.GetString("Description"),
                    IsCorrect = reader.GetNullableBoolean("IsCorrect")
                };
            }
            else
            {
                return null;
            }
        }

        private IExamEssayAnswer GetData(SqlDataReader reader)
        {
            var examResult = r_ExamManager.GetById(reader.GetInt64("ExamId"));
            var questionResult = r_EssayQuestionManager.GetById(reader.GetInt64("QuestionId"));

            return GetData(examResult.Data, questionResult.Data, reader);
        }

        private async Task<IExamEssayAnswer> GetDataAsync(SqlDataReader reader)
        {
            var examResult = await r_ExamManager.GetByIdAsync(reader.GetInt64("ExamId"));
            var questionResult = await r_EssayQuestionManager.GetByIdAsync(reader.GetInt64("QuestionId"));

            return GetData(examResult.Data, questionResult.Data, reader);
        }

        private async Task<IExamEssayAnswer> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var examResult = await r_ExamManager.GetByIdAsync(reader.GetInt64("ExamId"), cancellationToken);
            var questionResult = await r_EssayQuestionManager.GetByIdAsync(reader.GetInt64("QuestionId"), cancellationToken);

            return GetData(examResult.Data, questionResult.Data, reader);
        }

        public IEnumerableProcessResult<IExamEssayAnswer> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<IExamEssayAnswer>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IExamEssayAnswer>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IExamEssayAnswer>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IExamEssayAnswer>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<IExamEssayAnswer>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<IExamEssayAnswer>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IExamEssayAnswer>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IExamEssayAnswer>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IExamEssayAnswer>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<IExamEssayAnswer>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IExamEssayAnswer>(ex);
            }
        }

        public IProcessResult<IExamEssayAnswer> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IExamEssayAnswer>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IExamEssayAnswer>(ex);
            }
        }

        public async Task<IProcessResult<IExamEssayAnswer>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IExamEssayAnswer>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IExamEssayAnswer>(ex);
            }
        }

        public async Task<IProcessResult<IExamEssayAnswer>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IExamEssayAnswer>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IExamEssayAnswer>(ex);
            }
        }
    }
}
