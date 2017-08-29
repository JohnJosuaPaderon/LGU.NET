using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmployeeFingerPrintSetById : IProcess<IEmployeeFingerPrintSet>
    {
        IEmployee Employee { get; set; }
    }
}
