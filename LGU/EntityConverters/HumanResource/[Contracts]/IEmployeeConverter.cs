using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IEmployeeConverter<TDataReader> : IDataConverter<IEmployee, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
