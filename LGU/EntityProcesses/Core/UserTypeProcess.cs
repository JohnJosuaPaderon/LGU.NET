using LGU.EntityConverters.Core;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.Core
{
    public abstract class UserTypeProcess : CoreProcessBase
    {
        protected readonly IUserTypeConverter<SqlDataReader> r_Converter;

        public UserTypeProcess(IConnectionStringSource connectionStringSource, IUserTypeConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
