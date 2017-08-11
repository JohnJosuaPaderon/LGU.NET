using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class LocatorLeaveTypeProcess : HumanResourceProcessBase
    {
        protected readonly ILocatorLeaveTypeConverter<SqlDataReader> r_Converter;

        public LocatorLeaveTypeProcess(IConnectionStringSource connectionStringSource, ILocatorLeaveTypeConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
