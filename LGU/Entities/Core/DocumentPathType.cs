namespace LGU.Entities.Core
{
    public class DocumentPathType : Entity<ushort>
    {
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
