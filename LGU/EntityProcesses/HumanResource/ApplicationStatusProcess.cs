using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ApplicationStatusProcess : HumanResourceProcessBase
    {
        protected readonly IApplicationStatusConverter<SqlDataReader> r_Converter;

        public ApplicationStatusProcess(IConnectionStringSource connectionStringSource, IApplicationStatusConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
