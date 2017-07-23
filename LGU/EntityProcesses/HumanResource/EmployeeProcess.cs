using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class EmployeeProcess : HumanResourceProcessBase
    {
        protected readonly IEmployeeConverter<SqlDataReader> r_Converter;

        public EmployeeProcess(IConnectionStringSource connectionStringSource, IEmployeeConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
