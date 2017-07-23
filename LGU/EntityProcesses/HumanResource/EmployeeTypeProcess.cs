using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class EmployeeTypeProcess : HumanResourceProcessBase
    {
        protected readonly IEmployeeTypeConverter<SqlDataReader> r_Converter;

        public EmployeeTypeProcess(IConnectionStringSource connectionStringSource, IEmployeeTypeConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
