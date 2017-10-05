using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetDefaultPayrollFromFile : IProcess<IPayroll>
    {
        string FilePath { get; set; }
    }
}
