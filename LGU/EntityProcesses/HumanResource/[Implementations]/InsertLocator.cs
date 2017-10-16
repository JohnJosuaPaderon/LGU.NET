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
    public sealed class InsertLocator : LocatorProcess, IInsertLocator
    {
        public InsertLocator(IConnectionStringSource connectionStringSource, ILocatorConverter converter) : base(connectionStringSource, converter)
        {
        }

        public ILocator Locator { get; set; }

        private SqlQueryInfo<ILocator> QueryInfo =>
            SqlQueryInfo<ILocator>.CreateProcedureQueryInfo(Locator, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int64)
            .AddInputParameter("@_RequestorId", Locator.Requestor?.Id)
            .AddInputParameter("@_OfficeOutTime", Locator.OfficeOutTime)
            .AddInputParameter("@_ExpectedReturnTime", Locator.ExpectedReturnTime)
            .AddInputParameter("@_LeaveTypeId", Locator.LeaveType?.Id)
            .AddInputParameter("@_Purpose", Locator.Purpose)
            .AddInputParameter("@_Date", Locator.Date)
            .AddInputParameter("@_DepartmentHead", Locator.DepartmentHead)
            .AddLogByParameter();

        private IProcessResult<ILocator> GetProcessResult(ILocator data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64("@_Id");
                return new ProcessResult<ILocator>(Locator);
            }
            else
            {
                return new ProcessResult<ILocator>(ProcessResultStatus.Failed, "Failed to insert locator.");
            }
        }

        public IProcessResult<ILocator> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<ILocator>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<ILocator>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
