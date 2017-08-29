using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface ILocatorConverter<TDataReader> : IDataConverter<ILocator, TDataReader>
       where TDataReader : DbDataReader
    {
    }
}
