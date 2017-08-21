using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetTimeLogListByDepartmentCutOff : IEnumerableProcess<TimeLog>
    {
        Department Department { get; set; }
        ValueRange<DateTime> CutOff { get; set; }
    }
}
