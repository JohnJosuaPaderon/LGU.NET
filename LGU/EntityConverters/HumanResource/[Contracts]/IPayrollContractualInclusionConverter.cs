using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityConverters.HumanResource
{
    public interface IPayrollContractualInclusionConverter : IDataConverter<IPayrollContractualInclusion>
    {
        IDataConverterProperty<IPayrollContractual> PPayroll { get; }
        IDataConverterProperty<bool> PHdmfPremiumPs { get; }
    }
}
