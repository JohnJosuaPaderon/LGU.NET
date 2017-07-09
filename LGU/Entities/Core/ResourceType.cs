namespace LGU.Entities.Core
{
    public class ResourceType : Entity<short>
    {
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
