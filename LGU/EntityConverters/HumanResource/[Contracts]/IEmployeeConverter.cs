using LGU.Entities.HumanResource;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IEmployeeConverter<TDataReader> : IDataConverter<Employee, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
