namespace LGU.Entities.HumanResource
{
    public interface IWorkTimeScheduleParameters : IEntityParameters
    {
        string Description { get; }
        string WorkTimeStart { get; }
        string WorkTimeEnd { get; }
        string BreakTime { get; }
        string WorkingMonthDays { get; }
    }
}
