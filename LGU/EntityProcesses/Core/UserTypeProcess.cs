using LGU.EntityConverters.Core;

namespace LGU.EntityProcesses.Core
{
    public abstract class UserTypeProcess : CoreProcessBase
    {
        protected readonly IUserTypeConverter _Converter;

        public UserTypeProcess(IConnectionStringSource connectionStringSource, IUserTypeConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
