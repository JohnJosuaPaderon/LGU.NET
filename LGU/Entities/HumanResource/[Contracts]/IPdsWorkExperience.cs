using System;

namespace LGU.Entities.HumanResource
{
    public interface IPdsWorkExperience : IEntity<long>
    {
        IPersonalDataSheet PersonalDataSheet { get; set; }
        ValueRange<DateTime> InclusiveDates { get; set; }
        string PositionTitle { get; set; }
        string Company { get; set; }
        decimal MonthlySalary { get; set; }
        string SalaryGradeStepIncrement { get; set; }
        string StatusOfAppointment { get; set; }
        bool GovernmentService { get; set; }
    }
}
