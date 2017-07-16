using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class TimeLogProcess : HumanResourceProcessBase
    {
        protected readonly ITimeLogConverter<SqlDataReader> Converter;

        public TimeLogProcess(IConnectionStringSource connectionStringSource, ITimeLogConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            Converter = converter;
        }
    }
}
