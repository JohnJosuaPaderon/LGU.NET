using LGU.EntityConverters.Core;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.Core
{
    public abstract class GenderProcess : CoreProcessBase
    {
        protected readonly IGenderConverter<SqlDataReader> Converter;

        public GenderProcess(IConnectionStringSource connectionStringSource, IGenderConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            Converter = converter;
        }
    }
}
