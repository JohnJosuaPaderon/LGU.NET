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
    public sealed class GetLocatorLeaveTypeById : LocatorLeaveTypeProcess, IGetLocatorLeaveTypeById
    {
        public GetLocatorLeaveTypeById(IConnectionStringSource connectionStringSource, ILocatorLeaveTypeConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public short LocatorLeaveTypeId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
                .AddInputParameter("@_Id", LocatorLeaveTypeId);

        public IProcessResult<LocatorLeaveType> Execute()
        {
            return r_SqlHelper.ExecuteReader(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<LocatorLeaveType>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<LocatorLeaveType>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter, cancellationToken);
        }
    }
}
