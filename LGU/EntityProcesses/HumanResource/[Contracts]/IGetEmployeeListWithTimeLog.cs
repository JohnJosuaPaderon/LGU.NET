using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmployeeListWithTimeLog : IEnumerableProcess<Employee>
    {
        ValueRange<DateTime> CutOff { get; set; }
    }
}
