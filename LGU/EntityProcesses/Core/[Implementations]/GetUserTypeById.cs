using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class GetUserTypeById : UserTypeProcess, IGetUserTypeById
    {
        public GetUserTypeById(IConnectionStringSource connectionStringSource, IUserTypeConverter converter) : base(connectionStringSource, converter)
        {
        }

        public short UserTypeId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_Id", UserTypeId);

        public IProcessResult<IUserType> Execute()
        {
            return _SqlHelper.ExecuteReader(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IUserType>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IUserType>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
