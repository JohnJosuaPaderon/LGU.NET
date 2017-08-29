using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public interface IApplicationDocument : IDocument
    {
        IApplication Application { get; }
    }
}
