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
    public sealed class InsertSalaryGradeBatch : SalaryGradeBatchProcess, IInsertSalaryGradeBatch
    {
        public InsertSalaryGradeBatch(IConnectionStringSource connectionStringSource, ISalaryGradeBatchConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public ISalaryGradeBatch SalaryGradeBatch { get; set; }

        private SqlQueryInfo<ISalaryGradeBatch> QueryInfo =>
            SqlQueryInfo<ISalaryGradeBatch>.CreateProcedureQueryInfo(SalaryGradeBatch, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int32)
            .AddInputParameter("@_EffectivityDate", SalaryGradeBatch.EffectivityDate)
            .AddInputParameter("@_ExpiryDate", SalaryGradeBatch.ExpiryDate)
            .AddInputParameter("@_Description", SalaryGradeBatch.Description)
            .AddLogByParameter();

        private IProcessResult<ISalaryGradeBatch> GetProcessResult(ISalaryGradeBatch data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt32("@_Id");
                return new ProcessResult<ISalaryGradeBatch>(data);
            }
            else
            {
                return new ProcessResult<ISalaryGradeBatch>(ProcessResultStatus.Failed, "Failed to insert salary grade batch.");
            }
        }

        public IProcessResult<ISalaryGradeBatch> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<ISalaryGradeBatch>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<ISalaryGradeBatch>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
