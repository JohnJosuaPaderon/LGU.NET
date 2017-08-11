using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityProcesses.HumanResource
{
    public interface ISearchEmployeeWithTimeLog : IEnumerableProcess<Employee>
    {
        string SearchKey { get; set; }
        ValueRange<DateTime> CutOff { get; set; }
    }
}
