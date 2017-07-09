namespace LGU.Entities.Core
{
    public class Gender : Entity<short>
    {
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
