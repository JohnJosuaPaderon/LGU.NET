using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IWorkTimeScheduleConverter<TDataReader> : IDataConverter<IWorkTimeSchedule, TDataReader>
        where TDataReader : DbDataReader
    {
        IDataConverterProperty<int> Prop_Id { get; }
        IDataConverterProperty<string> Prop_Description { get; }
        IDataConverterProperty<DateTime> Prop_WorkTimeStart { get; }
        IDataConverterProperty<DateTime> Prop_WorkTimeEnd { get; }
        IDataConverterProperty<TimeSpan?> Prop_BreakTime { get; }
        IDataConverterProperty<int> Prop_WorkingMonthDays { get; }
    }
}
