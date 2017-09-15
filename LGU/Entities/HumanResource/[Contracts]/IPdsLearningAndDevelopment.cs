using System;

namespace LGU.Entities.HumanResource
{
    public interface IPdsLearningAndDevelopment : IEntity<long>
    {
        IPersonalDataSheet PersonalDataSheet { get; set; }
        string Title { get; set; }
        ValueRange<DateTime> InclusiveDates { get; set; }
        decimal Hours { get; set; }
        IPdsLearningAndDevelopmentType Type { get; set; }
        string Conductor { get; set; }
        string Sponsor { get; set; }
    }
}
