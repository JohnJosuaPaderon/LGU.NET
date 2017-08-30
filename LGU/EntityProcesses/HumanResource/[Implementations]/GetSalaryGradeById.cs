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
    public sealed class GetSalaryGradeById : SalaryGradeProcess, IGetSalaryGradeById
    {
        public GetSalaryGradeById(IConnectionStringSource connectionStringSource, ISalaryGradeConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public long SalaryGradeId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
                .AddInputParameter("@_Id", SalaryGradeId);

        public IProcessResult<ISalaryGrade> Execute()
        {
            return r_SqlHelper.ExecuteReader(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<ISalaryGrade>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<ISalaryGrade>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter, cancellationToken);
        }
    }
}
