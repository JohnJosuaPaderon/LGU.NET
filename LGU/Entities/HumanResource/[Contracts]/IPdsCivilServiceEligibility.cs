using System;

namespace LGU.Entities.HumanResource
{
    public interface IPdsCivilServiceEligibility : IEntity<long>
    {
        IPersonalDataSheet PersonalDataSheet { get; set; }
        string Description { get; set; }
        decimal? Rating { get; set; }
        DateTime ExaminationDate { get; set; }
        string ExaminationPlace { get; set; }
        string LicenseNumber { get; set; }
        DateTime? LicenseValidityDate { get; set; }
    }
}
