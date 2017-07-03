namespace LGU.Entities.Core
{
    public class UserStatus : Entity<ushort>
    {
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
