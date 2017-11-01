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
    public sealed class ExamMultipleChoiceAnswerConverter : IExamMultipleChoiceAnswerConverter
    {
        private IExamManager ExamManager;
        private IMultipleChoiceQuestionManager MultipleChoiceQuestionManager;
        private IMultipleChoiceCandidateAnswerManager MultipleChoiceCandidateAnswerManager;

        private IExamMultipleChoiceAnswer GetData(IExam exam, IMultipleChoiceQuestion question, IMultipleChoiceCandidateAnswer answer, DbDataReader reader)
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

        private IExamMultipleChoiceAnswer GetData(DbDataReader reader)
        {
            var examResult = ExamManager.GetById(reader.GetInt64("ExamId"));
            var questionResult = MultipleChoiceQuestionManager.GetById(reader.GetInt64("QuestionId"));
            var answerResult = MultipleChoiceCandidateAnswerManager.GetById(reader.GetInt64("AnswerId"));

            return GetData(examResult.Data, questionResult.Data, answerResult.Data, reader);
        }

        private async Task<IExamMultipleChoiceAnswer> GetDataAsync(DbDataReader reader)
        {
            var examResult = await ExamManager.GetByIdAsync(reader.GetInt64("ExamId"));
            var questionResult = await MultipleChoiceQuestionManager.GetByIdAsync(reader.GetInt64("QuestionId"));
            var answerResult = await MultipleChoiceCandidateAnswerManager.GetByIdAsync(reader.GetInt64("AnswerId"));

            return GetData(examResult.Data, questionResult.Data, answerResult.Data, reader);
        }

        private async Task<IExamMultipleChoiceAnswer> GetDataAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var examResult = await ExamManager.GetByIdAsync(reader.GetInt64("ExamId"), cancellationToken);
            var questionResult = await MultipleChoiceQuestionManager.GetByIdAsync(reader.GetInt64("QuestionId"), cancellationToken);
            var answerResult = await MultipleChoiceCandidateAnswerManager.GetByIdAsync(reader.GetInt64("AnswerId"), cancellationToken);

            return GetData(examResult.Data, questionResult.Data, answerResult.Data, reader);
        }

        public IEnumerableProcessResult<IExamMultipleChoiceAnswer> EnumerableFromReader(DbDataReader reader)
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

        public async Task<IEnumerableProcessResult<IExamMultipleChoiceAnswer>> EnumerableFromReaderAsync(DbDataReader reader)
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

        public async Task<IEnumerableProcessResult<IExamMultipleChoiceAnswer>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
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

        public IProcessResult<IExamMultipleChoiceAnswer> FromReader(DbDataReader reader)
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

        public async Task<IProcessResult<IExamMultipleChoiceAnswer>> FromReaderAsync(DbDataReader reader)
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

        public async Task<IProcessResult<IExamMultipleChoiceAnswer>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
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

        public void InitializeDependency()
        {
            ExamManager = ApplicationDomain.GetService<IExamManager>();
            MultipleChoiceCandidateAnswerManager = ApplicationDomain.GetService<IMultipleChoiceCandidateAnswerManager>();
            MultipleChoiceQuestionManager = ApplicationDomain.GetService<IMultipleChoiceQuestionManager>();
        }
    }
}
