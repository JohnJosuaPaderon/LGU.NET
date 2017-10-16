using LGU.Entities.Core;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System;

namespace LGU.EntityConverters.HumanResource
{
    public interface IEmployeeConverter : IDataConverter<IEmployee>
    {
        IDataConverterProperty<long> PId { get; }
        IDataConverterProperty<string> PFirstName { get; }
        IDataConverterProperty<string> PMiddleName { get; }
        IDataConverterProperty<string> PLastName { get; }
        IDataConverterProperty<string> PNameExtension { get; }
        IDataConverterProperty<DateTime?> PBirthDate { get; }
        IDataConverterProperty<bool> PDeceased { get; }
        IDataConverterProperty<decimal> PMonthlySalary { get; }
        IDataConverterProperty<IDepartment> PDepartment { get; }
        IDataConverterProperty<IEmploymentStatus> PEmploymentStatus { get; }
        IDataConverterProperty<IGender> PGender { get; }
        IDataConverterProperty<IPosition> PPosition { get; }
        IDataConverterProperty<IEmployeeType> PType { get; }
        IDataConverterProperty<IDepartmentHead> PDepartmentHead { get; }
        IDataConverterProperty<IWorkTimeSchedule> PWorkTimeSchedule { get; }
        IDataConverterProperty<IPayrollType> PPayrollType { get; }
        IDataConverterProperty<bool> PIsFlexWorkSchedule { get; }
    }
}
