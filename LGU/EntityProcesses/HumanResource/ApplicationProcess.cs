using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ApplicationProcess : HumanResourceProcessBase
    {
        protected readonly IApplicationConverter _Converter;

        public ApplicationProcess(IConnectionStringSource connectionStringSource, IApplicationConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
