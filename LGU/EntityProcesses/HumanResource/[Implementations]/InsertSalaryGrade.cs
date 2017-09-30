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
    public sealed class InsertSalaryGrade : SalaryGradeProcess, IInsertSalaryGrade
    {
        public InsertSalaryGrade(IConnectionStringSource connectionStringSource, ISalaryGradeConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public ISalaryGrade SalaryGrade { get; set; }

        private SqlQueryInfo<ISalaryGrade> QueryInfo =>
            SqlQueryInfo<ISalaryGrade>.CreateProcedureQueryInfo(SalaryGrade, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int64)
            .AddInputParameter("@_Number", SalaryGrade.Number)
            .AddInputParameter("@_BatchId", SalaryGrade.Batch?.Id)
            .AddLogByParameter();

        private IProcessResult<ISalaryGrade> GetProcessResult(ISalaryGrade data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64("@_Id");
                return new ProcessResult<ISalaryGrade>(SalaryGrade);
            }
            else
            {
                return new ProcessResult<ISalaryGrade>(ProcessResultStatus.Failed, "Failed to insert salary grade.");
            }
        }

        public IProcessResult<ISalaryGrade> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<ISalaryGrade>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<ISalaryGrade>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
