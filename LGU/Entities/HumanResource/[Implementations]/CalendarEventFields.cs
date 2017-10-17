namespace LGU.Entities.HumanResource
{
    public sealed class CalendarEventFields : EntityFields, ICalendarEventFields
    {
        public CalendarEventFields()
        {
            Description = "Description";
            DateOccur = "DateOccur";
            DateOccurEnd = "DateOccurEnd";
            IsHoliday = "IsHoliday";
            IsNonWorking = "IsNonWorking";
            IsAnnual = "IsAnnual";
        }

        public string Description { get; }
        public string DateOccur { get; }
        public string DateOccurEnd { get; }
        public string IsHoliday { get; }
        public string IsNonWorking { get; }
        public string IsAnnual { get; }
    }
}
