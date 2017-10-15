namespace LGU.Entities.HumanResource
{
    public sealed class EmployeeFlexWorkScheduleFields : EntityFields, IEmployeeFlexWorkScheduleFields
    {
        public EmployeeFlexWorkScheduleFields()
        {
            EmployeeId = "EmployeeId";
            EffectivityDateBegin = "EffectivityDateBegin";
            EffectivityDateEnd = "EffectivityDateEnd";
            SundayWorkTimeScheduleId = "SundayWorkTimeScheduleId";
            MondayWorkTimeScheduleId = "MondayWorkTimeScheduleId";
            TuesdayWorkTimeScheduleId = "TuesdayWorkTimeScheduleId";
            WednesdayWorkTimeScheduleId = "WednesdayWorkTimeScheduleId";
            ThursdayWorkTimeScheduleId = "ThursdayWorkTimeScheduleId";
            FridayWorkTimeScheduleId = "FridayWorkTimeScheduleId";
            SaturdayWorkTimeScheduleId = "SaturdayWorkTimeScheduleId";
        }

        public string EmployeeId { get; }
        public string EffectivityDateBegin { get; }
        public string EffectivityDateEnd { get; }
        public string SundayWorkTimeScheduleId { get; }
        public string MondayWorkTimeScheduleId { get; }
        public string TuesdayWorkTimeScheduleId { get; }
        public string WednesdayWorkTimeScheduleId { get; }
        public string ThursdayWorkTimeScheduleId { get; }
        public string FridayWorkTimeScheduleId { get; }
        public string SaturdayWorkTimeScheduleId { get; }
    }
}
