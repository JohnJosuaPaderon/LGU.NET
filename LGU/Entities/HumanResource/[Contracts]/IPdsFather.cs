using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public interface IPdsFather : IEntity<long>
    {
        IPerson Person { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string NameExtension { get; set; }
    }
}
