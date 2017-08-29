using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IApplicationDocumentConverter<TDataReader> : IDataConverter<IApplicationDocument, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
