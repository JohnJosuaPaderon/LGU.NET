using LGU.EntityConverters.Core;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.Core
{
    public abstract class PersonProcess : CoreProcessBase
    {
        protected readonly IPersonConverter<SqlDataReader> r_Converter;

        public PersonProcess(IConnectionStringSource connectionStringSource, IPersonConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
