using LGU.Entities.Core;

namespace LGU.Utilities.Core
{
    public sealed class PersonPlaceholderResolver : PlaceholderResolver, IPersonPlaceholderResolver
    {
        public PersonPlaceholderResolver() : base("Core.Person")
        {
        }

        public string Resolve(Person person, string placeholder)
        {
            switch (GetPropertyName(placeholder))
            {
                case nameof(Person.Id): return person.Id.ToString();
                case nameof(Person.FirstName): return person.FirstName;
                case nameof(Person.MiddleName): return person.MiddleName;
                case nameof(Person.LastName): return person.LastName;
                case nameof(Person.NameExtension): return person.NameExtension;
                case nameof(Person.FullName): return person.FullName;
                case nameof(Person.InformalFullName): return person.InformalFullName;
                default: return null;
            }
        }
    }
}
