using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU
{
    public interface IDataConverter<T, TDataReader>
        where TDataReader : DbDataReader
    {
        IDataProcessResult<T> FromReader(TDataReader reader);
        Task<IDataProcessResult<T>> FromReaderAsync(TDataReader reader);
        Task<IDataProcessResult<T>> FromReaderAsync(TDataReader reader, CancellationToken cancellationToken);
        IEnumerableDataProcessResult<T> EnumerableFromReader(TDataReader reader);
        Task<IEnumerableDataProcessResult<T>> EnumerableFromReaderAsync(TDataReader reader);
        Task<IEnumerableDataProcessResult<T>> EnumerableFromReaderAsync(TDataReader reader, CancellationToken cancellationToken);
    }
}
