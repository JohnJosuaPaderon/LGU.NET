using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmployeeListWithTimeLogByDepartment : IEnumerableProcess<IEmployee>
    {
        ValueRange<DateTime> CutOff { get; set; }
        IDepartment Department { get; set; }
    }
}
