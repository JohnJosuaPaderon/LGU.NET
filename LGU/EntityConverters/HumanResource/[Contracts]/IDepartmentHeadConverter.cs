using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IDepartmentHeadConverter<TDataReader> : IDataConverter<IDepartmentHead, TDataReader>
       where TDataReader : DbDataReader
    {
    }
}
