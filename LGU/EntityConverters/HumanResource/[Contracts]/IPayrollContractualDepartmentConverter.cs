﻿using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityConverters.HumanResource
{
    public interface IPayrollContractualDepartmentConverter : IDataConverter<IPayrollContractualDepartment>
    {
        IDataConverterProperty<IDepartment> PDepartment { get; }
        IDataConverterProperty<IPayroll> PPayroll { get; }
        IDataConverterProperty<IEmployee> PHead { get; }
        IDataConverterProperty<int> POrdinal { get; }
        IEnumerableProcess<IPayrollContractualEmployee> GetEmployees { get; set; }
        Action<(IDepartment Department, IPayroll Payroll, IEmployee Head)> GetEmployeesInitializer { get; set; }
    }
}
