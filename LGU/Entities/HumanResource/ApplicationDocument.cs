using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public class ApplicationDocument : Document
    {
        public Application Application { get; set; }
        public ApplicationDocumentCategory Category { get; set; }
    }
}
