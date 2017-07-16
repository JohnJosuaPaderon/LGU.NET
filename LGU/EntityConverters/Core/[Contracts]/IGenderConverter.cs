using LGU.Entities.Core;
using System.Data.Common;

namespace LGU.EntityConverters.Core
{
    public interface IGenderConverter<TDataReader> : IDataConverter<Gender, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
