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
    public sealed class DeleteMultipleChoiceQuestion : MultipleChoiceQuestionProcess, IDeleteMultipleChoiceQuestion
    {
        public DeleteMultipleChoiceQuestion(IConnectionStringSource connectionStringSource, IMultipleChoiceQuestionConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public MultipleChoiceQuestion MultipleChoiceQuestion { get; set; }

        private SqlQueryInfo<MultipleChoiceQuestion> QueryInfo =>
            SqlQueryInfo<MultipleChoiceQuestion>.CreateProcedureQueryInfo(MultipleChoiceQuestion, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", MultipleChoiceQuestion.Id)
            .AddLogByParameter();

        private IProcessResult<MultipleChoiceQuestion> GetProcessResult(MultipleChoiceQuestion data, SqlCommand command, int affectedRows)
        {
            return affectedRows > 0 ? new ProcessResult<MultipleChoiceQuestion>(data) : new ProcessResult<MultipleChoiceQuestion>(ProcessResultStatus.Failed, "Failed to delete multiple choice question.");
        }

        public IProcessResult<MultipleChoiceQuestion> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<MultipleChoiceQuestion>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<MultipleChoiceQuestion>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
