using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface ISaveDefaultPayrollToFile <TDepartment> : IProcess
        where TDepartment : IPayrollDepartment
    {
        IPayroll Payroll { get; set; }
        string FilePath { get; set; }
    }
}
