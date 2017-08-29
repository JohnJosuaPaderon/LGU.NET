using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteEmployeeFingerPrintSet : IProcess<IEmployeeFingerPrintSet>
    {
        IEmployeeFingerPrintSet FingerPrintSet { get; set; }
    }
}
