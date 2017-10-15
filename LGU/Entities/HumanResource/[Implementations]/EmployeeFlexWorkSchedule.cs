using System;

namespace LGU.Entities.HumanResource
{
    public sealed class EmployeeFlexWorkSchedule : Entity<long>, IEmployeeFlexWorkSchedule
    {
        public IEmployee Employee { get; set; }
        public ValueRange<DateTime> EffectivityDate { get; set; }
        public IWorkTimeSchedule SundayWorkTimeSchedule { get; set; }
        public IWorkTimeSchedule MondayWorkTimeSchedule { get; set; }
        public IWorkTimeSchedule TuesdayWorkTimeSchedule { get; set; }
        public IWorkTimeSchedule WednesdayWorkTimeSchedule { get; set; }
        public IWorkTimeSchedule ThursdayWorkTimeSchedule { get; set; }
        public IWorkTimeSchedule FridayWorkTimeSchedule { get; set; }
        public IWorkTimeSchedule SaturdayWorkTimeSchedule { get; set; }
    }
}
