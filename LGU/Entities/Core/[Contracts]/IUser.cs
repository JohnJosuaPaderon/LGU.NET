using System.Security;

namespace LGU.Entities.Core
{
    public interface IUser : IEntity<long>
    {
        SecureString SecureUsername { get; set; }
        SecureString SecurePassword { get; set; }
        IUserStatus Status { get; set; }
        IUserType Type { get; set; }
        IPerson Owner { get; }
        string DisplayName { get; set; }
    }
}
