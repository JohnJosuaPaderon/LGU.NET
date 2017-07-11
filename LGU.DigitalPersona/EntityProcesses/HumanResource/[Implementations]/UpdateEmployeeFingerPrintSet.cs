using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class UpdateEmployeeFingerPrintSet : HumanResourceProcessBase, IUpdateEmployeeFingerPrintSet
    {
        public UpdateEmployeeFingerPrintSet(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public EmployeeFingerPrintSet FingerPrintSet { get; set; }

        private SqlDataQueryInfo<EmployeeFingerPrintSet> QueryInfo
        {
            get
            {
                return SqlDataQueryInfo<EmployeeFingerPrintSet>.CreateProcedureQueryInfo(FingerPrintSet, GetQualifiedDbObjectName("UpdateEmployeeFingerPrintSet"), GetProcessResult, true)
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
            }
        }

        private IDataProcessResult<EmployeeFingerPrintSet> GetProcessResult(EmployeeFingerPrintSet data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new DataProcessResult<EmployeeFingerPrintSet>(data);
            }
            else
            {
                return new DataProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public IDataProcessResult<EmployeeFingerPrintSet> Execute()
        {
            return SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IDataProcessResult<EmployeeFingerPrintSet>> ExecuteAsync()
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IDataProcessResult<EmployeeFingerPrintSet>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
