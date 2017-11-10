using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityConverters.HumanResource
{
    public interface IPayrollConverter<T> : IDataConverter<T>
        where T : IPayroll
    {
        IDataConverterProperty<IPayrollType> PType { get; }
        IDataConverterProperty<IPayrollCutOff> PCutOff { get; }
        IDataConverterProperty<DateTime> PRangeDateBegin { get; }
        IDataConverterProperty<DateTime> PRangeDateEnd { get; }
        IDataConverterProperty<DateTime> PRunDate { get; }
        IDataConverterProperty<IEmployee> PMayor { get; }
        IDataConverterProperty<IEmployee> PHumanResourceHead { get; }
        IDataConverterProperty<IEmployee> PTreasurer { get; }
        IDataConverterProperty<IEmployee> PCityAccountant { get; }
        IDataConverterProperty<IEmployee> PCityBudgetOfficer { get; }
    }
}
