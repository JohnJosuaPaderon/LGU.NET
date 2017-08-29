using LGU.Entities.Core;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.Core
{
    public interface IDocumentConverter<TDataReader> : IDataConverter<IDocument, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
