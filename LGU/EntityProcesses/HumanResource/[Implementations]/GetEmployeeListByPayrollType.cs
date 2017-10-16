using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetEmployeeListByPayrollType : HumanResourceProcessBaseV2, IGetEmployeeListByPayrollType
    {
        public GetEmployeeListByPayrollType(IConnectionStringSource connectionStringSource, IEmployeeConverter converter, IEmployeeParameters parameters) : base(connectionStringSource)
        {
            _Parameters = parameters;
            _Converter = converter;
        }

        private readonly IEmployeeConverter _Converter;
        private readonly IEmployeeParameters _Parameters;

        public IPayrollType PayrollType { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(nameof(GetEmployeeListByPayrollType))
            .AddInputParameter(_Parameters.PayrollTypeId, PayrollType.Id);

        public IEnumerableProcessResult<IEmployee> Execute()
        {
            _Converter.PPayrollType.Value = PayrollType;
            return _SqlHelper.ExecuteReaderEnumerable(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IEmployee>> ExecuteAsync()
        {
            _Converter.PPayrollType.Value = PayrollType;
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IEmployee>> ExecuteAsync(CancellationToken cancellationToken)
        {
            _Converter.PPayrollType.Value = PayrollType;
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
