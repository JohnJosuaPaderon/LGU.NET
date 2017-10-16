using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ApplicationDocumentProcess : HumanResourceProcessBase
    {
        protected readonly IApplicationDocumentConverter _Converter;

        public ApplicationDocumentProcess(IConnectionStringSource connectionStringSource, IApplicationDocumentConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
