using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ApplicationStatusProcess : HumanResourceProcessBase
    {
        protected readonly IApplicationStatusConverter<SqlDataReader> Converter;

        public ApplicationStatusProcess(IConnectionStringSource connectionStringSource, IApplicationStatusConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            Converter = converter;
        }
    }
}
