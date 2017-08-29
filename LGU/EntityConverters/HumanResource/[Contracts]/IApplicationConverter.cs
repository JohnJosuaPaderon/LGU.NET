using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IApplicationConverter<TDataReader> : IDataConverter<IApplication, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
