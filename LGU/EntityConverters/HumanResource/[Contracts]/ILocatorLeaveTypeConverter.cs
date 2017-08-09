using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface ILocatorLeaveTypeConverter<TDataReader> : IDataConverter<LocatorLeaveType, TDataReader>
       where TDataReader : DbDataReader
    {
    }
}
