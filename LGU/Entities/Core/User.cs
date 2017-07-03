using System;

namespace LGU.Entities.Core
{
    public class User : Entity<ulong>
    {
        public User()
        {
        }

        public User(Person owner)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        public string SecureUsername { get; set; }
        public string SecurePassword { get; set; }
        public UserStatus Status { get; set; }
        public UserType Type { get; set; }
        public Person Owner { get; }
        public string DisplayName { get; set; }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
