using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ExamMultipleChoiceAnswerProcess : HumanResourceProcessBase
    {
        protected readonly IExamMultipleChoiceAnswerConverter<SqlDataReader> Converter;

        public ExamMultipleChoiceAnswerProcess(IConnectionStringSource connectionStringSource, IExamMultipleChoiceAnswerConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            Converter = converter;
        }
    }
}
