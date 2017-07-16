using LGU.Entities.HumanResource;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IDepartmentConverter<TDataReader> : IDataConverter<Department, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
