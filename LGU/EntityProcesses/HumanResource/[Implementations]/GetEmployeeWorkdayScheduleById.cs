using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetEmployeeWorkdayScheduleById : HumanResourceProcessBaseV2, IGetEmployeeWorkdayScheduleById
    {
        private const string PARAM_ID = "@_Id";

        public GetEmployeeWorkdayScheduleById(IConnectionStringSource connectionStringSource, IEmployeeWorkdayScheduleConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }

        public long EmployeeWorkdayScheduleId { get; set; }

        private readonly IEmployeeWorkdayScheduleConverter _Converter;

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter(PARAM_ID, EmployeeWorkdayScheduleId);

        public IProcessResult<IEmployeeWorkdaySchedule> Execute()
        {
            _Converter.Prop_Id.Value = EmployeeWorkdayScheduleId;
            return _SqlHelper.ExecuteReader(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IEmployeeWorkdaySchedule>> ExecuteAsync()
        {
            _Converter.Prop_Id.Value = EmployeeWorkdayScheduleId;
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IEmployeeWorkdaySchedule>> ExecuteAsync(CancellationToken cancellationToken)
        {
            _Converter.Prop_Id.Value = EmployeeWorkdayScheduleId;
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
