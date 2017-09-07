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
    public sealed class GetCurrentSalaryGradeStepByEmployee : SalaryGradeStepProcess, IGetCurrentSalaryGradeStepByEmployee
    {
        public GetCurrentSalaryGradeStepByEmployee(IConnectionStringSource connectionStringSource, ISalaryGradeStepConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IEmployee Employee { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_EmployeeId", Employee?.Id);

        public IProcessResult<ISalaryGradeStep> Execute()
        {
            return r_SqlHelper.ExecuteReader(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<ISalaryGradeStep>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<ISalaryGradeStep>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter, cancellationToken);
        }
    }
}
