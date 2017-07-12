using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.Core;
using LGU.EntityProcessHelpers.Core;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class GetGenderById : CoreProcessBase, IGetGenderById
    {
        public GetGenderById(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public short GenderId { get; set; }

        private SqlQueryInfo QueryInfo
        {
            get
            {
                return SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName("GetGenderById"), GetProcessResult)
                    .AddInputParameter("@_GenderId", GenderId);
            }
        }

        private IProcessResult GetProcessResult(SqlCommand command, int affectedRows)
        {
            return new ProcessResult(ProcessResultStatus.Success);
        }

        public IDataProcessResult<Gender> Execute()
        {
            return SqlHelper.ExecuteReader(QueryInfo, GenderProcessHelper.FromReader);
        }

        public Task<IDataProcessResult<Gender>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderAsync(QueryInfo, GenderProcessHelper.FromReaderAsync);
        }

        public Task<IDataProcessResult<Gender>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderAsync(QueryInfo, GenderProcessHelper.FromReaderAsync, cancellationToken);
        }
    }
}
