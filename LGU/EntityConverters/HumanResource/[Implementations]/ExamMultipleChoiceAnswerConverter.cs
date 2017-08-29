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
    public sealed class ExamMultipleChoiceAnswerConverter : IExamMultipleChoiceAnswerConverter<SqlDataReader>
    {
        private readonly IExamManager r_ExamManager;
        private readonly IMultipleChoiceQuestionManager r_MultipleChoiceQuestionManager;
        private readonly IMultipleChoiceCandidateAnswerManager r_MultipleChoiceCandidateAnswerManager;

        public ExamMultipleChoiceAnswerConverter(
            IExamManager examManager,
            IMultipleChoiceQuestionManager multipleChoiceQuestionManager,
            IMultipleChoiceCandidateAnswerManager multipleChoiceCandidateAnswerManager)
        {
            r_ExamManager = examManager;
            r_MultipleChoiceQuestionManager = multipleChoiceQuestionManager;
            r_MultipleChoiceCandidateAnswerManager = multipleChoiceCandidateAnswerManager;
        }

        private IExamMultipleChoiceAnswer GetData(IExam exam, IMultipleChoiceQuestion question, IMultipleChoiceCandidateAnswer answer, SqlDataReader reader)
        {
            if (exam != null && question != null)
            {
                return new ExamMultipleChoiceAnswer(exam, question)
                {
                    Answer = answer,
                    IsCorrect = reader.GetNullableBoolean("IsCorrect")
                };
            }
            else
            {
                return null;
            }
        }

        private IExamMultipleChoiceAnswer GetData(SqlDataReader reader)
        {
            var examResult = r_ExamManager.GetById(reader.GetInt64("ExamId"));
            var questionResult = r_MultipleChoiceQuestionManager.GetById(reader.GetInt64("QuestionId"));
            var answerResult = r_MultipleChoiceCandidateAnswerManager.GetById(reader.GetInt64("AnswerId"));

            return GetData(examResult.Data, questionResult.Data, answerResult.Data, reader);
        }

        private async Task<IExamMultipleChoiceAnswer> GetDataAsync(SqlDataReader reader)
        {
            var examResult = await r_ExamManager.GetByIdAsync(reader.GetInt64("ExamId"));
            var questionResult = await r_MultipleChoiceQuestionManager.GetByIdAsync(reader.GetInt64("QuestionId"));
            var answerResult = await r_MultipleChoiceCandidateAnswerManager.GetByIdAsync(reader.GetInt64("AnswerId"));

            return GetData(examResult.Data, questionResult.Data, answerResult.Data, reader);
        }

        private async Task<IExamMultipleChoiceAnswer> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var examResult = await r_ExamManager.GetByIdAsync(reader.GetInt64("ExamId"), cancellationToken);
            var questionResult = await r_MultipleChoiceQuestionManager.GetByIdAsync(reader.GetInt64("QuestionId"), cancellationToken);
            var answerResult = await r_MultipleChoiceCandidateAnswerManager.GetByIdAsync(reader.GetInt64("AnswerId"), cancellationToken);

            return GetData(examResult.Data, questionResult.Data, answerResult.Data, reader);
        }

        public IEnumerableProcessResult<IExamMultipleChoiceAnswer> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<IExamMultipleChoiceAnswer>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IExamMultipleChoiceAnswer>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IExamMultipleChoiceAnswer>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IExamMultipleChoiceAnswer>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<IExamMultipleChoiceAnswer>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<IExamMultipleChoiceAnswer>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IExamMultipleChoiceAnswer>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IExamMultipleChoiceAnswer>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IExamMultipleChoiceAnswer>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<IExamMultipleChoiceAnswer>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IExamMultipleChoiceAnswer>(ex);
            }
        }

        public IProcessResult<IExamMultipleChoiceAnswer> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IExamMultipleChoiceAnswer>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IExamMultipleChoiceAnswer>(ex);
            }
        }

        public async Task<IProcessResult<IExamMultipleChoiceAnswer>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IExamMultipleChoiceAnswer>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IExamMultipleChoiceAnswer>(ex);
            }
        }

        public async Task<IProcessResult<IExamMultipleChoiceAnswer>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IExamMultipleChoiceAnswer>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IExamMultipleChoiceAnswer>(ex);
            }
        }
    }
}
