using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetMultipleChoiceCandidateAnswerById : MultipleChoiceCandidateAnswerProcess, IGetMultipleChoiceCandidateAnswerById
    {
        public GetMultipleChoiceCandidateAnswerById(IConnectionStringSource connectionStringSource, IMultipleChoiceCandidateAnswerConverter converter) : base(connectionStringSource, converter)
        {
        }

        public long MultipleChoiceCandidateAnswerId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_Id", MultipleChoiceCandidateAnswerId);

        public IProcessResult<IMultipleChoiceCandidateAnswer> Execute()
        {
            return _SqlHelper.ExecuteReader(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IMultipleChoiceCandidateAnswer>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IMultipleChoiceCandidateAnswer>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
