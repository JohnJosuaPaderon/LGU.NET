namespace LGU.EntityProcesses.HumanResource
{
    public abstract class HumanResourceProcessBase : ProcessBase
    {
        public HumanResourceProcessBase(IConnectionStringSource connectionStringSource) : base(connectionStringSource, "HumanResource")
        {
        }
    }
}
