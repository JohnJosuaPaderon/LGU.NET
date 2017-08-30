using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class SalaryGradeProcess : HumanResourceProcessBase
    {
        protected readonly ISalaryGradeConverter<SqlDataReader> r_Converter;

        public SalaryGradeProcess(IConnectionStringSource connectionStringSource, ISalaryGradeConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
