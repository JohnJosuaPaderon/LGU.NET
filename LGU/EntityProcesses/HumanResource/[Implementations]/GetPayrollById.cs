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
    public sealed class GetPayrollById : HumanResourceProcessBaseV2, IGetPayrollById
    {
        public GetPayrollById(IConnectionStringSource connectionStringSource, IPayrollConverter<SqlDataReader> converter, IPayrollParameters parameters) : base(connectionStringSource)
        {
            _Converter = converter;
            _Parameters = parameters;
        }

        private readonly IPayrollConverter<SqlDataReader> _Converter;
        private readonly IPayrollParameters _Parameters;

        public long PayrollId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter(_Parameters.Id, PayrollId);

        public IProcessResult<IPayroll> Execute()
        {
            _Converter.PId.Value = PayrollId;
            return _SqlHelper.ExecuteReader(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IPayroll>> ExecuteAsync()
        {
            _Converter.PId.Value = PayrollId;
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IPayroll>> ExecuteAsync(CancellationToken cancellationToken)
        {
            _Converter.PId.Value = PayrollId;
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
