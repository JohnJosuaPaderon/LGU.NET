using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class SalaryGradeBatchProcess : HumanResourceProcessBase
    {
        protected readonly ISalaryGradeBatchConverter<SqlDataReader> r_Converter;

        public SalaryGradeBatchProcess(IConnectionStringSource connectionStringSource, ISalaryGradeBatchConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
