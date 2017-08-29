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

        public IExamSet ExamSet { get; set; }

        private SqlQueryInfo<IExamSet> QueryInfo =>
            SqlQueryInfo<IExamSet>.CreateProcedureQueryInfo(ExamSet, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", ExamSet.Id)
            .AddLogByParameter();

        private IProcessResult<IExamSet> GetProcessResult(IExamSet data, SqlCommand command, int affectedRows)
        {
            return affectedRows > 0 ? new ProcessResult<IExamSet>(data) : new ProcessResult<IExamSet>(ProcessResultStatus.Failed, "Failed to delete exam set.");
        }

        public IProcessResult<IExamSet> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IExamSet>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IExamSet>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
