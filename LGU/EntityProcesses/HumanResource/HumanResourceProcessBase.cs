namespace LGU.EntityProcesses.HumanResource
{
    public abstract class HumanResourceProcessBase : ProcessBase
    {
        public HumanResourceProcessBase(IConnectionStringSource connectionStringSource) : base(connectionStringSource, "HumanResource")
        {
        }
    }

    public abstract class HumanResourceProcessBaseV2 : ProcessBaseV2
    {
        public HumanResourceProcessBaseV2(IConnectionStringSource connectionStringSource) : base(connectionStringSource, "HumanResource")
        {
        }
    }
}
