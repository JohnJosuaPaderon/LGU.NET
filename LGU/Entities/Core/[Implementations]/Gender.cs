namespace LGU.Entities.Core
{
    public class Gender : Entity<short>, IGender
    {
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
