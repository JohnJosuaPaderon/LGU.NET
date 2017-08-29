using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetDepartmentListWithTimeLog : IEnumerableProcess<IDepartment>
    {
        ValueRange<DateTime> CutOff { get; set; }
    }
}
