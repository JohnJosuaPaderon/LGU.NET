using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmployeeFingerPrintSetById : IProcess<EmployeeFingerPrintSet>
    {
        Employee Employee { get; set; }
    }
}
