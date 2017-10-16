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
        public ExamMultipleChoiceAnswerConverter(
            IExamManager examManager,
            IMultipleChoiceQuestionManager multipleChoiceQuestionManager,
            IMultipleChoiceCandidateAnswerManager multipleChoiceCandidateAnswerManager)
        {
            _ExamManager = examManager;
            _MultipleChoiceQuestionManager = multipleChoiceQuestionManager;
            _MultipleChoiceCandidateAnswerManager = multipleChoiceCandidateAnswerManager;
        }

        private readonly IExamManager _ExamManager;
        private readonly IMultipleChoiceQuestionManager _MultipleChoiceQuestionManager;
        private readonly IMultipleChoiceCandidateAnswerManager _MultipleChoiceCandidateAnswerManager;

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
            var examResult = _ExamManager.GetById(reader.GetInt64("ExamId"));
            var questionResult = _MultipleChoiceQuestionManager.GetById(reader.GetInt64("QuestionId"));
            var answerResult = _MultipleChoiceCandidateAnswerManager.GetById(reader.GetInt64("AnswerId"));

            return GetData(examResult.Data, questionResult.Data, answerResult.Data, reader);
        }

        private async Task<IExamMultipleChoiceAnswer> GetDataAsync(DbDataReader reader)
        {
            var examResult = await _ExamManager.GetByIdAsync(reader.GetInt64("ExamId"));
            var questionResult = await _MultipleChoiceQuestionManager.GetByIdAsync(reader.GetInt64("QuestionId"));
            var answerResult = await _MultipleChoiceCandidateAnswerManager.GetByIdAsync(reader.GetInt64("AnswerId"));

            return GetData(examResult.Data, questionResult.Data, answerResult.Data, reader);
        }

        private async Task<IExamMultipleChoiceAnswer> GetDataAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var examResult = await _ExamManager.GetByIdAsync(reader.GetInt64("ExamId"), cancellationToken);
            var questionResult = await _MultipleChoiceQuestionManager.GetByIdAsync(reader.GetInt64("QuestionId"), cancellationToken);
            var answerResult = await _MultipleChoiceCandidateAnswerManager.GetByIdAsync(reader.GetInt64("AnswerId"), cancellationToken);

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
    }
}
