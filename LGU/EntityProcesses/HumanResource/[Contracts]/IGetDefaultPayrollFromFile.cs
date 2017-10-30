using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetDefaultPayrollFromFile<TDepartment> : IProcess<IPayroll>
        where TDepartment : IPayrollDepartment
    {
        string FilePath { get; set; }
    }
}
