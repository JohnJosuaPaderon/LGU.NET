using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmployeeListByPayrollType : IEnumerableProcess<IEmployee>
    {
        IPayrollType PayrollType { get; set; }
    }
}
