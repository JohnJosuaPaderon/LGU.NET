using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ApplicationProcess : HumanResourceProcessBase
    {
        protected readonly IApplicationConverter<SqlDataReader> r_Converter;

        public ApplicationProcess(IConnectionStringSource connectionStringSource, IApplicationConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
