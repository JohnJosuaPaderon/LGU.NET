using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ExamSetProcess : HumanResourceProcessBase
    {
        protected readonly IExamSetConverter<SqlDataReader> r_Converter;

        public ExamSetProcess(IConnectionStringSource connectionStringSource, IExamSetConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
