using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ExamProcess : HumanResourceProcessBase
    {
        protected readonly IExamConverter<SqlDataReader> Converter;

        public ExamProcess(IConnectionStringSource connectionStringSource, IExamConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            Converter = converter;
        }
    }
}
