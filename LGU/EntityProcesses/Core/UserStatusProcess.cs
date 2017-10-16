using LGU.EntityConverters.Core;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.Core
{
    public abstract class UserStatusProcess : CoreProcessBase
    {
        protected readonly IUserStatusConverter _Converter;

        public UserStatusProcess(IConnectionStringSource connectionStringSource, IUserStatusConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
