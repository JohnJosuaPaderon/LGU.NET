using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class InsertPayroll : HumanResourceProcessBase, IInsertPayroll<SqlConnection, SqlTransaction>
    {
        private const string MESSAGE_FAILED = "Failed to insert payroll.";
        private const string PARAMETER_ID = "@_Id";
        private const string PARAMETER_TYPE_ID = "@_TypeId";
        private const string PARAMETER_CUT_OFF_ID = "@_CutOffId";
        private const string PARAMETER_RANGE_DATE_BEGIN = "@_RangeDateBegin";
        private const string PARAMETER_RANGE_DATE_END = "@_RangeDateEnd";
        private const string PARAMETER_RUN_DATE = "@_RunDate";
        private const string PARAMETER_HUMAN_RESOURCE_HEAD_ID = "@_HumanResourceHeadId";
        private const string PARAMETER_MAYOR_ID = "@_MayorId";
        private const string PARAMETER_TREASURER_ID = "@_TreasurerId";
        private const string PARAMETER_CITY_ACCOUNTANT_ID = "@_CityAccountantId";
        private const string PARAMETER_CITY_BUDGET_OFFICER_ID = "@_CityBudgetOfficerId";

        public InsertPayroll(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public IPayroll Payroll { get; set; }

        private SqlQueryInfo<IPayroll> QueryInfo =>
            SqlQueryInfo<IPayroll>.CreateProcedureQueryInfo(Payroll, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter(PARAMETER_ID, DbType.Int64)
            .AddInputParameter(PARAMETER_TYPE_ID, Payroll.Type?.Id)
            .AddInputParameter(PARAMETER_CUT_OFF_ID, Payroll.CutOff?.Id)
            .AddInputParameter(PARAMETER_RANGE_DATE_BEGIN, Payroll.RangeDate.Begin)
            .AddInputParameter(PARAMETER_RANGE_DATE_END, Payroll.RangeDate.End)
            .AddInputParameter(PARAMETER_RUN_DATE, Payroll.RunDate)
            .AddInputParameter(PARAMETER_HUMAN_RESOURCE_HEAD_ID, Payroll.HumanResourceHead?.Id)
            .AddInputParameter(PARAMETER_MAYOR_ID, Payroll.Mayor?.Id)
            .AddInputParameter(PARAMETER_TREASURER_ID, Payroll.Treasurer?.Id)
            .AddInputParameter(PARAMETER_CITY_ACCOUNTANT_ID, Payroll.CityAccountant?.Id)
            .AddInputParameter(PARAMETER_CITY_BUDGET_OFFICER_ID, Payroll.CityBudgetOfficer?.Id)
            .AddLogByParameter();

        private IProcessResult<IPayroll> GetProcessResult(IPayroll data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64(PARAMETER_ID);
                return new ProcessResult<IPayroll>(data);
            }
            else
            {
                return new ProcessResult<IPayroll>(ProcessResultStatus.Failed, MESSAGE_FAILED);
            }
        }

        public IProcessResult<IPayroll> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IPayroll>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IPayroll>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }

        public IProcessResult<IPayroll> Execute(SqlConnection connection, SqlTransaction transaction)
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo, connection, transaction);
        }

        public Task<IProcessResult<IPayroll>> ExecuteAsync(SqlConnection connection, SqlTransaction transaction)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, connection, transaction);
        }

        public Task<IProcessResult<IPayroll>> ExecuteAsync(SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, connection, transaction, cancellationToken);
        }
    }
}
