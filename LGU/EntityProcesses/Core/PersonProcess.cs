using LGU.EntityConverters.Core;

namespace LGU.EntityProcesses.Core
{
    public abstract class PersonProcess : CoreProcessBase
    {
        protected readonly IPersonConverter _Converter;

        public PersonProcess(IConnectionStringSource connectionStringSource, IPersonConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
