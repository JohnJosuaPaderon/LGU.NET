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
    public sealed class GeneratePayrollContractualEmployeeListByDepartment : HumanResourceProcessBaseV2, IGeneratePayrollContractualEmployeeListByDepartment
    {
        private const string PARAM_DEPARTMENT_ID = "@_DepartmentId";
        private const string PARAM_CUT_OFF_BEGIN = "@_CutOffBegin";
        private const string PARAM_CUT_OFF_END = "@_CutOffEnd";

        public GeneratePayrollContractualEmployeeListByDepartment(IConnectionStringSource connectionStringSource, IPayrollContractualEmployeeConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;

            _Converter.PDepartment.Value = null;
        }

        private IPayrollContractualEmployeeConverter _Converter;

        public IDepartment Department { get; set; }
        public ValueRange<DateTime> CutOff { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter(PARAM_DEPARTMENT_ID, Department.Id)
            .AddInputParameter(PARAM_CUT_OFF_BEGIN, CutOff.Begin)
            .AddInputParameter(PARAM_CUT_OFF_END, CutOff.End);

        public IEnumerableProcessResult<IPayrollContractualEmployee> Execute()
        {
            _Converter.PId.Value = 0;
            return _SqlHelper.ExecuteReaderEnumerable(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IPayrollContractualEmployee>> ExecuteAsync()
        {
            _Converter.PId.Value = 0;
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IPayrollContractualEmployee>> ExecuteAsync(CancellationToken cancellationToken)
        {
            _Converter.PId.Value = 0;
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
