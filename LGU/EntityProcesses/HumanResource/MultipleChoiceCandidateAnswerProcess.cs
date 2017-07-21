using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class MultipleChoiceCandidateAnswerProcess : HumanResourceProcessBase
    {
        protected readonly IMultipleChoiceCandidateAnswerConverter<SqlDataReader> Converter;

        public MultipleChoiceCandidateAnswerProcess(IConnectionStringSource connectionStringSource, IMultipleChoiceCandidateAnswerConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            Converter = converter;
        }
    }
}
