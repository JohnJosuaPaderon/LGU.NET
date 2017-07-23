using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ExamProcess : HumanResourceProcessBase
    {
        protected readonly IExamConverter<SqlDataReader> r_Converter;

        public ExamProcess(IConnectionStringSource connectionStringSource, IExamConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
