using LGU.Core.Entities;

namespace LGU.Core.EntityProcesses
{
    /// <summary>
    /// Exposes a functionality that constructs person's full name
    /// </summary>
    public interface IConstructPersonFullName : IProcess<string>
    {
        /// <summary>
        /// The source of name chunks
        /// </summary>
        Person Person { get; }
    }
}
