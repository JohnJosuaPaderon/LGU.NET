using LGU.Entities.Core;
using System.Data.Common;

namespace LGU.EntityConverters.Core
{
    public interface IUserConverter<TDataReader> : IDataConverter<User, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
