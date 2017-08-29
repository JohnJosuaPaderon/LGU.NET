namespace LGU.Entities.Core
{
    public class UserType : Entity<short>, IUserType
    {
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
