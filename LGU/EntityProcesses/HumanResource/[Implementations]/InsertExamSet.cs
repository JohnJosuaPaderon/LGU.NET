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

        public IExamSet ExamSet { get; set; }

        private SqlQueryInfo<IExamSet> QueryInfo =>
            SqlQueryInfo<IExamSet>.CreateProcedureQueryInfo(ExamSet, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int64)
            .AddInputParameter("@_Description", ExamSet.Description)
            .AddInputParameter("@_PassingScore", ExamSet.PassingScore)
            .AddLogByParameter();

        private IProcessResult<IExamSet> GetProcessResult(IExamSet data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt32("@_Id");
                return new ProcessResult<IExamSet>(data);
            }
            else
            {
                return new ProcessResult<IExamSet>(ProcessResultStatus.Failed, "Failed to insert exam set.");
            }
        }

        public IProcessResult<IExamSet> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IExamSet>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IExamSet>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
