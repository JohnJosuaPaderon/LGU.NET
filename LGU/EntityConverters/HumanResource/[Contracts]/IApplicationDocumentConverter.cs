using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IApplicationDocumentConverter<TDataReader> : IDataConverter<ApplicationDocument, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
