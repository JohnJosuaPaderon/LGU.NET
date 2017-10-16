using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityConverters.HumanResource
{
    public interface IPayrollContractualDepartmentConverter : IDataConverter<IPayrollContractualDepartment>
    {
        IDataConverterProperty<IDepartment> PDepartment { get; }
        IDataConverterProperty<IPayroll> PPayroll { get; }
        IDataConverterProperty<IEmployee> PHead { get; }
        IDataConverterProperty<int> POrdinal { get; }
    }
}
