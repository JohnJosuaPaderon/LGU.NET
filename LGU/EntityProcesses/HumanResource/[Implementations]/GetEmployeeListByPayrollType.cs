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
    public sealed class GetEmployeeListByPayrollType : HumanResourceProcessBaseV2, IGetEmployeeListByPayrollType
    {
        private const string PARAM_PAYROLL_TYPE_ID = "@_PayrollTypeId";

        public GetEmployeeListByPayrollType(IConnectionStringSource connectionStringSource, IEmployeeConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }

        private readonly IEmployeeConverter<SqlDataReader> _Converter;

        public IPayrollType PayrollType { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(nameof(GetEmployeeListByPayrollType))
            .AddInputParameter(PARAM_PAYROLL_TYPE_ID, PayrollType.Id);

        public IEnumerableProcessResult<IEmployee> Execute()
        {
            _Converter.Prop_PayrollType.Value = PayrollType;
            return _SqlHelper.ExecuteReaderEnumerable(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IEmployee>> ExecuteAsync()
        {
            _Converter.Prop_PayrollType.Value = PayrollType;
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IEmployee>> ExecuteAsync(CancellationToken cancellationToken)
        {
            _Converter.Prop_PayrollType.Value = PayrollType;
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
