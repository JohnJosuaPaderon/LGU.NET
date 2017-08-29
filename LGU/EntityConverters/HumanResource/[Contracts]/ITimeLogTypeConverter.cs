using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface ITimeLogTypeConverter<TDataReader> : IDataConverter<ITimeLogType, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
