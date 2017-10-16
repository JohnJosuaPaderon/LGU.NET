using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityConverters.HumanResource
{
    public interface IWorkTimeScheduleConverter : IDataConverter<IWorkTimeSchedule>
    {
        IDataConverterProperty<int> Prop_Id { get; }
        IDataConverterProperty<string> Prop_Description { get; }
        IDataConverterProperty<DateTime> Prop_WorkTimeStart { get; }
        IDataConverterProperty<DateTime> Prop_WorkTimeEnd { get; }
        IDataConverterProperty<TimeSpan?> Prop_BreakTime { get; }
        IDataConverterProperty<int> Prop_WorkingMonthDays { get; }
    }
}
