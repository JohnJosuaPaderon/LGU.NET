using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IEmploymentStatusConverter<TDataReader> : IDataConverter<EmploymentStatus, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
