using LGU.Entities.Core;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.Core
{
    public interface IUserConverter<TDataReader> : IDataConverter<IUser, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
