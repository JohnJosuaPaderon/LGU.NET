namespace LGU.Entities.Core
{
    public interface IDocument : IEntity<long>
    {
        string Title { get; set; }
        string Description { get; set; }
        IDocumentPathType PathType { get; set; }
        string Path { get; set; }
        byte[] Data { get; set; }
    }
}
