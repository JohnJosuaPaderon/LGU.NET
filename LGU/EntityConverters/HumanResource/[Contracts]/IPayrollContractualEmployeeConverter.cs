using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IPayrollContractualEmployeeConverter<TDataReader> : IDataConverter<IPayrollContractualEmployee, TDataReader>
        where TDataReader : DbDataReader
    {
        IDataConverterProperty<IEmployee> Employee { get; }
        IDataConverterProperty<IPayroll> Payroll { get; }
        IDataConverterProperty<decimal> MonthlyRate { get; }
        IDataConverterProperty<decimal?> WithholdingTax { get; }
        IDataConverterProperty<string> Remarks { get; }
    }
}
