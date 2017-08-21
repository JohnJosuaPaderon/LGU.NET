using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetDepartmentListWithTimeLog : IEnumerableProcess<Department>
    {
        ValueRange<DateTime> CutOff { get; set; }
    }
}
