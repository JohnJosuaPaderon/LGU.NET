using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityConverters.HumanResource
{
    public interface IPayrollContractualEmployeeConverter : IDataConverter<IPayrollContractualEmployee>
    {
        IDataConverterProperty<long> PId { get; }
        IDataConverterProperty<IPayrollContractualDepartment> PDepartment { get; }
        IDataConverterProperty<IEmployee> PEmployee { get; }
        IDataConverterProperty<decimal> PMonthlyRate { get; }
        IDataConverterProperty<decimal?> PWithholdingTax { get; }
        IDataConverterProperty<decimal?> PHdmfPremiumPs { get; }
        IDataConverterProperty<decimal> PTimeLogDeduction { get; }
    }
}
