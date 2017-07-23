using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class MultipleChoiceCandidateAnswerProcess : HumanResourceProcessBase
    {
        protected readonly IMultipleChoiceCandidateAnswerConverter<SqlDataReader> r_Converter;

        public MultipleChoiceCandidateAnswerProcess(IConnectionStringSource connectionStringSource, IMultipleChoiceCandidateAnswerConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
