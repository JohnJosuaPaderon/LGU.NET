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
    public sealed class GetEmployeeListWithTimeLogByDepartment : HumanResourceProcessBaseV2, IGetEmployeeListWithTimeLogByDepartment
    {
        private const string PARAM_CUT_OFF_BEGIN = "@_CutOffBegin";
        private const string PARAM_CUT_OFF_END = "@_CutOffEnd";

        public GetEmployeeListWithTimeLogByDepartment(IConnectionStringSource connectionStringSource, IEmployeeParameters parameters, IEmployeeConverter converter) : base(connectionStringSource)
        {
            _Parameters = parameters;
            _Converter = converter;
            _Converter.PSecureBankAccountNumber.Value = null;
        }

        private readonly IEmployeeParameters _Parameters;
        private readonly IEmployeeConverter _Converter;

        public ValueRange<DateTime> CutOff { get; set; }
        public IDepartment Department { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter(_Parameters.DepartmentId, Department?.Id)
            .AddInputParameter(PARAM_CUT_OFF_BEGIN, CutOff.Begin)
            .AddInputParameter(PARAM_CUT_OFF_END, CutOff.End);

        public IEnumerableProcessResult<IEmployee> Execute()
        {
            _Converter.PDepartment.Value = Department;
            return _SqlHelper.ExecuteReaderEnumerable(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IEmployee>> ExecuteAsync()
        {
            _Converter.PDepartment.Value = Department;
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IEmployee>> ExecuteAsync(CancellationToken cancellationToken)
        {
            _Converter.PDepartment.Value = Department;
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
