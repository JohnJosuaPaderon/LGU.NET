using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface ILocatorConverter<TDataReader> : IDataConverter<Locator, TDataReader>
       where TDataReader : DbDataReader
    {
    }
}
