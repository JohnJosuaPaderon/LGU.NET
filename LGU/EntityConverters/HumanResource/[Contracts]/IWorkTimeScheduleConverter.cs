using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityConverters.HumanResource
{
    public interface IWorkTimeScheduleConverter : IDataConverter<IWorkTimeSchedule>
    {
        IDataConverterProperty<int> PId { get; }
        IDataConverterProperty<string> PDescription { get; }
        IDataConverterProperty<DateTime> PWorkTimeStart { get; }
        IDataConverterProperty<DateTime> PWorkTimeEnd { get; }
        IDataConverterProperty<TimeSpan?> PBreakTime { get; }
        IDataConverterProperty<int> PWorkingMonthDays { get; }
    }
}
