using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityConverters.HumanResource
{
    public interface IPayrollConverter : IDataConverter<IPayroll>
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
