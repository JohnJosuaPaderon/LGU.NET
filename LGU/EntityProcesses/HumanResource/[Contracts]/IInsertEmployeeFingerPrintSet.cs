using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertEmployeeFingerPrintSet : IProcess<EmployeeFingerPrintSet>
    {
        EmployeeFingerPrintSet FingerPrintSet { get; set; }
    }
}
