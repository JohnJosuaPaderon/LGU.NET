using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class MultipleChoiceQuestionProcess : HumanResourceProcessBase
    {
        protected readonly IMultipleChoiceQuestionConverter<SqlDataReader> Converter;

        public MultipleChoiceQuestionProcess(IConnectionStringSource connectionStringSource, IMultipleChoiceQuestionConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            Converter = converter;
        }
    }
}
