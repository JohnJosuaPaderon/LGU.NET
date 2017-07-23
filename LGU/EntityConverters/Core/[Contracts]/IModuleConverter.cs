using LGU.Entities.Core;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.Core
{
    public interface IModuleConverter<TDataReader> : IDataConverter<Module, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
