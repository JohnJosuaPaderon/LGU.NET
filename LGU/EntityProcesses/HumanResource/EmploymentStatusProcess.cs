using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class EmploymentStatusProcess : HumanResourceProcessBase
    {
        protected readonly IEmploymentStatusConverter<SqlDataReader> r_Converter;

        public EmploymentStatusProcess(IConnectionStringSource connectionStringSource, IEmploymentStatusConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
