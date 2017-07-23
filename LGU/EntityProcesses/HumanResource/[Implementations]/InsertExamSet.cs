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
    public sealed class InsertExamSet : ExamSetProcess, IInsertExamSet
    {
        public InsertExamSet(IConnectionStringSource connectionStringSource, IExamSetConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public ExamSet ExamSet { get; set; }

        private SqlQueryInfo<ExamSet> QueryInfo =>
            SqlQueryInfo<ExamSet>.CreateProcedureQueryInfo(ExamSet, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int64)
            .AddInputParameter("@_Description", ExamSet.Description)
            .AddInputParameter("@_PassingScore", ExamSet.PassingScore)
            .AddLogByParameter();

        private IProcessResult<ExamSet> GetProcessResult(ExamSet data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt32("@_Id");
                return new ProcessResult<ExamSet>(data);
            }
            else
            {
                return new ProcessResult<ExamSet>(ProcessResultStatus.Failed, "Failed to insert exam set.");
            }
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
