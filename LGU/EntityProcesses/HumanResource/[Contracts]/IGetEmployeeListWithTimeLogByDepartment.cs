using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmployeeListWithTimeLogByDepartment : IEnumerableProcess<Employee>
    {
        ValueRange<DateTime> CutOff { get; set; }
        Department Department { get; set; }
    }
}
