using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGeneratePayrollContractualEmployeeList : IEnumerableProcess<IPayrollContractualEmployee>
    {
        ValueRange<DateTime> CutOff { get; set; }
    }
}
