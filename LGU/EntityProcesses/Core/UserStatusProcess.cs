using LGU.EntityConverters.Core;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.Core
{
    public abstract class UserStatusProcess : CoreProcessBase
    {
        protected readonly IUserStatusConverter<SqlDataReader> r_Converter;

        public UserStatusProcess(IConnectionStringSource connectionStringSource, IUserStatusConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
