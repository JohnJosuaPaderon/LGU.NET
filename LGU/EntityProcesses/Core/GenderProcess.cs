using LGU.EntityConverters.Core;

namespace LGU.EntityProcesses.Core
{
    public abstract class GenderProcess : CoreProcessBase
    {
        protected readonly IGenderConverter _Converter;

        public GenderProcess(IConnectionStringSource connectionStringSource, IGenderConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
