using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public interface IPdsSpouse : IEntity<long>
    {
        IPerson Person { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string NameExtension { get; set; }
        string Occupation { get; set; }
        string EmployerBusinessName { get; set; }
        string BusinessAddress { get; set; }
        string TelephoneNumber { get; set; }
    }
}
