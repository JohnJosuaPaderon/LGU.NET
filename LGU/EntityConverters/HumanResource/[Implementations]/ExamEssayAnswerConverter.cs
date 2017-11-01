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
    public sealed class ExamEssayAnswerConverter : IExamEssayAnswerConverter
    {
        private IExamManager ExamManager;
        private IEssayQuestionManager EssayQuestionManager;

        private IExamEssayAnswer GetData(IExam exam, IEssayQuestion question, DbDataReader reader)
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

        private IExamEssayAnswer GetData(DbDataReader reader)
        {
            var examResult = ExamManager.GetById(reader.GetInt64("ExamId"));
            var questionResult = EssayQuestionManager.GetById(reader.GetInt64("QuestionId"));

            return GetData(examResult.Data, questionResult.Data, reader);
        }

        private async Task<IExamEssayAnswer> GetDataAsync(DbDataReader reader)
        {
            var examResult = await ExamManager.GetByIdAsync(reader.GetInt64("ExamId"));
            var questionResult = await EssayQuestionManager.GetByIdAsync(reader.GetInt64("QuestionId"));

            return GetData(examResult.Data, questionResult.Data, reader);
        }

        private async Task<IExamEssayAnswer> GetDataAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var examResult = await ExamManager.GetByIdAsync(reader.GetInt64("ExamId"), cancellationToken);
            var questionResult = await EssayQuestionManager.GetByIdAsync(reader.GetInt64("QuestionId"), cancellationToken);

            return GetData(examResult.Data, questionResult.Data, reader);
        }

        public IEnumerableProcessResult<IExamEssayAnswer> EnumerableFromReader(DbDataReader reader)
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

        public async Task<IEnumerableProcessResult<IExamEssayAnswer>> EnumerableFromReaderAsync(DbDataReader reader)
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

        public async Task<IEnumerableProcessResult<IExamEssayAnswer>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
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

        public IProcessResult<IExamEssayAnswer> FromReader(DbDataReader reader)
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

        public async Task<IProcessResult<IExamEssayAnswer>> FromReaderAsync(DbDataReader reader)
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

        public async Task<IProcessResult<IExamEssayAnswer>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
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

        public void InitializeDependency()
        {
            ExamManager = ApplicationDomain.GetService<IExamManager>();
            EssayQuestionManager = ApplicationDomain.GetService<IEssayQuestionManager>();
        }
    }
}
