using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ExamEssayAnswerProcess : HumanResourceProcessBase
    {
        protected readonly IExamEssayAnswerConverter<SqlDataReader> r_Converter;

        public ExamEssayAnswerProcess(IConnectionStringSource connectionStringSource, IExamEssayAnswerConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
