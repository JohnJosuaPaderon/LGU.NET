using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IPayrollConverter<TDataReader> : IDataConverter<IPayroll, TDataReader>
        where TDataReader : DbDataReader
    {
        IDataConverterProperty<long> Prop_Id { get; }
        IDataConverterProperty<IPayrollType> Prop_Type { get; }
        IDataConverterProperty<IPayrollCutOff> Prop_CutOff { get; }
        IDataConverterProperty<ValueRange<DateTime>> Prop_RangeDate { get; }
        IDataConverterProperty<DateTime> Prop_RunDate { get; }
        IDataConverterProperty<IEmployee> Prop_HumanResourceHead { get; }
        IDataConverterProperty<IEmployee> Prop_Mayor { get; }
        IDataConverterProperty<IEmployee> Prop_Treasurer { get; }
        IDataConverterProperty<IEmployee> Prop_CityAccountant { get; }
        IDataConverterProperty<IEmployee> Prop_CityBudgetOfficer { get; }
    }
}
