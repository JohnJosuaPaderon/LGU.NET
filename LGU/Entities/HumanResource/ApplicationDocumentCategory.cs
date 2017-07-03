namespace LGU.Entities.HumanResource
{
    public class ApplicationDocumentCategory : Entity<ushort>
    {
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
