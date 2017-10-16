namespace LGU.Entities.HumanResource
{
    public interface ICalendarEventFields : IEntityFields
    {
        string Description { get; }
        string DateOccur { get; }
        string DateOccurEnd { get; }
        string IsHoliday { get; }
        string IsNonWorking { get; }
        string IsAnnual { get; }
    }
}
