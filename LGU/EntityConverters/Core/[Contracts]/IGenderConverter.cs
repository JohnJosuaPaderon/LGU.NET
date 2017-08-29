using LGU.Entities.Core;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.Core
{
    public interface IGenderConverter<TDataReader> : IDataConverter<IGender, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
