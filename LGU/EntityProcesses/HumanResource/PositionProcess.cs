using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class PositionProcess : HumanResourceProcessBase
    {
        protected readonly IPositionConverter _Converter;

        public PositionProcess(IConnectionStringSource connectionStringSource, IPositionConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
