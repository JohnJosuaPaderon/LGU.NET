using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IPayrollConverter<TDataReader> : IDataConverter<IPayroll, TDataReader>
        where TDataReader : DbDataReader
    {
        IDataConverterProperty<long> PId { get; }
        IDataConverterProperty<IPayrollType> PType { get; }
        IDataConverterProperty<IPayrollCutOff> PCutOff { get; }
        IDataConverterProperty<ValueRange<DateTime>> PRangeDate { get; }
        IDataConverterProperty<DateTime> PRunDate { get; }
        IDataConverterProperty<IEmployee> PHumanResourceHead { get; }
        IDataConverterProperty<IEmployee> PMayor { get; }
        IDataConverterProperty<IEmployee> PTreasurer { get; }
        IDataConverterProperty<IEmployee> PCityAccountant { get; }
        IDataConverterProperty<IEmployee> PCityBudgetOfficer { get; }
    }
}
