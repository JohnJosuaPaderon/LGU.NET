namespace LGU.Entities.HumanResource
{
    public sealed class WorkTimeScheduleFields : EntityFields, IWorkTimeScheduleFields
    {
        public WorkTimeScheduleFields()
        {
            Description = "Description";
            WorkTimeStart = "WorkTimeStart";
            WorkTimeEnd = "WorkTimeEnd";
            BreakTime = "BreakTime";
            WorkingMonthDays = "WorkingMonthDays";
        }

        public string Description { get; }
        public string WorkTimeStart { get; }
        public string WorkTimeEnd { get; }
        public string BreakTime { get; }
        public string WorkingMonthDays { get; }
    }
}
