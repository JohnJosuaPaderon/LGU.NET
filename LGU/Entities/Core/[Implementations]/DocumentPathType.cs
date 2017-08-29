namespace LGU.Entities.Core
{
    public class DocumentPathType : Entity<short>, IDocumentPathType
    {
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
