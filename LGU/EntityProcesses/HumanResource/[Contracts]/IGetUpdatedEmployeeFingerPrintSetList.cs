using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetUpdatedEmployeeFingerPrintSetList : IEnumerableProcess<EmployeeFingerPrintSet>
    {
        DateTime LogDate { get; set; }
    }
}
