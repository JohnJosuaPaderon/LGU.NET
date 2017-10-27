using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityConverters.HumanResource
{
    public interface IPayrollContractualDepartmentConverter : IDataConverter<IPayrollContractualDepartment>
    {
        IDataConverterProperty<IDepartment> PDepartment { get; }
        IDataConverterProperty<IPayrollContractual> PPayroll { get; }
        IDataConverterProperty<IDepartmentHead> PHead { get; }
        IDataConverterProperty<int> POrdinal { get; }
        IEnumerableProcess<IPayrollContractualEmployee> GetEmployees { get; set; }
        Action<(IDepartment Department, IDepartmentHead Head)> GetEmployeesInitializer { get; set; }
    }
}
