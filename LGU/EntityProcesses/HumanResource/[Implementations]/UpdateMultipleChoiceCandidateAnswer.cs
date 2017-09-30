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

        public IMultipleChoiceCandidateAnswer MultipleChoiceCandidateAnswer { get; set; }

        private SqlQueryInfo<IMultipleChoiceCandidateAnswer> QueryInfo =>
            SqlQueryInfo<IMultipleChoiceCandidateAnswer>.CreateProcedureQueryInfo(MultipleChoiceCandidateAnswer, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", MultipleChoiceCandidateAnswer.Id)
            .AddInputParameter("@_QuestionId", MultipleChoiceCandidateAnswer.Question?.Id)
            .AddInputParameter("@_Description", MultipleChoiceCandidateAnswer.Description)
            .AddInputParameter("@_IsCorrect", MultipleChoiceCandidateAnswer.IsCorrect)
            .AddLogByParameter();

        private IProcessResult<IMultipleChoiceCandidateAnswer> GetProcessResult(IMultipleChoiceCandidateAnswer data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IMultipleChoiceCandidateAnswer>(data);
            }
            else
            {
                return new ProcessResult<IMultipleChoiceCandidateAnswer>(ProcessResultStatus.Failed, "Failed to update multiple choice candidate answer.");
            }
        }

        public IProcessResult<IMultipleChoiceCandidateAnswer> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IMultipleChoiceCandidateAnswer>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IMultipleChoiceCandidateAnswer>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
