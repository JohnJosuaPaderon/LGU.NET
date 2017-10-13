namespace LGU.Entities.Core
{
    public interface IPersonParameters
    {
        string Id { get; }
        string FirstName { get; }
        string MiddleName { get; }
        string LastName { get; }
        string NameExtension { get; }
        string BirthDate { get; }
        string Deceased { get; }
        string GenderId { get; }
    }
}
