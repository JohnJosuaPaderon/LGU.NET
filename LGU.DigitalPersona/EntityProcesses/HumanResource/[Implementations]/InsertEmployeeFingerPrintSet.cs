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
    public sealed class InsertEmployeeFingerPrintSet : EmployeeFingerPrintSetProcess, IInsertEmployeeFingerPrintSet
    {
        public InsertEmployeeFingerPrintSet(IConnectionStringSource connectionStringSource, IEmployeeFingerPrintSetConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public EmployeeFingerPrintSet FingerPrintSet { get; set; }

        private SqlQueryInfo<EmployeeFingerPrintSet> QueryInfo =>
            SqlQueryInfo<EmployeeFingerPrintSet>.CreateProcedureQueryInfo(FingerPrintSet, GetQualifiedDbObjectName("InsertEmployeeFingerPrintSet"), GetProcessResult, true)
            .AddInputParameter("@_Id", FingerPrintSet.Employee?.Id)
            .AddInputParameter("@_LeftThumb", FingerPrintSet.LeftThumb?.Data?.Bytes, SqlDbType.VarBinary)
            .AddInputParameter("@_LeftIndexFinger", FingerPrintSet.LeftIndexFinger?.Data?.Bytes, SqlDbType.VarBinary)
            .AddInputParameter("@_LeftMiddleFinger", FingerPrintSet.LeftMiddleFinger?.Data?.Bytes, SqlDbType.VarBinary)
            .AddInputParameter("@_LeftRingFinger", FingerPrintSet.LeftRingFinger?.Data?.Bytes, SqlDbType.VarBinary)
            .AddInputParameter("@_LeftLittleFinger", FingerPrintSet.LeftLittleFinger?.Data?.Bytes, SqlDbType.VarBinary)
            .AddInputParameter("@_RightThumb", FingerPrintSet.RightThumb?.Data?.Bytes, SqlDbType.VarBinary)
            .AddInputParameter("@_RightIndexFinger", FingerPrintSet.RightIndexFinger?.Data?.Bytes, SqlDbType.VarBinary)
            .AddInputParameter("@_RightMiddleFinger", FingerPrintSet.RightMiddleFinger?.Data?.Bytes, SqlDbType.VarBinary)
            .AddInputParameter("@_RightRingFinger", FingerPrintSet.RightRingFinger?.Data?.Bytes, SqlDbType.VarBinary)
            .AddInputParameter("@_RightLittleFinger", FingerPrintSet.RightLittleFinger?.Data?.Bytes, SqlDbType.VarBinary)
            .AddLogByParameter();

        private IProcessResult<EmployeeFingerPrintSet> GetProcessResult(EmployeeFingerPrintSet data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                return new ProcessResult<EmployeeFingerPrintSet>(data, ProcessResultStatus.Success);
            }
            else
            {
                return new ProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }

        }

        public IProcessResult<EmployeeFingerPrintSet> Execute()
        {
            return SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<EmployeeFingerPrintSet>> ExecuteAsync()
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<EmployeeFingerPrintSet>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
