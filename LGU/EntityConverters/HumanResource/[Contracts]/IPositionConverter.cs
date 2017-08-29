using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IPositionConverter<TDataReader> : IDataConverter<IPosition, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
