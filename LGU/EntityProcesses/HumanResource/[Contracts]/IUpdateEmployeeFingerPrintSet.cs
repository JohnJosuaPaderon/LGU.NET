using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateEmployeeFingerPrintSet : IProcess<EmployeeFingerPrintSet>
    {
        EmployeeFingerPrintSet FingerPrintSet { get; set; }
    }
}
