using LGU.Entities.Core;
using System;

namespace LGU.Entities.HumanResource
{
    public interface IPersonalDataSheet : IEntity<long>
    {
        Employee Employee { get; }
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
        float Height { get; set; }
        float Weight { get; set; }
        BloodType BloodType { get; set; }
        string GsisIdNumber { get; set; }
        string PagIbigIdNumber { get; set; }
        string PhilHealthNumber { get; set; }
        string SssNumber { get; set; }
        string TIN { get; set; }
        string TelephoneNumber { get; set; }
        string MobileNumber { get; set; }
        string AgencyEmployeeNumber { get; set; }
        string EmailAddress { get; set; }
        IPdsAddress ResidentialAddress { get; set; }
        IPdsAddress PermanentAddress { get; set; }
        IPdsFather Father { get; set; }
        IPdsMother Mother { get; set; }
        IPdsSpouse Spouse { get; set; }
    }
}
