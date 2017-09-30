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
    public sealed class GetExamSetById : ExamSetProcess, IGetExamSetById
    {
        public GetExamSetById(IConnectionStringSource connectionStringSource, IExamSetConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public long ExamSetId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_Id", ExamSetId);

        public IProcessResult<IExamSet> Execute()
        {
            return _SqlHelper.ExecuteReader(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<IExamSet>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<IExamSet>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter, cancellationToken);
        }
    }
}
