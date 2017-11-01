namespace LGU.Entities.HumanResource
{
    public interface IWorkTimeScheduleFields : IEntityFields
    {
        string Description { get; }
        string WorkTimeStart { get; }
        string WorkTimeEnd { get; }
        string BreakTime { get; }
        string WorkingMonthDays { get; }
    }
}
