using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateEmployeeFingerPrintSet : IProcess<IEmployeeFingerPrintSet>
    {
        IEmployeeFingerPrintSet FingerPrintSet { get; set; }
    }
}
