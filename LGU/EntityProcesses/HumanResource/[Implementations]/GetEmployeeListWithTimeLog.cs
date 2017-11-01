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
    public sealed class GetEmployeeListWithTimeLog : HumanResourceProcessBaseV2, IGetEmployeeListWithTimeLog
    {
        private const string PARAM_CUT_OFF_BEGIN = "@_CutOffBegin";
        private const string PARAM_CUT_OFF_END = "@_CutOffEnd";

        public GetEmployeeListWithTimeLog(IConnectionStringSource connectionStringSource, IEmployeeConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }

        private readonly IEmployeeConverter _Converter;

        public ValueRange<DateTime> CutOff { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter(PARAM_CUT_OFF_BEGIN, CutOff.Begin)
            .AddInputParameter(PARAM_CUT_OFF_END, CutOff.End);

        public IEnumerableProcessResult<IEmployee> Execute()
        {
            return _SqlHelper.ExecuteReaderEnumerable(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IEmployee>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IEmployee>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
