using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface ITimeLogTypeConverter<TDataReader> : IDataConverter<TimeLogType, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
