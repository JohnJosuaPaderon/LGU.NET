using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGeneratePayrollContractualDepartmentList : IEnumerableProcess<IPayrollContractualDepartment>
    {
        ValueRange<DateTime> CutOff { get; set; }
    }
}
