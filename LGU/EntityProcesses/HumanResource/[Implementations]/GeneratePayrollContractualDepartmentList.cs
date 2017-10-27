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
    public sealed class GeneratePayrollContractualDepartmentList : HumanResourceProcessBaseV2, IGeneratePayrollContractualDepartmentList
    {
        private const string PARAM_CUT_OFF_BEGIN = "@_CutOffBegin";
        private const string PARAM_CUT_OFF_END = "@_CutOffEnd";

        public GeneratePayrollContractualDepartmentList(IConnectionStringSource connectionStringSource, IGeneratePayrollContractualEmployeeListByDepartment getEmployees, IPayrollContractualDepartmentConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
            _GetEmployees = getEmployees;

            _Converter.GetEmployees = getEmployees;
            _Converter.GetEmployeesInitializer = GetEmployeesInitializer;
        }

        private readonly IPayrollContractualDepartmentConverter _Converter;
        private IGeneratePayrollContractualEmployeeListByDepartment _GetEmployees;

        public ValueRange<DateTime> CutOff { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter(PARAM_CUT_OFF_BEGIN, CutOff.Begin)
            .AddInputParameter(PARAM_CUT_OFF_END, CutOff.End);

        private void GetEmployeesInitializer((IDepartment Department, IDepartmentHead Head) arg)
        {
            _GetEmployees.CutOff = CutOff;
            _GetEmployees.Department = arg.Department;
        }

        public IEnumerableProcessResult<IPayrollContractualDepartment> Execute()
        {
            _Converter.PPayroll.Value = null;
            return _SqlHelper.ExecuteReaderEnumerable(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IPayrollContractualDepartment>> ExecuteAsync()
        {
            _Converter.PPayroll.Value = null;
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IPayrollContractualDepartment>> ExecuteAsync(CancellationToken cancellationToken)
        {
            _Converter.PPayroll.Value = null;
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
