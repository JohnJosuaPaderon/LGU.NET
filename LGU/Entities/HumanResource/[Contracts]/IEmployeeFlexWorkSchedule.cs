using System;

namespace LGU.Entities.HumanResource
{
    public interface IEmployeeFlexWorkSchedule : IEntity<long>
    {
        IEmployee Employee { get; set; }
        ValueRange<DateTime> EffectivityDate { get; set; }
        IWorkTimeSchedule SundayWorkTimeSchedule { get; set; }
        IWorkTimeSchedule MondayWorkTimeSchedule { get; set; }
        IWorkTimeSchedule TuesdayWorkTimeSchedule { get; set; }
        IWorkTimeSchedule WednesdayWorkTimeSchedule { get; set; }
        IWorkTimeSchedule ThursdayWorkTimeSchedule { get; set; }
        IWorkTimeSchedule FridayWorkTimeSchedule { get; set; }
        IWorkTimeSchedule SaturdayWorkTimeSchedule { get; set; }
    }
}
