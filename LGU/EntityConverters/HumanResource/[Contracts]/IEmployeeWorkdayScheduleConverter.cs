using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IEmployeeWorkdayScheduleConverter<TDataReader> : IDataConverter<IEmployeeWorkdaySchedule, TDataReader>
        where TDataReader : DbDataReader
    {
        IDataConverterProperty<long> Prop_Id { get; }
        IDataConverterProperty<IEmployee> Prop_Employee { get; }
        IDataConverterProperty<bool> Prop_Sunday { get; }
        IDataConverterProperty<bool> Prop_Monday { get; }
        IDataConverterProperty<bool> Prop_Tuesday { get; }
        IDataConverterProperty<bool> Prop_Wednesday { get; }
        IDataConverterProperty<bool> Prop_Thursday { get; }
        IDataConverterProperty<bool> Prop_Friday { get; }
        IDataConverterProperty<bool> Prop_Saturday { get; }
    }
}
