using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IApplicationStatusConverter<TDataReader> : IDataConverter<IApplicationStatus, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
