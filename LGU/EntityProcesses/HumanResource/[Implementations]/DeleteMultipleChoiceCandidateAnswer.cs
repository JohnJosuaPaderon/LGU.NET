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

        public MultipleChoiceCandidateAnswer MultipleChoiceCandidateAnswer { get; set; }

        private SqlQueryInfo<MultipleChoiceCandidateAnswer> QueryInfo =>
            SqlQueryInfo<MultipleChoiceCandidateAnswer>.CreateProcedureQueryInfo(MultipleChoiceCandidateAnswer, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", MultipleChoiceCandidateAnswer.Id)
            .AddLogByParameter();

        private IProcessResult<MultipleChoiceCandidateAnswer> GetProcessResult(MultipleChoiceCandidateAnswer data, SqlCommand command, int affectedRows)
        {
            return affectedRows > 0 ? new ProcessResult<MultipleChoiceCandidateAnswer>(data) : new ProcessResult<MultipleChoiceCandidateAnswer>(ProcessResultStatus.Failed, "Faiedl to delete multiple choice candidate answer.");
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
