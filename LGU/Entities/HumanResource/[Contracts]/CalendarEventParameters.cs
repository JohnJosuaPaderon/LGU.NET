namespace LGU.Entities.HumanResource
{
    public sealed class CalendarEventParameters : EntityParameters, ICalendarEventParameters
    {
        public CalendarEventParameters()
        {
            Description = "@_Description";
            DateOccur = "@_DateOccur";
            DateOccurEnd = "@_DateOccurEnd";
            IsHoliday = "@_IsHoliday";
            IsNonWorking = "@_IsNonWorking";
            IsAnnual = "@_IsAnnual";
        }

        public string Description { get; }
        public string DateOccur { get; }
        public string DateOccurEnd { get; }
        public string IsHoliday { get; }
        public string IsNonWorking { get; }
        public string IsAnnual { get; }
    }
}
