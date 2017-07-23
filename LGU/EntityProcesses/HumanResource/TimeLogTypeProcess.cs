using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class TimeLogTypeProcess : HumanResourceProcessBase
    {
        protected readonly ITimeLogTypeConverter<SqlDataReader> r_Converter;

        public TimeLogTypeProcess(IConnectionStringSource connectionStringSource, ITimeLogTypeConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
