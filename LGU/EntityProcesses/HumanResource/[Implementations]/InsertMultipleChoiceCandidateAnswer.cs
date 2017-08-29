using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class InsertMultipleChoiceCandidateAnswer : MultipleChoiceCandidateAnswerProcess, IInsertMultipleChoiceCandidateAnswer
    {
        public InsertMultipleChoiceCandidateAnswer(IConnectionStringSource connectionStringSource, IMultipleChoiceCandidateAnswerConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IMultipleChoiceCandidateAnswer MultipleChoiceCandidateAnswer { get; set; }

        private SqlQueryInfo<IMultipleChoiceCandidateAnswer> QueryInfo =>
            SqlQueryInfo<IMultipleChoiceCandidateAnswer>.CreateProcedureQueryInfo(MultipleChoiceCandidateAnswer, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int64)
            .AddInputParameter("@_QuestionId", MultipleChoiceCandidateAnswer.Question?.Id)
            .AddInputParameter("@_Description", MultipleChoiceCandidateAnswer.Description)
            .AddInputParameter("@_IsCorrect", MultipleChoiceCandidateAnswer.IsCorrect)
            .AddLogByParameter();

        private IProcessResult<IMultipleChoiceCandidateAnswer> GetProcessResult(IMultipleChoiceCandidateAnswer data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64("@_Id");
                return new ProcessResult<IMultipleChoiceCandidateAnswer>(data);
            }
            else
            {
                return new ProcessResult<IMultipleChoiceCandidateAnswer>(ProcessResultStatus.Failed, "Failed to insert multiple choice candidate answer.");
            }
        }

        public IProcessResult<IMultipleChoiceCandidateAnswer> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IMultipleChoiceCandidateAnswer>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IMultipleChoiceCandidateAnswer>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
