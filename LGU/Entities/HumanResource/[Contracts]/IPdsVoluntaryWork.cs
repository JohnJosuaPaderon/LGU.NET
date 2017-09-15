using System;

namespace LGU.Entities.HumanResource
{
    public interface IPdsVoluntaryWork : IEntity<long>
    {
        IPersonalDataSheet PersonalDataSheet { get; set; }
        IPdsOrganization Organization { get; set; }
        ValueRange<DateTime> InclusiveDates { get; set; }
        decimal Hours { get; set; }
        string WorkNature { get; set; }
    }
}
