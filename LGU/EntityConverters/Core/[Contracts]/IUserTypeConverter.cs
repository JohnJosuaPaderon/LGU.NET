using LGU.Entities.Core;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.Core
{
    public interface IUserTypeConverter<TDataReader> : IDataConverter<UserType, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
