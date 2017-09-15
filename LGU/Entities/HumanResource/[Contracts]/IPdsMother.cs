using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public interface IPdsMother : IEntity<long>
    {
        IPerson Person { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string MaidenName { get; set; }
    }
}
