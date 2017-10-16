using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmployeeFlexWorkScheduleByDate : IProcess<IEmployeeFlexWorkSchedule>
    {
        DateTime Date { get; set; }
    }
}
