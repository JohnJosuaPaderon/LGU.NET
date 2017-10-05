using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface ICalendarEventConverter<TDataReader> : IDataConverter<ICalendarEvent, TDataReader>
        where TDataReader : DbDataReader
    {
        IDataConverterProperty<long> Prop_Id { get; }
        IDataConverterProperty<string> Prop_Description { get; }
        IDataConverterProperty<DateTime> Prop_DateOccur { get; }
        IDataConverterProperty<DateTime?> Prop_DateOccurEnd { get; }
        IDataConverterProperty<bool> Prop_IsHoliday { get; }
        IDataConverterProperty<bool> Prop_IsNonWorking { get; }
        IDataConverterProperty<bool> Prop_IsAnnual { get; }
    }
}
