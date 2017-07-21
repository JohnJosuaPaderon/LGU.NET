using System;

namespace LGU.Entities.Core
{
    public class Document : Entity<long>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DocumentPathType PathType { get; set; }
        public Uri Path { get; set; }
        public byte[] Data { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
