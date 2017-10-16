using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityConverters.HumanResource
{
    public interface ICalendarEventConverter : IDataConverter<ICalendarEvent>
    {

        IDataConverterProperty<long> PId { get; }
        IDataConverterProperty<string> PDescription { get; }
        IDataConverterProperty<DateTime> PDateOccur { get; }
        IDataConverterProperty<DateTime?> PDateOccurEnd { get; }
        IDataConverterProperty<bool> PIsHoliday { get; }
        IDataConverterProperty<bool> PIsNonWorking { get; }
        IDataConverterProperty<bool> PIsAnnual { get; }
    }
}
