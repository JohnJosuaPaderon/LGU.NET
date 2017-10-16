using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GeneratePayrollContractualEmployeeList : HumanResourceProcessBaseV2, IGeneratePayrollContractualEmployeeList
    {
        private const string PARAM_CUT_OFF_BEGIN = "@_CutOffBegin";
        private const string PARAM_CUT_OFF_END = "@_CutOffEnd";

        public GeneratePayrollContractualEmployeeList(IConnectionStringSource connectionStringSource, IPayrollContractualEmployeeConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }

        private readonly IPayrollContractualEmployeeConverter _Converter;

        public ValueRange<DateTime> CutOff { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter(PARAM_CUT_OFF_BEGIN, CutOff.Begin)
            .AddInputParameter(PARAM_CUT_OFF_END, CutOff.End);

        public IEnumerableProcessResult<IPayrollContractualEmployee> Execute()
        {
            _Converter.PPayroll.Value = null;
            _Converter.PWithholdingTax.Value = null;

            return _SqlHelper.ExecuteReaderEnumerable(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IPayrollContractualEmployee>> ExecuteAsync()
        {
            _Converter.PPayroll.Value = null;
            _Converter.PWithholdingTax.Value = null;

            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IPayrollContractualEmployee>> ExecuteAsync(CancellationToken cancellationToken)
        {
            _Converter.PPayroll.Value = null;
            _Converter.PWithholdingTax.Value = null;

            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
