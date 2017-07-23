using LGU.Entities.Core;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.Core
{
    public interface IDocumentConverter<TDataReader> : IDataConverter<Document, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
