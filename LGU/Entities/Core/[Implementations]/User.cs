 using System;
using System.Security;

namespace LGU.Entities.Core
{
    public class User : Entity<long>, IUser
    {
        public User()
        {
        }

        public User(IPerson owner)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        public SecureString SecureUsername { get; set; }
        public SecureString SecurePassword { get; set; }
        public IUserStatus Status { get; set; }
        public IUserType Type { get; set; }
        public IPerson Owner { get; }
        public string DisplayName { get; set; }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
