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
    public sealed class DeleteExamSet : ExamSetProcess, IDeleteExamSet
    {
        public DeleteExamSet(IConnectionStringSource connectionStringSource, IExamSetConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public ExamSet ExamSet { get; set; }

        private SqlQueryInfo<ExamSet> QueryInfo =>
            SqlQueryInfo<ExamSet>.CreateProcedureQueryInfo(ExamSet, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", ExamSet.Id)
            .AddLogByParameter();

        private IProcessResult<ExamSet> GetProcessResult(ExamSet data, SqlCommand command, int affectedRows)
        {
            return affectedRows > 0 ? new ProcessResult<ExamSet>(data) : new ProcessResult<ExamSet>(ProcessResultStatus.Failed, "Failed to delete exam set.");
        }

        public IProcessResult<ExamSet> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<ExamSet>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<ExamSet>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
