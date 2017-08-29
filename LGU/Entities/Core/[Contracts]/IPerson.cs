using System;

namespace LGU.Entities.Core
{
    public interface IPerson : IEntity<long>
    {
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string NameExtension { get; set; }
        string MiddleInitials { get; }
        string FullName { get; }
        string InformalFullName { get; }
        DateTime? BirthDate { get; set; }
        IGender Gender { get; set; }
        bool Deceased { get; set; }
    }
}
