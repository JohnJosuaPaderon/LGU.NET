using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmployeeListWithTimeLog : IEnumerableProcess<IEmployee>
    {
        ValueRange<DateTime> CutOff { get; set; }
    }
}
