namespace LGU.EntityProcesses.Core
{
    public abstract class CoreProcessBase : ProcessBase
    {
        public CoreProcessBase(IConnectionStringSource connectionStringSource) : base(connectionStringSource, "Core")
        {
        }
    }
}
