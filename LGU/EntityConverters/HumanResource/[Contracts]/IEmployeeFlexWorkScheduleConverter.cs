using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityConverters.HumanResource
{
    public interface IEmployeeFlexWorkScheduleConverter : IDataConverter<IEmployeeFlexWorkSchedule>
    {
        IDataConverterProperty<IEmployee> PEmployee { get; }
        IDataConverterProperty<DateTime> PEffectivityDateBegin { get; }
        IDataConverterProperty<DateTime> PEffectivityDateEnd { get; }
        IDataConverterProperty<IWorkTimeSchedule> PSundayWorkTimeSchedule { get; }
        IDataConverterProperty<IWorkTimeSchedule> PMondayWorkTimeSchedule { get; }
        IDataConverterProperty<IWorkTimeSchedule> PTuesdayWorkTimeSchedule { get; }
        IDataConverterProperty<IWorkTimeSchedule> PWednesdayWorkTimeSchedule { get; }
        IDataConverterProperty<IWorkTimeSchedule> PThursdayWorkTimeSchedule { get; }
        IDataConverterProperty<IWorkTimeSchedule> PFridayWorkTimeSchedule { get; }
        IDataConverterProperty<IWorkTimeSchedule> PSaturdayWorkTimeSchedule { get; }
    }
}
