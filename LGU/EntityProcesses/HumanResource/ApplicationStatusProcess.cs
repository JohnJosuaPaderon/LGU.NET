using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ApplicationStatusProcess : HumanResourceProcessBase
    {
        protected readonly IApplicationStatusConverter _Converter;

        public ApplicationStatusProcess(IConnectionStringSource connectionStringSource, IApplicationStatusConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
