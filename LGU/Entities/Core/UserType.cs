namespace LGU.Entities.Core
{
    public class UserType : Entity<ushort>
    {
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
