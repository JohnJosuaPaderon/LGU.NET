namespace LGU.Entities.HumanResource
{
    public sealed class EmployeeFlexWorkScheduleParameters : EntityParameters, IEmployeeFlexWorkScheduleParameters
    {
        public EmployeeFlexWorkScheduleParameters()
        {
            EmployeeId = "@_EmployeeId";
            EffectivityDateBegin = "@_EffectivityDateBegin";
            EffectivityDateEnd = "@_EffectivityDateEnd";
            SundayWorkTimeScheduleId = "@_SundayWorkTimeScheduleId";
            MondayWorkTimeScheduleId = "@_MondayWorkTimeScheduleId";
            TuesdayWorkTimeScheduleId = "@_TuesdayWorkTimeScheduleId";
            WednesdayWorkTimeScheduleId = "@_WednesdayWorkTimeScheduleId";
            ThursdayWorkTimeScheduleId = "@_ThursdayWorkTimeScheduleId";
            FridayWorkTimeScheduleId = "@_FridayWorkTimeScheduleId";
            SaturdayWorkTimeScheduleId = "@_SaturdayWorkTimeScheduleId";
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
