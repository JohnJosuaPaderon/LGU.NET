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
    public sealed class DeleteMultipleChoiceCandidateAnswer : MultipleChoiceCandidateAnswerProcess, IDeleteMultipleChoiceCandidateAnswer
    {
        public DeleteMultipleChoiceCandidateAnswer(IConnectionStringSource connectionStringSource, IMultipleChoiceCandidateAnswerConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IMultipleChoiceCandidateAnswer MultipleChoiceCandidateAnswer { get; set; }

        private SqlQueryInfo<IMultipleChoiceCandidateAnswer> QueryInfo =>
            SqlQueryInfo<IMultipleChoiceCandidateAnswer>.CreateProcedureQueryInfo(MultipleChoiceCandidateAnswer, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", MultipleChoiceCandidateAnswer.Id)
            .AddLogByParameter();

        private IProcessResult<IMultipleChoiceCandidateAnswer> GetProcessResult(IMultipleChoiceCandidateAnswer data, SqlCommand command, int affectedRows)
        {
            return affectedRows > 0 ? new ProcessResult<IMultipleChoiceCandidateAnswer>(data) : new ProcessResult<IMultipleChoiceCandidateAnswer>(ProcessResultStatus.Failed, "Faiedl to delete multiple choice candidate answer.");
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
