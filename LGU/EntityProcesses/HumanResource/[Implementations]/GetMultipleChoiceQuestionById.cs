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
    public sealed class GetMultipleChoiceQuestionById : MultipleChoiceQuestionProcess, IGetMultipleChoiceQuestionById
    {
        public GetMultipleChoiceQuestionById(IConnectionStringSource connectionStringSource, IMultipleChoiceQuestionConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public long MultipleChoiceQuestionId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_Id", MultipleChoiceQuestionId);

        public IProcessResult<IMultipleChoiceQuestion> Execute()
        {
            return _SqlHelper.ExecuteReader(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<IMultipleChoiceQuestion>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<IMultipleChoiceQuestion>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter, cancellationToken);
        }
    }
}
