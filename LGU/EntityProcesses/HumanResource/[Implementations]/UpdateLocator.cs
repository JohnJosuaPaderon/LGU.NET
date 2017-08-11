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
    public sealed class UpdateLocator : LocatorProcess, IUpdateLocator
    {
        public UpdateLocator(IConnectionStringSource connectionStringSource, ILocatorConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public Locator Locator { get; set; }

        public SqlQueryInfo<Locator> QueryInfo =>
            SqlQueryInfo<Locator>.CreateProcedureQueryInfo(Locator, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Locator.Id)
            .AddInputParameter("@_RequestorId", Locator.Requestor?.Id)
            .AddInputParameter("@_OfficeOutTime", Locator.OfficeOutTime)
            .AddInputParameter("@_ExpectedReturnTime", Locator.ExpectedReturnTime)
            .AddInputParameter("@_LeaveTypeId", Locator.LeaveType?.Id)
            .AddInputParameter("@_Purpose", Locator.Purpose)
            .AddInputParameter("@_Date", Locator.Date)
            .AddLogByParameter();

        private IProcessResult<Locator> GetProcessResult(Locator data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<Locator>(Locator);
            }
            else
            {
                return new ProcessResult<Locator>(ProcessResultStatus.Failed, "Failed to update locator.");
            }
        }

        public IProcessResult<Locator> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<Locator>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<Locator>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
