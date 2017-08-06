using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class EmployeeWorkTimeScheduleProcess : HumanResourceProcessBase
    {
        protected readonly IEmployeeWorkTimeScheduleConverter<SqlDataReader> r_Converter;

        public EmployeeWorkTimeScheduleProcess(IConnectionStringSource connectionStringSource, IEmployeeWorkTimeScheduleConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
