using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class LocatorProcess : HumanResourceProcessBase
    {
        protected readonly ILocatorConverter<SqlDataReader> r_Converter;

        public LocatorProcess(IConnectionStringSource connectionStringSource, ILocatorConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
