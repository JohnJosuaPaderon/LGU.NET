using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityConverters.HumanResource
{
    public interface IPayrollContractualConverter : IDataConverter<IPayrollContractual>
    {
        IDataConverterProperty<IPayrollCutOff> PCutOff { get; }
    }
}
