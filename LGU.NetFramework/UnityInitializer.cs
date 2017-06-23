using LGU.Core.EntityProcesses;
using Microsoft.Practices.Unity;

namespace LGU
{
    public class UnityInitializer
    {
        public virtual void Initialize()
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IInsertComputer, InsertComputer>();
        }
    }
}
