using System;

namespace LGU.Entities.Core
{
    public interface IPersonalDataSheet
    {
        IPerson Owner { get; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string NameExtension { get; set; }
        DateTime BirthDate { get; set; }
        string BirthPlace { get; set; }
        ICitizenship Citizenship { get; set; }
        IGender Gender { get; set; }
        ICountry DualCitizenshipCountry { get; set; }
        ICivilStatus CivilStatus { get; set; }
        IPersonalDataSheetAddress ResidentialAddress { get; }
        IPersonalDataSheetAddress PermanentAddress { get; }
        float Height { get; set; }
        float Weight { get; set; }
        BloodType BloodType { get; set; }
        string GSISIdNumber { get; set; }
        string PagIBIGIdNumber { get; set; }
        string PhilHealthNumber { get; set; }
        string SSSNumber { get; set; }
        string TINNumber { get; set; }
        string TelephoneNumber { get; set; }
        string MobileNumber { get; set; }
        string AgencyEmployeeNumber { get; set; }
        string EmailAddress { get; set; }
    }
}
