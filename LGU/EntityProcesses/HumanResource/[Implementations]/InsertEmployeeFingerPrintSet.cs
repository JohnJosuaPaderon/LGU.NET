using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class InsertEmployeeFingerPrintSet : HumanResourceProcessBase, IInsertEmployeeFingerPrintSet
    {
        public InsertEmployeeFingerPrintSet(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public EmployeeFingerPrintSet FingerPrintSet { get; set; }

        private SqlDataQueryInfo<EmployeeFingerPrintSet> QueryInfo
        {
            get
            {
                return SqlDataQueryInfo<EmployeeFingerPrintSet>.CreateProcedureQueryInfo(FingerPrintSet, "HumanResource.InsertEmployeeFingerPrintSet", GetProcessResult, true)
                    .AddInputParameter("@_Id", FingerPrintSet.Employee?.Id)
                    .AddInputParameter("@_LeftThumb", FingerPrintSet.LeftThumb?.Data?.Bytes)
                    .AddInputParameter("@_LeftIndexFinger", FingerPrintSet.LeftIndexFinger?.Data?.Bytes)
                    .AddInputParameter("@_LeftMiddleFinger", FingerPrintSet.LeftMiddleFinger?.Data?.Bytes)
                    .AddInputParameter("@_LeftRingFinger", FingerPrintSet.LeftRingFinger?.Data?.Bytes)
                    .AddInputParameter("@_LeftLittleFinger", FingerPrintSet.LeftLittleFinger?.Data?.Bytes)
                    .AddInputParameter("@_RightThumb", FingerPrintSet.RightThumb?.Data?.Bytes)
                    .AddInputParameter("@_RightIndexFinger", FingerPrintSet.RightIndexFinger?.Data?.Bytes)
                    .AddInputParameter("@_RightMiddleFinger", FingerPrintSet.RightMiddleFinger?.Data?.Bytes)
                    .AddInputParameter("@_RightRingFinger", FingerPrintSet.RightRingFinger?.Data?.Bytes)
                    .AddInputParameter("@_RightLittleFinger", FingerPrintSet.RightLittleFinger?.Data?.Bytes);
            }
        }

        private IDataProcessResult<EmployeeFingerPrintSet> GetProcessResult(EmployeeFingerPrintSet data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                return new DataProcessResult<EmployeeFingerPrintSet>(data, ProcessResultStatus.Success);
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
