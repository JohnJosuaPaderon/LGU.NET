namespace LGU.Entities.Core
{
    public class Document : Entity<long>, IDocument
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IDocumentPathType PathType { get; set; }
        public string Path { get; set; }
        public byte[] Data { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
