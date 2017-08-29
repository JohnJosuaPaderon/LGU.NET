using LGU.Entities.Core;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.Core
{
    public interface IUserStatusConverter<TDataReader> : IDataConverter<IUserStatus, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
