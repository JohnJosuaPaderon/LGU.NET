using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteEmployeeFingerPrintSet : IProcess<EmployeeFingerPrintSet>
    {
        EmployeeFingerPrintSet FingerPrintSet { get; set; }
    }
}
