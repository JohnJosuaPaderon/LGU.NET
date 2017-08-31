using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class SalaryGradeStepProcess : HumanResourceProcessBase
    {
        protected readonly ISalaryGradeStepConverter<SqlDataReader> r_Converter;

        public SalaryGradeStepProcess(IConnectionStringSource connectionStringSource, ISalaryGradeStepConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
