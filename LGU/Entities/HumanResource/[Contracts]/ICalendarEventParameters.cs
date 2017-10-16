namespace LGU.Entities.HumanResource
{
    public interface ICalendarEventParameters : IEntityParameters
    {
        string Description { get; }
        string DateOccur { get; }
        string DateOccurEnd { get; }
        string IsHoliday { get; }
        string IsNonWorking { get; }
        string IsAnnual { get; }
    }
}
