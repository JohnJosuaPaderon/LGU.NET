using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetPayrollCutOffById : HumanResourceProcessBase, IGetPayrollCutOffById
    {
        private const string FIELD_ID = "@_Id";

        public GetPayrollCutOffById(IConnectionStringSource connectionStringSource, IPayrollCutOffConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }

        private readonly IPayrollCutOffConverter _Converter;

        public short PayrollCutOffId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter(FIELD_ID, PayrollCutOffId);

        public IProcessResult<IPayrollCutOff> Execute()
        {
            return _SqlHelper.ExecuteReader(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IPayrollCutOff>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IPayrollCutOff>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
