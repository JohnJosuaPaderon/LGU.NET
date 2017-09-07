using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class WorkTimeScheduleProcess : HumanResourceProcessBase
    {
        public WorkTimeScheduleProcess(IConnectionStringSource connectionStringSource, IWorkTimeScheduleConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }

        protected readonly IWorkTimeScheduleConverter<SqlDataReader> r_Converter;
    }
}
