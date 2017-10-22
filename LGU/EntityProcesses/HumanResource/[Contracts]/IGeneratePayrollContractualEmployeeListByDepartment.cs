using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGeneratePayrollContractualEmployeeListByDepartment : IEnumerableProcess<IPayrollContractualEmployee>
    {
        IDepartment Department { get; set; }
        ValueRange<DateTime> CutOff { get; set; }
    }
}
