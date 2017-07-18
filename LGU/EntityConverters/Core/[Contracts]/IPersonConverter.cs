using LGU.Entities.Core;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.Core
{
    public interface IPersonConverter<TDataReader> : IDataConverter<Person, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
