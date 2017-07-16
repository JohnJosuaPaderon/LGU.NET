using LGU.EntityConverters.Core;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.Core
{
    public abstract class UserProcess : CoreProcessBase
    {
        protected readonly IUserConverter<SqlDataReader> Converter;

        public UserProcess(IConnectionStringSource connectionStringSource, IUserConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            Converter = converter;
        }
    }
}
