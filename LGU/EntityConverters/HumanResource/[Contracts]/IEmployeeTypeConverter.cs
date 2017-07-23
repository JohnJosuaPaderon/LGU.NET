using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IEmployeeTypeConverter<TDataReader> : IDataConverter<EmployeeType, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
