using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class UpdateMultipleChoiceCandidateAnswer : MultipleChoiceCandidateAnswerProcess, IUpdateMultipleChoiceCandidateAnswer
    {
        public UpdateMultipleChoiceCandidateAnswer(IConnectionStringSource connectionStringSource, IMultipleChoiceCandidateAnswerConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public MultipleChoiceCandidateAnswer MultipleChoiceCandidateAnswer { get; set; }

        private SqlQueryInfo<MultipleChoiceCandidateAnswer> QueryInfo =>
            SqlQueryInfo<MultipleChoiceCandidateAnswer>.CreateProcedureQueryInfo(MultipleChoiceCandidateAnswer, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", MultipleChoiceCandidateAnswer.Id)
            .AddInputParameter("@_QuestionId", MultipleChoiceCandidateAnswer.Question?.Id)
            .AddInputParameter("@_Description", MultipleChoiceCandidateAnswer.Description)
            .AddInputParameter("@_IsCorrect", MultipleChoiceCandidateAnswer.IsCorrect)
            .AddLogByParameter();

        private IProcessResult<MultipleChoiceCandidateAnswer> GetProcessResult(MultipleChoiceCandidateAnswer data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<MultipleChoiceCandidateAnswer>(data);
            }
            else
            {
                return new ProcessResult<MultipleChoiceCandidateAnswer>(ProcessResultStatus.Failed, "Failed to update multiple choice candidate answer.");
            }
        }

        public IProcessResult<MultipleChoiceCandidateAnswer> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<MultipleChoiceCandidateAnswer>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<MultipleChoiceCandidateAnswer>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
