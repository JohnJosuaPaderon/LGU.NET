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
    public sealed class MultipleChoiceCandidateAnswerConverter : IMultipleChoiceCandidateAnswerConverter<SqlDataReader>
    {
        private readonly IMultipleChoiceQuestionManager r_MultipleChoiceQuestionManager;

        public MultipleChoiceCandidateAnswerConverter(IMultipleChoiceQuestionManager multipleChoiceQuestionManager)
        {
            r_MultipleChoiceQuestionManager = multipleChoiceQuestionManager;
        }

        private MultipleChoiceCandidateAnswer GetData(MultipleChoiceQuestion question, SqlDataReader reader)
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

        private MultipleChoiceCandidateAnswer GetData(SqlDataReader reader)
        {
            var questionResult = r_MultipleChoiceQuestionManager.GetById(reader.GetInt64("QuestionId"));

            return GetData(questionResult.Data, reader);
        }

        private async Task<MultipleChoiceCandidateAnswer> GetDataAsync(SqlDataReader reader)
        {
            var questionResult = await r_MultipleChoiceQuestionManager.GetByIdAsync(reader.GetInt64("QuestionId"));

            return GetData(questionResult.Data, reader);
        }

        private async Task<MultipleChoiceCandidateAnswer> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var questionResult = await r_MultipleChoiceQuestionManager.GetByIdAsync(reader.GetInt64("QuestionId"), cancellationToken);

            return GetData(questionResult.Data, reader);
        }

        public IEnumerableProcessResult<MultipleChoiceCandidateAnswer> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<MultipleChoiceCandidateAnswer>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<MultipleChoiceCandidateAnswer>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<MultipleChoiceCandidateAnswer>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<MultipleChoiceCandidateAnswer>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<MultipleChoiceCandidateAnswer>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<MultipleChoiceCandidateAnswer>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<MultipleChoiceCandidateAnswer>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<MultipleChoiceCandidateAnswer>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<MultipleChoiceCandidateAnswer>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<MultipleChoiceCandidateAnswer>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<MultipleChoiceCandidateAnswer>(ex);
            }
        }

        public IProcessResult<MultipleChoiceCandidateAnswer> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<MultipleChoiceCandidateAnswer>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<MultipleChoiceCandidateAnswer>(ex);
            }
        }

        public async Task<IProcessResult<MultipleChoiceCandidateAnswer>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<MultipleChoiceCandidateAnswer>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<MultipleChoiceCandidateAnswer>(ex);
            }
        }

        public async Task<IProcessResult<MultipleChoiceCandidateAnswer>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<MultipleChoiceCandidateAnswer>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<MultipleChoiceCandidateAnswer>(ex);
            }
        }
    }
}
