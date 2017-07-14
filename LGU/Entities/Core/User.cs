 using System;
using System.Security;

namespace LGU.Entities.Core
{
    public class User : Entity<long>
    {
        public User()
        {
        }

        public User(Person owner)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        public SecureString SecureUsername { get; set; }
        public SecureString SecurePassword { get; set; }
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
