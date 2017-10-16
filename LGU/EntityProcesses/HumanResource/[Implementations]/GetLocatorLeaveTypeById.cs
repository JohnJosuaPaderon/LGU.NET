using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetLocatorLeaveTypeById : LocatorLeaveTypeProcess, IGetLocatorLeaveTypeById
    {
        public GetLocatorLeaveTypeById(IConnectionStringSource connectionStringSource, ILocatorLeaveTypeConverter converter) : base(connectionStringSource, converter)
        {
        }

        public short LocatorLeaveTypeId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
                .AddInputParameter("@_Id", LocatorLeaveTypeId);

        public IProcessResult<ILocatorLeaveType> Execute()
        {
            return _SqlHelper.ExecuteReader(QueryInfo, _Converter);
        }

        public Task<IProcessResult<ILocatorLeaveType>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter);
        }

        public Task<IProcessResult<ILocatorLeaveType>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
