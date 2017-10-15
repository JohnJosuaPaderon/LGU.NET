namespace LGU.Entities.HumanResource
{
    public interface IEmployeeFlexWorkScheduleFields : IEntityFields
    {
        string EmployeeId { get; }
        string EffectivityDateBegin { get; }
        string EffectivityDateEnd { get; }
        string SundayWorkTimeScheduleId { get; }
        string MondayWorkTimeScheduleId { get; }
        string TuesdayWorkTimeScheduleId { get; }
        string WednesdayWorkTimeScheduleId { get; }
        string ThursdayWorkTimeScheduleId { get; }
        string FridayWorkTimeScheduleId { get; }
        string SaturdayWorkTimeScheduleId { get; }
    }
}
