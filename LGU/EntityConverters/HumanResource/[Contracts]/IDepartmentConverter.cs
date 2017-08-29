using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IDepartmentConverter<TDataReader> : IDataConverter<IDepartment, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
