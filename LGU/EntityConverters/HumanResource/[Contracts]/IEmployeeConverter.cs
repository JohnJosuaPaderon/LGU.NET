using LGU.Entities.Core;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IEmployeeConverter<TDataReader> : IDataConverter<IEmployee, TDataReader>
        where TDataReader : DbDataReader
    {
        IDataConverterProperty<long> Prop_Id { get; }
        IDataConverterProperty<string> Prop_FirstName { get; }
        IDataConverterProperty<string> Prop_MiddleName { get; }
        IDataConverterProperty<string> Prop_LastName { get; }
        IDataConverterProperty<string> Prop_NameExtension { get; }
        IDataConverterProperty<DateTime?> Prop_BirthDate { get; }
        IDataConverterProperty<bool> Prop_Deceased { get; }
        IDataConverterProperty<decimal> Prop_MonthlySalary { get; }
        IDataConverterProperty<IDepartment> Prop_Department { get; }
        IDataConverterProperty<IEmploymentStatus> Prop_EmploymentStatus { get; }
        IDataConverterProperty<IGender> Prop_Gender { get; }
        IDataConverterProperty<IPosition> Prop_Position { get; }
        IDataConverterProperty<IEmployeeType> Prop_Type { get; }
        IDataConverterProperty<IDepartmentHead> Prop_DepartmentHead { get; }
        IDataConverterProperty<IWorkTimeSchedule> Prop_WorkTimeSchedule { get; }
        IDataConverterProperty<IPayrollType> Prop_PayrollType { get; }
    }
}
