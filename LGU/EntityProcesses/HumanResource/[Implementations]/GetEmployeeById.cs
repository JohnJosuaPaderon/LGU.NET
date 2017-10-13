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
    public sealed class GetEmployeeById : EmployeeProcess, IGetEmployeeById
    {
        public GetEmployeeById(IConnectionStringSource connectionStringSource, IEmployeeConverter<SqlDataReader> converter, IEmployeeParameters parameters) : base(connectionStringSource, converter)
        {
            _Parameters = parameters;
        }

        private readonly IEmployeeParameters _Parameters;

        public long EmployeeId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter(_Parameters.Id, EmployeeId);

        public IProcessResult<IEmployee> Execute()
        {
            _Converter.PId.Value = EmployeeId;
            return _SqlHelper.ExecuteReader(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IEmployee>> ExecuteAsync()
        {
            _Converter.PId.Value = EmployeeId;
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IEmployee>> ExecuteAsync(CancellationToken cancellationToken)
        {
            _Converter.PId.Value = EmployeeId;
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
