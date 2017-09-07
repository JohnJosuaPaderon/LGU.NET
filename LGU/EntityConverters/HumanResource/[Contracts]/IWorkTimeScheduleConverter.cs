using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IWorkTimeScheduleConverter<TDataReader> : IDataConverter<IWorkTimeSchedule, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
