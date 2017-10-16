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
    public sealed class MultipleChoiceCandidateAnswerConverter : IMultipleChoiceCandidateAnswerConverter
    {
        private readonly IMultipleChoiceQuestionManager r_MultipleChoiceQuestionManager;

        public MultipleChoiceCandidateAnswerConverter(IMultipleChoiceQuestionManager multipleChoiceQuestionManager)
        {
            r_MultipleChoiceQuestionManager = multipleChoiceQuestionManager;
        }

        private IMultipleChoiceCandidateAnswer GetData(IMultipleChoiceQuestion question, DbDataReader reader)
        {
            if (question != null)
            {
                return new MultipleChoiceCandidateAnswer(question)
                {
                    Id = reader.GetInt64("Id"),
                    Description = reader.GetString("Description"),
                    IsCorrect = reader.GetBoolean("IsCorrect")
                };
            }
            else
            {
                return null;
            }
        }

        private IMultipleChoiceCandidateAnswer GetData(DbDataReader reader)
        {
            var questionResult = r_MultipleChoiceQuestionManager.GetById(reader.GetInt64("QuestionId"));

            return GetData(questionResult.Data, reader);
        }

        private async Task<IMultipleChoiceCandidateAnswer> GetDataAsync(DbDataReader reader)
        {
            var questionResult = await r_MultipleChoiceQuestionManager.GetByIdAsync(reader.GetInt64("QuestionId"));

            return GetData(questionResult.Data, reader);
        }

        private async Task<IMultipleChoiceCandidateAnswer> GetDataAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var questionResult = await r_MultipleChoiceQuestionManager.GetByIdAsync(reader.GetInt64("QuestionId"), cancellationToken);

            return GetData(questionResult.Data, reader);
        }

        public IEnumerableProcessResult<IMultipleChoiceCandidateAnswer> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<IMultipleChoiceCandidateAnswer>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IMultipleChoiceCandidateAnswer>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IMultipleChoiceCandidateAnswer>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IMultipleChoiceCandidateAnswer>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<IMultipleChoiceCandidateAnswer>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<IMultipleChoiceCandidateAnswer>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IMultipleChoiceCandidateAnswer>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IMultipleChoiceCandidateAnswer>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IMultipleChoiceCandidateAnswer>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<IMultipleChoiceCandidateAnswer>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IMultipleChoiceCandidateAnswer>(ex);
            }
        }

        public IProcessResult<IMultipleChoiceCandidateAnswer> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IMultipleChoiceCandidateAnswer>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IMultipleChoiceCandidateAnswer>(ex);
            }
        }

        public async Task<IProcessResult<IMultipleChoiceCandidateAnswer>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IMultipleChoiceCandidateAnswer>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IMultipleChoiceCandidateAnswer>(ex);
            }
        }

        public async Task<IProcessResult<IMultipleChoiceCandidateAnswer>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IMultipleChoiceCandidateAnswer>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IMultipleChoiceCandidateAnswer>(ex);
            }
        }
    }
}
