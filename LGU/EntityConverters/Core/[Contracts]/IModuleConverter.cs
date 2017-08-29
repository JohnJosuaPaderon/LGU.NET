using LGU.Entities.Core;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.Core
{
    public interface IModuleConverter<TDataReader> : IDataConverter<IModule, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
