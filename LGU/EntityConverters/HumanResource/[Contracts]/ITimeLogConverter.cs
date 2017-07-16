using LGU.Entities.HumanResource;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface ITimeLogConverter<TDataReader> : IDataConverter<TimeLog, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
