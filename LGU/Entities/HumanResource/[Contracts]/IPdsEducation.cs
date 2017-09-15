using System;

namespace LGU.Entities.HumanResource
{
    public interface IPdsEducation : IEntity<long>
    {
        IPersonalDataSheet PersonalDataSheet { get; }
        IPdsEducationLevel Level { get; set; }
        string SchoolName { get; set; }
        string BasicEducationDegreeCourse { get; set; }
        ValueRange<DateTime> AttendancePeriod { get; set; }
        string HighestLevelUnitEarned { get; set; }
        int YearGraduated { get; set; }
        string ReceivedScholarshipAcademicHonor { get; set; }
    }
}
