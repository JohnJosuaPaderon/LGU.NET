using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetEmployeeWorkdayScheduleByEmployee : HumanResourceProcessBaseV2, IGetEmployeeWorkdayScheduleByEmployee
    {
        public GetEmployeeWorkdayScheduleByEmployee(
            IConnectionStringSource connectionStringSource,
            IEmployeeWorkdayScheduleConverter converter,
            IEmployeeWorkdayScheduleParameters parameters) : base(connectionStringSource)
        {
            _Converter = converter;
            _Parameters = parameters;
        }

        private readonly IEmployeeWorkdayScheduleConverter _Converter;
        private readonly IEmployeeWorkdayScheduleParameters _Parameters;

        public IEmployee Employee { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter(_Parameters.EmployeeId, Employee?.Id);

        public IProcessResult<IEmployeeWorkdaySchedule> Execute()
        {
            _Converter.Prop_Employee.Value = Employee;
            return _SqlHelper.ExecuteReader(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IEmployeeWorkdaySchedule>> ExecuteAsync()
        {
            _Converter.Prop_Employee.Value = Employee;
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IEmployeeWorkdaySchedule>> ExecuteAsync(CancellationToken cancellationToken)
        {
            _Converter.Prop_Employee.Value = Employee;
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
