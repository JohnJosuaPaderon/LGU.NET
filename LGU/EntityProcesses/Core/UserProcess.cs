using LGU.EntityConverters.Core;

namespace LGU.EntityProcesses.Core
{
    public abstract class UserProcess : CoreProcessBase
    {
        protected readonly IUserConverter _Converter;

        public UserProcess(IConnectionStringSource connectionStringSource, IUserConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
