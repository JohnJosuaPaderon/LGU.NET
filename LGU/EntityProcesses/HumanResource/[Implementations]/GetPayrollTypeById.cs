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
    public sealed class GetPayrollTypeById : HumanResourceProcessBase, IGetPayrollTypeById
    {
        private const string PARAMETER_ID = "@_Id";

        public GetPayrollTypeById(IConnectionStringSource connectionStringSource, IPayrollTypeConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }

        private readonly IPayrollTypeConverter<SqlDataReader> _Converter;

        public short PayrollTypeId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter(PARAMETER_ID, PayrollTypeId);

        public IProcessResult<IPayrollType> Execute()
        {
            return _SqlHelper.ExecuteReader(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IPayrollType>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IPayrollType>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
