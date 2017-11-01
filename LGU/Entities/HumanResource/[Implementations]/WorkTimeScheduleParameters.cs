namespace LGU.Entities.HumanResource
{
    public sealed class WorkTimeScheduleParameters : EntityParameters, IWorkTimeScheduleParameters
    {
        public WorkTimeScheduleParameters()
        {
            Description = "@_Description";
            WorkTimeStart = "@_WorkTimeStart";
            WorkTimeEnd = "@_WorkTimeEnd";
            BreakTime = "@_BreakTime";
            WorkingMonthDays = "@_WorkingMonthDays";
        }

        public string Description { get; }
        public string WorkTimeStart { get; }
        public string WorkTimeEnd { get; }
        public string BreakTime { get; }
        public string WorkingMonthDays { get; }
    }
}
