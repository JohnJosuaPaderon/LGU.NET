using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ExamSetProcess : HumanResourceProcessBase
    {
        protected readonly IExamSetConverter<SqlDataReader> Converter;

        public ExamSetProcess(IConnectionStringSource connectionStringSource, IExamSetConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            Converter = converter;
        }
    }
}
