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
    public sealed class DeleteSalaryGrade : SalaryGradeProcess, IDeleteSalaryGrade
    {
        public DeleteSalaryGrade(IConnectionStringSource connectionStringSource, ISalaryGradeConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public ISalaryGrade SalaryGrade { get; set; }

        private SqlQueryInfo<ISalaryGrade> QueryInfo =>
            SqlQueryInfo<ISalaryGrade>.CreateProcedureQueryInfo(SalaryGrade, GetQualifiedDbObjectName(), GetProcessResult, true)
                .AddInputParameter("@_Id", SalaryGrade.Id)
                .AddLogByParameter();

        private IProcessResult<ISalaryGrade> GetProcessResult(ISalaryGrade SalaryGrade, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<ISalaryGrade>(SalaryGrade);
            }
            else
            {
                return new ProcessResult<ISalaryGrade>(ProcessResultStatus.Failed, "Failed to delete salary grade.");
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
