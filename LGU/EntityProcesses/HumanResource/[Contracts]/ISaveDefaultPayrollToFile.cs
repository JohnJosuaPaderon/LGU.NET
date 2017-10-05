using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface ISaveDefaultPayrollToFile : IProcess
    {
        IPayroll Payroll { get; set; }
        string FilePath { get; set; }
    }
}
